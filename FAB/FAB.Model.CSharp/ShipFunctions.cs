using FunctionalLibrary;
using System;
using System.Linq;

namespace FAB.Model
{
    public static class ShipFunctions
    {
        public const string AircraftCarrier = "Aircraft Carrier";
        public const string Battleship = "Battleship";
        public const string Submarine = "Submarine";
        public const string Destroyer = "Destroyer";
        public const string PatrolBoat = "Patrol Boat";
        public const string Minesweeper = "Minesweeper";
        public const string Frigate = "Frigate";

        public static Ship setPosition(this Ship ship, Location loc, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, ship.Hits, loc, orient);
        }

        //Calculated based on the size and the orientation of the ship
        public static bool occupies(this Ship ship, Location loc)
        {
            return ship.Orientation == Orientations.Horizontal ?
                 ship.Location.Row == loc.Row &&
                    loc.Col >= ship.Location.Col && loc.Col < ship.Location.Col + ship.Size
                 : ship.Location.Col == loc.Col &&
                    loc.Row >= ship.Location.Row && loc.Row < ship.Location.Row + ship.Size;
        }

        public static bool horizontal(this Ship ship)
        {
            return ship.Orientation == Orientations.Horizontal;
        }

        public static bool vertical(this Ship ship)
        {
            return ship.Orientation == Orientations.Vertical;
        }

        //If ship is horizontal, this will be the first and last column numbers;
        //if vertical, the first and last row numbers
        public static Tuple<int, int> extent(this Ship ship)
        {
            return ship.horizontal() ?
                Tuple.Create(ship.HeadCol, ship.HeadCol + ship.Size-1) :
                Tuple.Create(ship.HeadRow, ship.HeadRow + ship.Size-1);
        }

        public static bool overlaps(this Tuple<int, int> extent1, Tuple<int, int> extent2)
        {
            return extent1.covers(extent2.Item1) || 
                extent1.covers(extent2.Item2) ||
                extent2.covers(extent1.Item1); //No need for 4th test
        }
        public static bool covers(this Tuple<int, int> extent, int value)
        {
            return value >= extent.Item1 && value <= extent.Item2; 
        }
        //Returns true if the two ships would overlap.
        public static bool intersects(this Ship ship1, Ship ship2)
        {
            return ship1.Orientation == ship2.Orientation ?
                (ship1.horizontal() && ship1.HeadRow == ship2.HeadRow ||
                    ship1.vertical() && ship1.HeadCol == ship2.HeadCol)
                    && ship1.extent().overlaps(ship2.extent()) 
                 : ship1.horizontal() && ship1.extent().covers(ship2.HeadCol) && ship2.extent().covers(ship1.Location.Row)
                    || ship1.vertical() && ship1.extent().covers(ship2.HeadRow) && ship2.extent().covers(ship1.HeadCol);
        }

        public static bool isHitInLocation(this Ship ship, Location loc)
        {
            return ship.Hits.Contains(loc);
        }

        public static Tuple<Ship, bool, string> fireAt(this Ship ship, Location loc)
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

        public static FList<Ship> TrainingGame()
        {
            return FList.Cons(
                new Ship(AircraftCarrier, 5, new Location(1, 8), Orientations.Horizontal),
                new Ship(Battleship, 4, new Location(8, 1), Orientations.Vertical),
                new Ship(Submarine, 3, new Location(7, 6), Orientations.Vertical),
                new Ship(Destroyer, 3, new Location(5, 9), Orientations.Horizontal),
                new Ship(PatrolBoat, 2, new Location(1, 4), Orientations.Vertical)
            );
        }
    }
}
