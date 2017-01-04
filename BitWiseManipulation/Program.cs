using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitWiseManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter integer (0 to exit): ");
                var input = Convert.ToInt32( Console.ReadLine());
                if (input == 0) break;
                var binary = Convert.ToString(input, 2);
                Console.WriteLine(string.Format("Input  binary: {0}", binary));
                //Console.WriteLine("Enter digits to shift right (- for left): ");
                //var shift = Convert.ToInt32(Console.ReadLine());
                //int shifted;
                //if (shift > 0)
                //{
                //    shifted = input >> shift;
                //} else
                //{
                //    shifted = input << shift;
                //}
                var output = Convert.ToString(~input);
                //Console.WriteLine(string.Format("Output binary: {0}", binary));
                //var integer = Convert.ToInt32(binary, 2);
                Console.WriteLine(string.Format("Not integer: {0}", output));
            }
        }


        static void AND()
        {
            // If the mask value is 1, and the value is 1, it sets it to 1
            // If the mask value is 1, and the value is 0, it keeps that 0
            // If the mask value is 0, the value is set to 0 regardless
            // 42   = 0010 1010
            // 36   = 0010 0100
            //
            // val  = 0010 0000 = 32
            int val = 42 & 36;
            //WL("{0}", val);
        }
        static void OR()
        {
            // If the mask value is 0, the original is returned
            // If the mask value is 1, 1 is returned (i.e. true || false == true)
            // 42   = 0010 1010
            // 36   = 0010 0100
            //
            // val  = 0010 1110 = 46
            int val = 42 | 36;
            //WL("{0}", val);
        }

        static void NOT()
        {
            // 42   = 0000 0000 0010 1010
            //
            // Result:
            // -43  = 1111 1111 1101 0101
            //
            // Inverts the bits of 42, see the other article
            // of how this works with 2s complement (you basically
            // invert the bits and add 1)
            int val = 42;
            val = ~42;
            //WL("{0}", val);
        }

        static void XOR()
        {
            // Sets the bit only if 1 of the values is true, not both
            // 42   = 0010 1010
            // 36   = 0010 0100
            //
            // val  = 0000 1110 = 14
            int val = 42 ^ 36;
            //WL("{0}", val);
        }

        static void OREQUALS()
        {
            // Shorthand or alternative syntax for the OR mask,
            // saves doing "val = val | 36".
            int val = 42;
            val |= 36;
            //WL("{0}", val);
        }

        static void SHIFTLEFT()
        {
            // 42   = 0010 1010
            // << 2 = 1010 1000 = 168
            int val = 42;
            val = val << 2;
           // WL("{0}", val);

            // Pushing beyond 8 bits
            // 42   = 0000 0000 0010 1010
            // << 4 = 0000 0010 1010 0000 = 672 (512 + 128 + 32)
            val = 42;
            val = val << 4;
            //WL("{0}", val);
        }

        static void SHIFTRIGHT()
        {
            // 42   = 0010 1010
            // >> 2 = 0000 1010 = 10)
            int val = 42;
            val = val >> 2;
           // WL("{0}", val);

            //  42   = 0010 1010
            // inverted using 1s complement
            //  -42  = 1101 0101
            //  -42  = 1101 0110 (2s complement: add 1)
            //  105  = 0110 1001
            // -105  = 1001 0111
            //  120,000 = 0000 0000 0000 0001 1101 0100 1100 0000
            // -120,000 = 1111 1111 1111 1110 0010 1011 0011 1111 (1s)
            //            1111 1111 1111 1110 0010 1011 0100 0000 (2s - added 1)
            // 42      = 0010 1010
            // -42     = 1101 0110
            // -42 >>2 = 0011 0101
            // -42 >>2 = 1111 0101 (it pads the zeros to the left with 1s)
            val = -42;
            val = val >> 2;
            //WL("{0}", val);
        }


        static void NEGATIVESHIFT()
        {
            // Using 256 as 42 doesn't have enough bits (it right shifts to 0)
            //
            // 256   = 0000 0001 0000 0000
            // -6    = 0000 0000 1111 1010 With shifting, this is promoted to an int, using the last 5 bits
            //       = 0000 0000 0001 1010 (2 + 8 + 16 = 26)
            //       = 0000 0000 0000 0000 (Zero as its shifting 26 bits to the right)
            int val = 256 >> -6;
            //WL("{0}", val);
        }

    }
}
