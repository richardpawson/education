namespace Boom.Model
{
    public class Missile
    {
        public static GameBoard Fire(int col, int row, GameBoard board)
        {
            return board.CheckSquareAndRecordOutcome(col, row);
        }
    }
}


