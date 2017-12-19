using FAB.Model;
using FunctionalLibrary;
using System.Collections.Immutable;

namespace FAB.DataFixture
{
    public static class Ships
    {
        public const string AircraftCarrier = "Aircraft Carrier";
        public const string Battleship = "Battleship";
        public const string Submarine = "Submarine";
        public const string Destroyer = "Destroyer";
        public const string PatrolBoat = "Patrol Boat";
        public const string Minesweeper = "Minesweeper";
        public const string Frigate = "Frigate";

        //Returns five ships with no placings. Intention is that after creating a new
        // GameBoard with this set, you would call RandomiseShipPlacement() on it.
        public static FList<Ship> UnplacedShips5()
        {
             return FList.Cons(
                new Ship(AircraftCarrier,5),
                new Ship(Battleship, 4),
                new Ship(Submarine, 3),
                new Ship(Destroyer, 3),
                new Ship(PatrolBoat, 2)
            );
        }
        public static FList<Ship> UnplacedShips4()
        {
            return FList.Cons(
                new Ship(PatrolBoat, 2),
                new Ship(PatrolBoat, 2),
                new Ship(PatrolBoat, 2),
                new Ship(PatrolBoat, 2)
            );
        }

        public static FList<Ship> TrainingGame()
        {
            return FList.Cons(
                new Ship(AircraftCarrier, 5,  new Location(1,8),Orientations.Horizontal),
                new Ship(Battleship, 4,  new Location(8, 1), Orientations.Vertical),
                new Ship(Submarine, 3,  new Location(7, 6), Orientations.Vertical),
                new Ship(Destroyer, 3,  new Location(5, 9), Orientations.Horizontal),
                new Ship(PatrolBoat, 2,  new Location(1, 4), Orientations.Vertical)
            );
        }

        //Contains only two small ships.  Intent is for testing a complete game scenario.
        public static FList<Ship> SmallTestGame()
        {
            return FList.Cons(
                new Ship(Minesweeper, 1,  new Location(2, 3), Orientations.Horizontal),
                new Ship(Frigate, 2, new Location(4, 5), Orientations.Vertical)
            );
        }
    }
}
