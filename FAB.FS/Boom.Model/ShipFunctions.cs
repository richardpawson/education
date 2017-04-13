using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom.Model
{
    public static class ShipFunctions
    {
        #region Ship-related functions

        public static Ship SetPosition(this Ship ship, Location loc, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, ship.Hits, loc, orient);
        }

        //Calculated based on the size and the orientation of the ship
        public static bool ShipOccupiesLocation(this Ship ship, Location loc)
        {
            return ship.Orientation == Orientations.Horizontal ?
                 ship.Location.Row == loc.Row &&
                    loc.Col >= ship.Location.Col && loc.Col < ship.Location.Col + ship.Size :
                 ship.Location.Col == loc.Col &&
                    loc.Row >= ship.Location.Row && loc.Row < ship.Location.Row + ship.Size;
        }

        public static bool IsHitInLocation(this Ship ship, Location loc)
        {
            return ship.Hits.Contains(loc);
        }

        public static Tuple<Ship, bool, String> FireAt(this Ship ship, Location loc)
        {
            if (ship.ShipOccupiesLocation(loc))
            {
                var newHits = ship.Hits.Add(loc);
                var newShip = new Ship(ship.Name, ship.Size, newHits, ship.Location, ship.Orientation);
                var message = IsSunk(newShip) ? newShip.Name + " sunk!" : "Hit a " + newShip.Name + " at (" + loc.Col + "," + loc.Row + ").";
                return Tuple.Create(newShip, true, message);
            }
            else
            {
                return Tuple.Create(ship, false, "");
            }
        }

        public static bool IsSunk(this Ship ship)
        {
            return ship.Hits.Count >= ship.Size;
        }
        #endregion

    }
}
