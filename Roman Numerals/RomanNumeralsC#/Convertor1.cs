using System.Collections.Generic;
using System.Text;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {


        public static string Roman(int d)
        {
            string result = "";
            while (d >= 1000)
            {
                d -= 1000;
                result += "M";
            }
            while (d >= 900)
            {
                d -= 900;
                result += "CM";
            }
            while (d >= 500)
            {
                d -= 500;
                result += "D";
            }
            while (d >= 400)
            {
                d -= 400;
                result += "CD";
            }
            while (d >= 100)
            {
                d -= 100;
                result += "C";
            }
            while (d >= 90)
            {
                d -= 90;
                result += "XC";
            }
            while (d >= 50)
            {
                d -= 50;
                result += "L";
            }
            while (d >= 40)
            {
                d -= 40;
                result += "XL";
            }
            while (d >= 10)
            {
                d -= 10;
                result += "X";
            }
            while (d >= 9)
            {
                d -= 9;
                result += "IX";
            }
            while (d >= 5)
            {
                d -= 5;
                result += "V";
            }
            while (d >= 4)
            {
                d -= 4;
                result += "IV";
            }
            while (d >= 1)
            {
                d -= 1;
                result += "I";
            }
            return result;
        }
    }
}
