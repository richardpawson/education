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
        public static Ship[] UnplacedShips5()
        {

            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier",5, noHits);
            ships[1] = new Ship("Battleship",4, noHits);
            ships[2] = new Ship("Submarine", 3, noHits);
            ships[3] = new Ship("Destroyer", 3, noHits);
            ships[4] = new Ship("Patrol Boat", 2, noHits);
            return ships;
        }

        public static Ship[] UnplacedShips2()
        {
            var ships = new Ship[2];
            ships[0] = new Ship("Destroyer", 3, noHits);
            ships[1] = new Ship("Patrol Boat", 2, noHits);
            return ships;
        }

        public static Ship[] TrainingGame() {
            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier", 5, noHits, 1,8,Orientations.Horizontal);
            ships[1] = new Ship("Battleship", 4, noHits, 8,1,Orientations.Vertical);
            ships[2] = new Ship("Submarine", 3, noHits, 7,6,Orientations.Vertical);
            ships[3] = new Ship("Destroyer", 3, noHits, 5,9,Orientations.Horizontal);
            ships[4] = new Ship("Patrol Boat", 2, noHits, 1,4,Orientations.Vertical);
            return ships;
        }

        //Contains only two small ships.  Intent is for testing a complete game scenario.
        public static Ship[] SmallTestGame()
        {
            var ships = new Ship[2];
            ships[0] = new Ship("Minesweeper", 1, noHits, 2, 3, Orientations.Horizontal);
            ships[1] = new Ship("Frigate", 2, noHits, 4, 5, Orientations.Vertical);
            return ships;
        }
    }
}
