namespace Boom.Model
{
    public class Missile
    {
        public static GameBoard Fire(int col, int row, GameBoard board)
        {
            return GameBoard.CheckSquareAndRecordOutcome(board, col, row);
        }
    }
}


