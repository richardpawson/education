using Quadrivia.FunctionalLibrary;
using System.Collections.Immutable;
using System.Linq;

namespace FAB.Model
{
    public class MissileFunctions
    {
        public static GameBoard fireMissile(Location loc, GameBoard board)
        {
            return board.checkSquareAndRecordOutcome(loc);
        }

        public static GameBoard fireBomb(Location loc, GameBoard board)
        {
            return board.checkSquaresAndRecordOutcome(GenerateLocationsToHit(loc.Col, loc.Row, board));
        }

        private static FList<Location> GenerateLocationsToHit(int centreCol, int centreRow, GameBoard board)
        {
            return FList.New(Enumerable.Range(centreCol - 1, 3)
                .SelectMany(col => Enumerable.Range(centreRow - 1, 3), 
                (col, row) => new Location(col, row))
                .ToArray());
        }
    }
}


