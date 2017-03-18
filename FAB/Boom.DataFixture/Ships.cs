using Boom.Model;

namespace Boom.DataFixture
{
    public static class Ships
    {
        //Returns five ships with no placings. Intention is that after creating a new
        // GameBoard with this set, you would call RandomiseShipPlacement() on it.
        public static Ship[] UnplacedShips5()
        {
            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier",5);
            ships[1] = new Ship("Battleship",4);
            ships[2] = new Ship("Submarine", 3);
            ships[3] = new Ship("Destroyer", 3);
            ships[4] = new Ship("Patrol Boat", 2);
            return ships;
        }

        public static Ship[] UnplacedShips2()
        {
            var ships = new Ship[2];
            ships[0] = new Ship("Destroyer", 3);
            ships[1] = new Ship("Patrol Boat", 2);
            return ships;
        }

        public static Ship[] TrainingGame() {
            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier", 5, 1,8,Orientations.Horizontal);
            ships[1] = new Ship("Battleship", 4,8,1,Orientations.Vertical);
            ships[2] = new Ship("Submarine", 3,7,6,Orientations.Vertical);
            ships[3] = new Ship("Destroyer", 3,5,9,Orientations.Horizontal);
            ships[4] = new Ship("Patrol Boat", 2,1,4,Orientations.Vertical);
            return ships;
        }

        //Contains only two small ships.  Intent is for testing a complete game scenario.
        public static Ship[] SmallTestGame()
        {
            var ships = new Ship[2];
            ships[0] = new Ship("Minesweeper", 1, 2, 3, Orientations.Horizontal);
            ships[1] = new Ship("Frigate", 2, 4, 5, Orientations.Vertical);
            return ships;
        }
    }
}
