namespace Boom.Model
{
    public interface IWeapon
    {
         void Fire(int col, int row, GameBoard Board);
    }
}