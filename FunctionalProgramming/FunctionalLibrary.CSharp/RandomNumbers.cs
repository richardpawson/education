using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalLibrary
{
    public class RandomResult
    {
        public readonly int Number;
        internal readonly uint U;
        internal readonly uint V;
        public RandomResult(int result, uint u, uint v)
        {
            Number = result;
            U = u;
            V = v;
        }

        //Create Random initialied with an explicit seed
        public RandomResult(uint u)
        {
            U = u;
            V = 0;
        }

        //Create Random initialied with the system clock
        public RandomResult()
        {
            U = (uint)DateTime.Now.Ticks >> 16;
            V = 0;
        }
    }
    public static class RandomGeneration
    { 
        public static RandomResult Next(this RandomResult result, int minValue, int maxValue)
        {
            var u = result.U;
            var v = result.V;
            uint u2 = 36969 * (u & 65535) + (u >> 16);
            uint v2 = 18000 * (v & 65535) + (v >> 16);
            double r1 = ((u2 << 16) + v2 + 1.0) * 2.328306435454494e-10;
            int r2 = (int) (minValue + r1 * (maxValue - minValue));
            return new RandomResult(r2, u2, v2);
        }


    }
}

