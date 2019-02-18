using System;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {



        public static string Roman(int number)
        {
            string result = "";
            if (number == 5)
            {
                result += "V";
                number -= 5;
            }
            if (number == 4)
            {
                result += "IV";
                number -= 4;
            }
            for (int i = 0; i <= number; i++)
            {
                result += "I";
                number -= 1;
            }
            return result;
        }



    }
}
