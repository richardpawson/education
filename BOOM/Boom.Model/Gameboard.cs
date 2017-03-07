using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        public int Size { get; private set; }
        private SquareValues[,] Squares;
        private Ship[] Ships;
        private ILogger Logger;
        private IRandomGenerator RandomGenerator;

        public GameBoard(int size, Ship[] ships, ILogger logger, IRandomGenerator randomGenerator)
        {
            Size = size;
            Squares = new SquareValues[Size, Size];
            Logger = logger;
            RandomGenerator = randomGenerator;
            InitialiseEmptyBoard();
            Ships = ships;
        }

        //Sets all squares to empty
        private void InitialiseEmptyBoard()
        {
            for (int Row = 0; Row < Size; Row++)
            {
                for (int Column = 0; Column < Size; Column++)
                {
                    Squares[Row, Column] = SquareValues.Empty;
                }
            }
        }
        //Checks, in collaboration with Ships, whether any of them cover
        //the given row, column; if one does, invoke the Hit() method on it.
        public void CheckSquareAndRecordOutcome(int col, int row)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipOccupiesLocation(col, row))
                {
                    ship.Hit(col, row);
                    Squares[row, col] = SquareValues.Hit;
                    if (ship.IsSunk())
                    {
                        Logger.WriteLine(ship.Name + " sunk!");
                    }
                    else
                    {
                        Logger.WriteLine("Hit a " + ship.Name + " at (" + col + "," + row + ").");
                    }
                    if (CheckWin())
                    {
                        Logger.WriteLine("All ships sunk!");
                        Logger.WriteLine();
                    }
                    return;
                }
            }
            Squares[row, col] = SquareValues.Miss;
            Logger.WriteLine("Sorry, (" + col + "," + row + ") is a miss.");
        }

        //Returns true if the given position for the ship fits within the board 
        //and does not clash with another ship
        private bool IsValidPosition(Ship ship, int row, int col, Orientations orientation)
        {
            if (orientation == Orientations.Vertical && row + ship.Size > Size)
            {
                return false;
            }
            else if (orientation == Orientations.Horizontal && col + ship.Size > Size)
            {
                return false;
            }
            else
            {
                if (orientation == Orientations.Vertical)
                {
                    for (int Scan = 0; Scan < ship.Size; Scan++)
                    {
                        if (Squares[row + Scan, col] != SquareValues.Empty)
                        {
                            return false;
                        }
                    }
                }
                else if (orientation == Orientations.Horizontal)
                {
                    for (int Scan = 0; Scan < ship.Size; Scan++)
                    {
                        if (Squares[row, col + Scan] != SquareValues.Empty)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //Returns true if all ships are sunk.
        public bool CheckWin()
        {
          return !Ships.Any(s => !s.IsSunk());
        }

        //Allows the actual array of squares to remain private
        public SquareValues ReadSquare(int row, int col)
        {
            return Squares[row, col];
        }

        //In collaboration with IsValidPosition, finds a random but valid
        //position for each of the ships set up, whether or not they already
        //have a position specified.
        public void RandomiseShipPlacement()
        {
            foreach (var ship in Ships)
            {
                Orientations orientation = 0; //default
                int row = 0;
                int col = 0;
                bool valid = false;
                while (valid == false)
                {
                    row = RandomGenerator.Next(0, Size);
                    col = RandomGenerator.Next(0, Size);
                    orientation = (Orientations)RandomGenerator.Next(0, 2);
                    valid = IsValidPosition(ship, row, col, orientation);
                }
                Logger.WriteLine("Computer placing the " + ship.Name);
                ship.SetPosition(row, col, orientation);
            }
        }
    }
}