namespace DrawingCSharp
{
    public interface IShape
    {
        byte[] DrawAsBitMap();
        string Summary();
        void GrowBy(double percent);
    }
}
