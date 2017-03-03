namespace Boom.Model
{
    public abstract class Weapon
    {
        public abstract void Fire(int row, int col, GameBoard Board);
    }
}