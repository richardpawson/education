using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServices
{
    public static class RandomNumbers
    { 
        public static Tuple<int, Random> Next(Random generator, int minValue, int maxValue)
        {
            var clone = Clone(generator);
            var result = clone.Next(minValue, maxValue);
            return Tuple.Create(result, clone);
        }

        //Acknowledgement
        //http://stackoverflow.com/questions/17420424/determine-the-seed-of-c-sharp-random-instance 
       public static Random Clone(this Random source)
        {
            var clone = new Random();
            var type = typeof(Random);
            var field = type.GetField("inext",
                BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(clone, field.GetValue(source));
            field = type.GetField("inextp",
                BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(clone, field.GetValue(source));
            field = type.GetField("SeedArray",
                BindingFlags.Instance | BindingFlags.NonPublic);
            int[] arr = (int[])field.GetValue(source);
            field.SetValue(clone, arr.Clone());
            return clone;
        }
    }
}

