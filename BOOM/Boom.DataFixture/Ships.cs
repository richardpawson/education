using Boom.Model;

namespace Boom.DataFixture
{
    public static class Ships
    {
        public static Ship[] UnplacedShips1()
        {
            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier",5);
            ships[1] = new Ship("Battleship",4);
            ships[2] = new Ship("Submarine", 3);
            ships[3] = new Ship("Destroyer", 3);
            ships[4] = new Ship("Patrol Boat", 2);
            return ships;
        }

        public static Ship[] TrainingGame() {
            var ships = new Ship[5];
            ships[0] = new Ship("Aircraft Carrier", 5, 8,1,Orientations.Horizontal);
            ships[1] = new Ship("Battleship", 4,1,8,Orientations.Vertical);
            ships[2] = new Ship("Submarine", 3,6,7,Orientations.Vertical);
            ships[3] = new Ship("Destroyer", 3,9,5,Orientations.Horizontal);
            ships[4] = new Ship("Patrol Boat", 2,4,1,Orientations.Vertical);
            return ships;
        }
    }
}
