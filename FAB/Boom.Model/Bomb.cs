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
            const int blastRadius = 1;
            var locs = GenerateLocationsToHit(loc.Col, loc.Row, blastRadius, board);
            return board.CheckSquaresAndRecordOutcome(locs);
        }

        private static ImmutableArray<Location> GenerateLocationsToHit(int centreCol, int centreRow, int blastRadius, GameBoard board)
        {
            var diam = 1+ blastRadius * 2;
            var colRange = Enumerable.Range(centreCol - blastRadius, diam);
            var rowRange = Enumerable.Range(centreRow - blastRadius, diam);
            var locations = colRange.SelectMany(col => rowRange, (col, row) => new Location(col, row));
            return ImmutableArray.CreateRange(locations);
        }
     }
}
