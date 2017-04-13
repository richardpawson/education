module GameBoardFunctions
open FAB.Model
open System
open TechnicalServices

let allShipsSunk ships  = ships |> Seq.exists(fun (ship : Ship)-> not(ship.isSunk))

let rec locationsThatShipWouldOccupy (loc: Location) orient (locsToAdd: int)  =
    let result =
        if locsToAdd = 0 then
            List.empty
        else
            if orient = Orientations.Horizontal then
                loc :: locationsThatShipWouldOccupy (loc.Add 1 0) orient (locsToAdd - 1) 
            else
                loc :: locationsThatShipWouldOccupy (loc.Add 0 1) orient (locsToAdd - 1)   
    result

//TODO: Move back onto Ship?
let shipWouldFitWithinBoard  boardSize  (ship: Ship)  (loc: Location)  orientation =
    (orientation = Orientations.Horizontal && loc.Col + ship.Size <= boardSize) ||
        (orientation = Orientations.Vertical && loc.Row + ship.Size <= boardSize)

//TODO: If this is being done with a ship, why not set its location& test validity?
let isValidPosition boardSize existingShips shipToBePlaced loc orientation =
    if not(shipWouldFitWithinBoard boardSize shipToBePlaced loc orientation) then
        false
    else
        let anyShipOccupiesLocation ships loc =
            ships |> Seq.exists( fun (ship: Ship) -> ship.occupiesLocation(loc))
        let locs= locationsThatShipWouldOccupy loc orientation shipToBePlaced.Size
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

let rec getValidRandomPosition boardSize shipsAlreadyLocated  shipToBeLocated random = 
    let pos = getRandomPosition boardSize  random
    let loc,orient,random = pos
    if isValidPosition boardSize shipsAlreadyLocated shipToBeLocated loc orient then
        pos
    else
        getValidRandomPosition boardSize  shipsAlreadyLocated  shipToBeLocated  random
    
let locateShipRandomly boardSize shipsAlreadyLocated (shipToBeLocated: Ship) random =
    let loc,orient,random = getValidRandomPosition boardSize  shipsAlreadyLocated  shipToBeLocated  random
    let message = "Computer placing the " + shipToBeLocated.Name + "\n";
    let newShip = shipToBeLocated.setPosition loc orient;
    (newShip, message, random);

let rec locateShipsRandomly boardSize (shipsToBePlaced: seq<Ship>) shipsAlreadyPlaced random =
    if shipsToBePlaced |> Seq.isEmpty then
        List.empty
    else 
        let thisShip = shipsToBePlaced |> Seq.head;
        let ship,message,newRandom = locateShipRandomly boardSize shipsAlreadyPlaced thisShip random
        let shipPlacement = (ship, message)
        let newshipsAlreadyPlaced = ship :: shipsAlreadyPlaced
        let newShipsToBePlaced = shipsToBePlaced |> Seq.skip 1 
        shipPlacement :: locateShipsRandomly boardSize newShipsToBePlaced newshipsAlreadyPlaced newRandom
    
let placeShipsRandomlyOnBoard boardSize shipsToBePlaced random =
    let shipPlacements = locateShipsRandomly boardSize shipsToBePlaced List.Empty random
    let newShips = shipPlacements |> Seq.map(fun sp -> fst sp)
    let messages = shipPlacements |> Seq.map(fun sp -> snd sp)
    let aggregateMsg = messages |> Seq.fold (+) ""
    new GameBoard(boardSize, newShips, aggregateMsg, List.Empty); 

let checkSquareAndRecordOutcome (board: GameBoard) loc aggregateMessages =
    let results = board.Ships |> Seq.map(fun (s: Ship) -> s.fireAt(loc))
    let newShips = results |> Seq.map(fun r -> match r with (ship,_,_) -> ship)
    let hits = results |> Seq.map(fun r -> match r with (_,hit,_) -> hit)
    let hit = hits |> Seq.fold (||) false
    let newMessages = results |> Seq.map(fun r -> match r with (_,_,msg) -> msg)
    let newMessage = newMessages |> Seq.fold (+) ""
    let aggregatedMessages = if aggregateMessages then board.Messages + newMessage else newMessage
    let misses = board.Misses;
    if hit then
        if allShipsSunk newShips then
            let newMessage = newMessage + "All ships sunk!"
            new GameBoard(board.Size, newShips, newMessage, misses);
        else
             new GameBoard(board.Size, newShips, aggregatedMessages, misses);
    else
        let newMisses = loc :: Seq.toList(board.Misses)
        let newMessage = aggregatedMessages + "Sorry, (" + loc.Col.ToString() + "," + loc.Row.ToString() + ") is a miss.";
        new GameBoard(board.Size, newShips, newMessage, newMisses);

    
let rec checkSquaresAndRecordOutcome board (locs : List<Location>) =
    let boardFromHead = checkSquareAndRecordOutcome board locs.Head true
    if locs.Length = 1 then
        boardFromHead
    else
        checkSquaresAndRecordOutcome boardFromHead locs.Tail;
