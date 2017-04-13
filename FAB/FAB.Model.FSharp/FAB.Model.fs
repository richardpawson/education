module Model
open System
open TechnicalServices

type Orientations = Horizontal = 0|Vertical=1

type SquareValues = Empty=0|Miss=1|Hit=2

type Location(col: int, row: int) =
    member this.Col = col
    member this.Row = row   
    member this.Add colInc rowInc = new Location(this.Col + colInc, this.Row + rowInc)

type Ship(name, size, hits, loc: Location, orient) = 
    member this.Name = name
    member this.Size = size
    member this.Hits = hits
    member this.Location = loc
    member this.Orientation = orient
    member this.isSunk  = this.Hits |> Seq.length = this.Size
    member this.setPosition loc orient = new Ship(this.Name, this.Size, this.Hits, loc, orient)
    member this.isHitInLocation loc = this.Hits |> Seq.contains loc
    member this.occupiesLocation (loc: Location) =
        if this.Orientation = Orientations.Horizontal then
            this.Location.Row = loc.Row &&
                loc.Col >= this.Location.Col && 
                    loc.Col < this.Location.Col + this.Size
        else
            this.Location.Col = loc.Col &&
                loc.Row >= this.Location.Row && 
                    loc.Row < this.Location.Row + this.Size;
    member this.fireAt loc =
        if this.occupiesLocation loc then
            let newHits = loc :: this.Hits
            let newShip = new Ship(this.Name, this.Size, newHits, this.Location, this.Orientation)
            let message = if this.isSunk then newShip.Name + " sunk!" else "Hit a " + newShip.Name + " at (" + loc.Col.ToString() + "," + loc.Row.ToString() + ")."
            (newShip, true, message)
        else 
            (this, false, "")

type GameBoard(size, ships, messages, misses) = 
    member this.Size = size
    member this.Ships = ships
    member this.Messages = messages
    member this.Misses = misses
    member this.readSquare loc =
        let result = 
            if this.Ships |> Seq.exists (fun (ship: Ship) -> ship.isHitInLocation loc) then
                SquareValues.Hit
            else if this.Misses |> Seq.contains loc then
                SquareValues.Miss
            else 
                SquareValues.Empty
        result
    member this.contains (loc: Location) =
        loc.Col >= 0 && loc.Col < this.Size && loc.Row >= 0 && loc.Row < this.Size

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

let rec locateShipsRandomly boardSize (shipsToBePlaced: List<Ship>) shipsAlreadyPlaced random =
    if shipsToBePlaced.IsEmpty then
        List.empty
    else 
        let thisShip = shipsToBePlaced.Head;
        let ship,message,newRandom = locateShipRandomly boardSize shipsAlreadyPlaced thisShip random
        let shipPlacement = (ship, message)
        let newshipsAlreadyPlaced = ship :: shipsAlreadyPlaced
        let newShipsToBePlaced = shipsToBePlaced.Tail ;
        shipPlacement :: locateShipsRandomly boardSize newShipsToBePlaced newshipsAlreadyPlaced newRandom

let placeShipsRandomlyOnBoard boardSize shipsToBePlaced random =
    let shipPlacements = locateShipsRandomly boardSize shipsToBePlaced List.Empty random
    let newShips = shipPlacements |> Seq.map(fun sp -> fst sp)
    let messages = shipPlacements |> Seq.map(fun sp -> snd sp)
    let aggregateMsg = messages |> Seq.fold (+) ""
    new GameBoard(boardSize, newShips, aggregateMsg, List.Empty); 