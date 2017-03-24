using Boom.Model;
using System;
using System.Collections.Immutable;

namespace Boom.DataFixture
{
    public static class Ships
    {
        private static ImmutableHashSet<Location> noHits = ImmutableHashSet<Location>.Empty;
  
        //Returns five ships with no placings. Intention is that after creating a new
        // GameBoard with this set, you would call RandomiseShipPlacement() on it.
        public static ImmutableArray<Ship> UnplacedShips5()
        {
             return ImmutableArray.Create(
                new Ship("Aircraft Carrier",5),
                new Ship("Battleship", 4),
                new Ship("Submarine", 3),
                new Ship("Destroyer", 3),
                new Ship("Patrol Boat", 2)
            );
        }

        public static ImmutableArray<Ship> UnplacedShips4()
        {
            return  ImmutableArray.Create(
                new Ship("Patrol Boat", 2),
                new Ship("Patrol Boat", 2),
                new Ship("Patrol Boat", 2),
                new Ship("Patrol Boat", 2)
            );
        }

        public static ImmutableArray<Ship> TrainingGame()
        {
            return ImmutableArray.Create(
                new Ship("Aircraft Carrier", 5, noHits, new Location(1,8),Orientations.Horizontal),
                new Ship("Battleship", 4, noHits, new Location(8, 1), Orientations.Vertical),
                new Ship("Submarine", 3, noHits, new Location(7, 6), Orientations.Vertical),
                new Ship("Destroyer", 3, noHits, new Location(5, 9), Orientations.Horizontal),
                new Ship("Patrol Boat", 2, noHits, new Location(1, 4), Orientations.Vertical)
            );
        }

        //Contains only two small ships.  Intent is for testing a complete game scenario.
        public static ImmutableArray<Ship> SmallTestGame()
        {
            return ImmutableArray.Create(
                new Ship("Minesweeper", 1, noHits, new Location(2, 3), Orientations.Horizontal),
                new Ship("Frigate", 2, noHits, new Location(4, 5), Orientations.Vertical)
            );
        }
    }
}
