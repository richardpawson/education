using System;

namespace CSharpApp
{
    public static class Conversions
    {
       public  static decimal ToCelcius(decimal f) 
        {
            return Math.Round((f - 32) * 5 / 9, 1);
        }
    }
}
