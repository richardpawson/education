namespace Boom.Model
{
    public interface IWeapon
    {
         void Fire(int row, int col, GameBoard Board);
    }
}