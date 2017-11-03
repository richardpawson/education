namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        public static string AsRomanNumeral(int number)
        {
            switch (number)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                default:
                    return "";
            }
        }

        //You can write private functions here and call them from within
        //AsRomanNumeral
    }
}
