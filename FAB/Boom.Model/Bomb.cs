using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Boom.Model
{
    //Fires nine shots covering the 3x3 grid of squares centred on the given row, column.
    public class Bomb
    {
        private static int blastRadius = 1;

        public static GameBoard Fire(Location loc, GameBoard board)
        {
            //TODO: This needs refactoring to make it functional i.e. generate a list of hit locations first
            var messages = new StringBuilder();
            for (int startCol = loc.Col - blastRadius; startCol <= loc.Col + blastRadius; startCol++)
            {
                for (int startRow = loc.Row - blastRadius; startRow <= loc.Row + blastRadius; startRow++)
                {
                    {
                        if (startCol >= 0 && startCol < 10 && startRow >= 0 && startRow < 10)
                        {
                            //TODO: more refactoring needed
                            var startLoc = new Location(startCol, startRow);
                            board =  board.CheckSquareAndRecordOutcome(startLoc);
                            messages.Append(board.Messages);
                        }
                    }
                }
            }
            return new GameBoard(board.Size, board.Ships, messages.ToString(), board.Misses);
        }

        //public static GameBoard Fire(int col, int row, GameBoard board)
        //{
        //    var locs = GenerateLocationsToHit(col, row, board);
        //    var messages = locs.Select(loc =>
        //       GameBoard.CheckSquareAndRecordOutcome(board, loc.Item1, loc.Item2).Messages).
        //       Aggregate((a, b) => a + b);
        //     )
        //     return new GameBoard(board.Size, board.Ships, messages.ToString(), board.RandomGenerator, board.Misses);

        //}

        //private static ImmutableArray<Location> GenerateLocationsToHit(int row, int col, GameBoard board)
        //{
        //    return ImmutableArray<Location>.Empty;
        //}
    }
}
