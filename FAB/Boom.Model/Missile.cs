namespace Boom.Model
{
    public class Missile
    {
        public static GameBoard Fire(Location loc, GameBoard board)
        {
            return board.CheckSquareAndRecordOutcome(loc);
        }
    }
}


