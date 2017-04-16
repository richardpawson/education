module ShipFunctions
open FAB.Model

let occupiesLocation (ship:Ship, loc: Location) =
    if ship.Orientation = Orientations.Horizontal then
        ship.Location.Row = loc.Row &&
            loc.Col >= ship.Location.Col && 
                loc.Col < ship.Location.Col + ship.Size
    else
        ship.Location.Col = loc.Col &&
            loc.Row >= ship.Location.Row && 
                loc.Row < ship.Location.Row + ship.Size;

let isSunk (ship:Ship) = ship.Hits |> Seq.length = ship.Size
let setPosition (ship:Ship, loc, orient) = new Ship(ship.Name, ship.Size, ship.Hits, loc, orient)
let isHitInLocation (ship:Ship, loc) = ship.Hits |> Seq.contains loc
let fireAt  (ship:Ship, loc) =
    if occupiesLocation(ship, loc) then
        //TODO -   error here  -  need to use a set so hit locations cannot be duplicated
        let newHits =ship.Hits.Add(loc)
        let newShip = new Ship(ship.Name, ship.Size, newHits, ship.Location, ship.Orientation)
        let message = if isSunk newShip then newShip.Name + " sunk!" else "Hit a " + newShip.Name + " at (" + loc.Col.ToString() + "," + loc.Row.ToString() + ")."
        (newShip, true, message)
    else 
        (ship, false, "")

