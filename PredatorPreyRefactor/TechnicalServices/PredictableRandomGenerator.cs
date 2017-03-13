using System;

namespace TechnicalServices
{
    //This is a 'mock' implementation of IRandomGenerator, for use
    //in testing, when predictable results are needed.  You can call SetNextValues,
    //passing in as many values as needed (before the next time they are set).
    public class PredictableRandomGenerator : IRandomGenerator
    {
        private int counter = 0;
        private int[] values = null;
        public int Next(int minValue, int maxValue)
        {
            if (counter >= values.Length)
            {
                throw new Exception("Insufficient values set");
            }
            int value = values[counter];
            if (value < minValue || value >= maxValue)
            {
                throw new Exception("Value provided (" + value + ") is not within specified range");
            }
            counter++;
            return value;
        }

        public void SetNextValues(params int[] values)
        {
            counter = 0;
            this.values = values;
        }
    }
}

