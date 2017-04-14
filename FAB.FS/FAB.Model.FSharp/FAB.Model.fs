namespace FAB.Model
open System
open TechnicalServices

type Orientations = Horizontal = 0|Vertical=1

type SquareValues = Empty=0|Miss=1|Hit=2

type Location(col: int, row: int) =
    struct
        member this.Col = col
        member this.Row = row   
        member this.Add colInc rowInc = new Location(this.Col + colInc, this.Row + rowInc)
    end

type Ship(name, size, hits: Set<Location>, loc: Location, orient) = 
    new (name, size) =
        Ship(name, size, Set.empty, new Location(0,0), Orientations.Horizontal)
    new (name, size,loc: Location, orient) =
        Ship(name, size, Set.empty, loc, orient)
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
            //TODO -   error here  -  need to use a set so hit locations cannot be duplicated
            let newHits =this.Hits.Add(loc)
            let newShip = new Ship(this.Name, this.Size, newHits, this.Location, this.Orientation)
            let message = if newShip.isSunk then newShip.Name + " sunk!" else "Hit a " + newShip.Name + " at (" + loc.Col.ToString() + "," + loc.Row.ToString() + ")."
            (newShip, true, message)
        else 
            (this, false, "")

type GameBoard(size, ships, messages: string, misses) = 
    member this.Size = size
    member this.Ships = ships
    member this.Messages = messages
    member this.Misses = misses
    member this.readSquare loc =
        //TODD: Use pattern matching here
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
