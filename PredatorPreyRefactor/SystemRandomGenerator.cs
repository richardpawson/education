using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredatorPrey
{
    class SystemRandomGenerator : IRandomGenerator
    {
        private static Random Rnd = new Random();

        public int Next(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}
