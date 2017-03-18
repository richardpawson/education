namespace Boom.Model
{
    public class Missile
    {
        public static void Fire(int col, int row, GameBoard board)
        {
            GameBoard.CheckSquareAndRecordOutcome(board, col, row);
        }
    }
}


