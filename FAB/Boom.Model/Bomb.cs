using System.Text;

namespace Boom.Model
{
    //Fires nine shots covering the 3x3 grid of squares centred on the given row, column.
    public class Bomb
    {
        private static int blastRadius = 1;

        public static GameBoard Fire(int col, int row, GameBoard board)
        {
            var messages = new StringBuilder();
            for (int startCol = col - blastRadius; startCol <= col + blastRadius; startCol++)
            {
                for (int startRow = row - blastRadius; startRow <= row + blastRadius; startRow++)
                {
                    {
                        if (startCol >= 0 && startCol < 10 && startRow >= 0 && startRow < 10)
                        {
                            board =  GameBoard.CheckSquareAndRecordOutcome(board, startCol, startRow);
                            messages.Append(board.Messages);
                        }
                    }
                }
            }
            return new GameBoard(board.Size, board.Ships, messages.ToString(), board.RandomGenerator, board.Misses);
        }
    }
}
