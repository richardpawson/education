using System;

namespace PredatorPrey
{
    class SystemRandomGenerator : IRandomGenerator
    {
        private static Random Random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}
