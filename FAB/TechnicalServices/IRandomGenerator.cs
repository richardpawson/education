namespace TechnicalServices
{
    public interface IRandomGenerator
    {
        //Generates next random number within specified range. Note that
        //minValue is inclusive; maxValue is exclusive.
        int Next(int minValue, int maxValue);
    }
}
