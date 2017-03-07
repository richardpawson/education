namespace Boom.Model
{
    public class Missile : IWeapon
    {
        public void Fire(int col, int row, GameBoard Board)
        {
            Board.CheckSquareAndRecordOutcome(col, row);
        }
    }
}


