using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Boom.Model
{
    //Fires nine shots covering the 3x3 grid of squares centred on the given row, column.
    public class Bomb
    {
        public static GameBoard Fire(Location loc, GameBoard board)
        {
            var locs = GenerateLocationsToHit(loc.Col, loc.Row, board);
            return board.CheckSquaresAndRecordOutcome(locs);
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
