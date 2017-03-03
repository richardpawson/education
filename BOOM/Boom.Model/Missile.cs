namespace Boom.Model
{
    public class Missile : Weapon
    {
        //Returns a list of ships hit
        public override void Fire(int row, int col, GameBoard Board)
        {
            Board.CheckLocation(row, col);
        }
    }
}


