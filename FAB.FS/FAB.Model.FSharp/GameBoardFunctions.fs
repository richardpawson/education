module GameBoardFunctions
open FAB.Model
open System
open TechnicalServices

let readSquare (board:GameBoard) (loc:Location)= 
    if board.Ships |> Seq.exists (fun (ship: Ship) -> ShipFunctions.isHitInLocation ship loc) then
        SquareValues.Hit
    else if board.Misses |> Seq.contains loc then
        SquareValues.Miss
    else 
        SquareValues.Empty

let allSunk ships  = not (ships |> Seq.exists(fun (ship : Ship)-> not(ShipFunctions.isSunk ship)))

let rec getLocations (start: Location) orient (numberToAdd: int)  =
    match orient with
    |Orientations.Horizontal -> Seq.init numberToAdd (fun n -> start.Add n 0 )
    |_ -> Seq.init numberToAdd (fun n -> start.Add 0 n)    
         
let fitsWithinBoundaries  boardSize  (ship: Ship) =
    match ship.Orientation with
     |Orientations.Horizontal -> ship.Location.Col + ship.Size <= boardSize
     |_ ->  ship.Location.Row + ship.Size <= boardSize

let isValidPosition boardSize existingShips ship =
    match fitsWithinBoundaries boardSize ship with
    | false -> false
    | true ->
        let anyShipOccupiesLocation ships loc =
            ships |> Seq.exists( fun (ship: Ship) -> ShipFunctions.occupies ship loc)
        let locs= getLocations ship.Location ship.Orientation ship.Size
        not (locs |> Seq.exists( fun loc -> anyShipOccupiesLocation existingShips loc))
       
let getRandomPosition boardSize  (random: Random) =
    let result1 = RandomNumbers.Next(random, 0, boardSize)
    let col = result1.Number
    let result2 = RandomNumbers.Next(result1.NewGenerator, 0, boardSize)
    let row = result2.Number
    let result3 = RandomNumbers.Next(result2.NewGenerator, 0, 2)
    let orientation : Orientations = LanguagePrimitives.EnumOfValue result3.Number
    let loc = new Location(col, row)
    (loc, orientation, result3.NewGenerator)

let rec setValidRandomPosition boardSize shipsAlreadyPlaced  (shipToBePlaced:Ship) random = 
    let loc,orient,newRandom = getRandomPosition boardSize  random
    let placedShip = new Ship(shipToBePlaced.Name, shipToBePlaced.Size, loc, orient)
    match isValidPosition boardSize shipsAlreadyPlaced placedShip with
        | true -> (placedShip, newRandom)
        | false -> setValidRandomPosition boardSize  shipsAlreadyPlaced  shipToBePlaced  newRandom

let rec locateShipsRandomly boardSize (shipsToBePlaced: seq<Ship>) shipsAlreadyPlaced random =
    match shipsToBePlaced |> Seq.isEmpty with
    | true -> List.empty
    | false -> 
        let thisShip = shipsToBePlaced |> Seq.head;
        let message = "Computer placing the " + thisShip.Name + "\n";
        let placedShip, newRandom = setValidRandomPosition boardSize  shipsAlreadyPlaced  thisShip  random
        let shipPlacement = (placedShip, message)
        let newshipsAlreadyPlaced = placedShip :: shipsAlreadyPlaced
        let newShipsToBePlaced = shipsToBePlaced |> Seq.skip 1 
        shipPlacement :: locateShipsRandomly boardSize newShipsToBePlaced newshipsAlreadyPlaced newRandom
    
let createBoardWithShipsPlacedRandomly boardSize shipsToBePlaced random =
    let shipPlacements = locateShipsRandomly boardSize shipsToBePlaced List.Empty random
    let newShips = shipPlacements |> Seq.map(fun sp -> fst sp)
    let messages = shipPlacements |> Seq.map(fun sp -> snd sp)
    let aggregateMsg = messages |> Seq.fold (+) ""
    new GameBoard(boardSize, newShips, aggregateMsg, List.Empty)

let checkSquareAndRecordOutcome (board: GameBoard) loc aggregateMessages =
    let results = board.Ships |> Seq.map(fun (s: Ship) -> ShipFunctions.fireAt s loc)
    let newShips = results |> Seq.map(fun r -> match r with (ship,_,_) -> ship)
    let hits = results |> Seq.map(fun r -> match r with (_,hit,_) -> hit)
    let hit = hits |> Seq.fold (||) false
    let messages = results |> Seq.map(fun r -> match r with (_,_,msg) -> msg)
    let foldedMessages = messages |> Seq.fold (+) ""
    let aggregatedMessages = if aggregateMessages then board.Messages + foldedMessages else foldedMessages
    let misses = board.Misses;
    match hit with 
    | true -> 
        match allSunk newShips with
        | true -> 
            let allSunk = foldedMessages + "All ships sunk!"
            new GameBoard(board.Size, newShips, allSunk, misses)
        | false -> new GameBoard(board.Size, newShips, aggregatedMessages, misses)
    | false ->
        let newMisses = loc :: Seq.toList(board.Misses)
        let sorry = aggregatedMessages + "Sorry, (" + loc.Col.ToString() + "," + loc.Row.ToString() + ") is a miss."
        new GameBoard(board.Size, newShips, sorry, newMisses)

let rec checkSquaresAndRecordOutcome board (locs : List<Location>) =
    let boardFromHead = checkSquareAndRecordOutcome board locs.Head true
    match locs.Length with
        | 1 -> boardFromHead
        | _ -> checkSquaresAndRecordOutcome boardFromHead locs.Tail;