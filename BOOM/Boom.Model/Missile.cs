namespace Boom.Model
{
    public class Missile : IWeapon
    {
        public void Fire(int row, int col, GameBoard Board)
        {
            Board.CheckLocation(row, col);
        }
    }
}


