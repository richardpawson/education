using System;

namespace TechnicalServices
{
    //Implementation of IRandomGenerator that uses the System.Random functionality
    //to produce random numbers.
    public class SystemRandomGenerator : IRandomGenerator
    {
        private static Random Random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}
