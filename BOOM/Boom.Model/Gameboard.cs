using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        public int Size { get; private set; }
        private List<Tuple<int, int>> Misses = new List<Tuple<int, int>>();
        private Ship[] Ships;
        private ILogger Logger;
        private IRandomGenerator RandomGenerator;

        public GameBoard(int size, Ship[] ships, ILogger logger, IRandomGenerator randomGenerator)
        {
            Size = size;
            Logger = logger;
            RandomGenerator = randomGenerator;
            Ships = ships;
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
            Misses.Add(Tuple.Create(col, row));
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
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (ship.ShipOccupiesLocation(col+scan, row)) return false;
                    }
                }
                else if (orientation == Orientations.Horizontal)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (ship.ShipOccupiesLocation(col, row+scan)) return false;
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
        public SquareValues ReadSquare(int col, int row)
        {
            if (Ships.Any(s => s.ShipIsHitInLocation(col, row)))
            {
                return SquareValues.Hit;
            }
            else if (Misses.Contains(Tuple.Create(col, row)))
            {
                return SquareValues.Miss;
            }
            else
            {
                return SquareValues.Empty;
            }
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
                    col = RandomGenerator.Next(0, Size);
                    row = RandomGenerator.Next(0, Size);
                    orientation = (Orientations)RandomGenerator.Next(0, 2);
                    valid = IsValidPosition(ship, row, col, orientation);
                }
                Logger.WriteLine("Computer placing the " + ship.Name);
                ship.SetPosition(col, row, orientation);
            }
        }
    }
}