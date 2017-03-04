using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        private char[,] Squares;
        private Ship[] Ships;
        public const char Empty = ' ';
        public const char Hit = 'h';
        public const char Miss = 'm';
        private ILogger Logger;
        private IRandomGenerator RandomGenerator;
        public int Size { get; private set; }

        public GameBoard(int size, Ship[] ships, ILogger logger, IRandomGenerator randomGenerator)
        {
            Size = size;
            Squares = new char[Size, Size];
            Logger = logger;
            RandomGenerator = randomGenerator;
            InitialiseEmptyBoard();
            Ships = ships;
        }

        private void InitialiseEmptyBoard()
        {
            for (int Row = 0; Row < Size; Row++)
            {
                for (int Column = 0; Column < Size; Column++)
                {
                    Squares[Row, Column] = Empty;
                }
            }
        }

        //Returns a list of ships hit if any
        public void CheckLocation(int row, int col)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipOccupiesLocation(row, col))
                {
                    ship.Hit();
                    Squares[row, col] = Hit;
                    if (ship.IsSunk())
                    {
                        Logger.WriteLine(ship.Name + " sunk !");
                    }
                    else
                    {
                        Logger.WriteLine("Hit a " + ship.Name + " at (" + col + "," + row + ").");
                    }
                    return;
                }
            }
            Squares[row, col] = Miss;
            Logger.WriteLine("Sorry, (" + row + "," + col + ") is a miss.");
        }

        private bool ValidateBoatPosition(Ship ship, int row, int col, Orientations orientation)
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
                    if (Squares[row + Scan, col] != Empty)
                    {
                        return false;
                    }
                }
            }
            else if (orientation == Orientations.Horizontal)
            {
                for (int Scan = 0; Scan < ship.Size; Scan++)
                {
                    if (Squares[row, col + Scan] != '-')
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool CheckWin()
    {
        return Ships.Count(s => !s.IsSunk()) == 0;
    }

    public char ReadSquare(int row, int col)
    {
        return Squares[row, col];
    }

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
                valid = ValidateBoatPosition(ship, row, col, orientation);
            }
            Logger.WriteLine("Computer placing the " + ship.Name);
            ship.SetPosition(row, col, orientation);
        }
    }
}
}