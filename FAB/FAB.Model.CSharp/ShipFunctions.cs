using System;

namespace FAB.Model
{
    public static class ShipFunctions
    {
        public static Ship setPosition(this Ship ship, Location loc, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, ship.Hits, loc, orient);
        }

        //Calculated based on the size and the orientation of the ship
        public static bool occupies(this Ship ship, Location loc)
        {
            return ship.Orientation == Orientations.Horizontal ?
                 ship.Location.Row == loc.Row &&
                    loc.Col >= ship.Location.Col && loc.Col < ship.Location.Col + ship.Size :
                 ship.Location.Col == loc.Col &&
                    loc.Row >= ship.Location.Row && loc.Row < ship.Location.Row + ship.Size;
        }

        public static bool isHitInLocation(this Ship ship, Location loc)
        {
            return ship.Hits.Contains(loc);
        }

        public static Tuple<Ship, bool, String> fireAt(this Ship ship, Location loc)
        {
            if (ship.occupies(loc))
            {
                var newHits = ship.Hits.Add(loc);
                var newShip = new Ship(ship.Name, ship.Size, newHits, ship.Location, ship.Orientation);
                var message = isSunk(newShip) ? newShip.Name + " sunk!" : "Hit a " + newShip.Name + " at (" + loc.Col + "," + loc.Row + ").";
                return Tuple.Create(newShip, true, message);
            }
            else
            {
                return Tuple.Create(ship, false, "");
            }
        }

        public static bool isSunk(this Ship ship)
        {
            return ship.Hits.Count >= ship.Size;
        }
    }
}
