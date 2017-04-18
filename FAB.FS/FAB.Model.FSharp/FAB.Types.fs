namespace FAB.Types
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

type Ship(name: string, size: int, hits: Set<Location>, loc: Location, orient) = 
    new (name: string, size: int) =
        Ship(name, size, Set.empty, new Location(0,0), Orientations.Horizontal)
    new (name: string, size: int,loc: Location, orient) =
        Ship(name, size, Set.empty, loc, orient)
    member this.Name = name
    member this.Size = size
    member this.Hits = hits
    member this.Location = loc
    member this.Orientation = orient

type GameBoard(size: int, ships: seq<Ship>, messages: string, misses: seq<Location>) = 
    member this.Size = size
    member this.Ships = ships
    member this.Messages = messages
    member this.Misses = misses

   
