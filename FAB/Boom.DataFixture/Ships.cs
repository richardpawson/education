using Boom.Model;
using System;
using System.Collections.Immutable;

namespace Boom.DataFixture
{
    public static class Ships
    {
        private static ImmutableHashSet<Tuple<int, int>> noHits = ImmutableHashSet<Tuple<int, int>>.Empty;
  
        //Returns five ships with no placings. Intention is that after creating a new
        // GameBoard with this set, you would call RandomiseShipPlacement() on it.
        public static ImmutableArray<Ship> UnplacedShips5()
        {
             return ImmutableArray.Create(
                new Ship("Aircraft Carrier",5, noHits),
                new Ship("Battleship", 4, noHits),
                new Ship("Submarine", 3, noHits),
                new Ship("Destroyer", 3, noHits),
                new Ship("Patrol Boat", 2, noHits)
            );
        }

        public static ImmutableArray<Ship> UnplacedShips4()
        {
            return  ImmutableArray.Create(
                new Ship("Patrol Boat", 2, noHits),
                new Ship("Patrol Boat", 2, noHits),
                new Ship("Patrol Boat", 2, noHits),
                new Ship("Patrol Boat", 2, noHits)
            );
        }

        public static ImmutableArray<Ship> TrainingGame()
        {
            return ImmutableArray.Create(
                new Ship("Aircraft Carrier", 5, noHits, 1,8,Orientations.Horizontal),
                new Ship("Battleship", 4, noHits, 8, 1, Orientations.Vertical),
                new Ship("Submarine", 3, noHits, 7, 6, Orientations.Vertical),
                new Ship("Destroyer", 3, noHits, 5, 9, Orientations.Horizontal),
                new Ship("Patrol Boat", 2, noHits, 1, 4, Orientations.Vertical)
            );
        }

        //Contains only two small ships.  Intent is for testing a complete game scenario.
        public static ImmutableArray<Ship> SmallTestGame()
        {
            return ImmutableArray.Create(
                new Ship("Minesweeper", 1, noHits, 2, 3, Orientations.Horizontal),
                new Ship("Frigate", 2, noHits, 4, 5, Orientations.Vertical)
            );
        }
    }
}
