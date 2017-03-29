namespace Boom.Model
{
    //Fires nine shots covering the 3x3 grid of squares centred on the given row, column.
    public class Bomb : IWeapon
    {
        private int blastRadius = 1;

        public void Fire(int col, int row, GameBoard Board)
        {
            for (int startCol = col - blastRadius; startCol <= col + blastRadius; startCol++)
            {
                for (int startRow = row - blastRadius; startRow <= row + blastRadius; startRow++)
                {
                    if (startCol >= 0 && startCol < 10 && startRow >= 0 && startRow < 10)
                    {
                        Board.CheckSquareAndRecordOutcome(startCol, startRow);
                    }
                }
            }
        }
    }
}
