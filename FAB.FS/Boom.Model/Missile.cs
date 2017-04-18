using System.Collections.Immutable;
using System.Linq;
using FAB;

namespace FAB
{
    public class Missile
    {
        public static GameBoard fireMissile(Location loc, GameBoard board)
        {
            return board.checkSquareAndRecordOutcome(loc);
        }

        public static GameBoard fireBomb(Location loc, GameBoard board)
        {
            var locs = GenerateLocationsToHit(loc.Col, loc.Row, board);
            return board.checkSquaresAndRecordOutcome(locs);
        }

        private static ImmutableArray<Location> GenerateLocationsToHit(int centreCol, int centreRow, GameBoard board)
        {
            var colRange = Enumerable.Range(centreCol - 1, 3);
            var rowRange = Enumerable.Range(centreRow - 1, 3);
            var locations = colRange.SelectMany(col => rowRange, (col, row) => new Location(col, row));
            return ImmutableArray.CreateRange(locations);
        }
    }
}


