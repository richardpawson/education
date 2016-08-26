namespace CSharpFractions
{
    public class Fraction
    {

        int num;
        int den;

        public Fraction(int numerator, int denominator)
        {

            num = numerator;

            den = denominator;

            reduce();
        }

        public override string ToString()
        {
            return num + "/" + den;
        }

        public Fraction plus(Fraction other)
        {
            if (den == other.den)
            {
                return new Fraction(num + other.num, den);
            }
            else { }
            return new Fraction(num * other.den + other.num * den, den * other.den);
        }
        public Fraction minus(Fraction other)
        {
            if (den == other.den)
            {
                return new Fraction(num - other.num, den);
            }
            else
            {
                return new Fraction(num * other.den - other.num * den, den * other.den);
            }
        }

        public Fraction multiplyBy(Fraction other)
        {
            return new Fraction(num * other.num, den * other.den);
        }

        public Fraction divideBy(Fraction other)
        {
            return multiplyBy(new Fraction(other.den, other.num));
        }

        private void reduce()
        {
            var gcd = greatestCommonDivisor(num, den);
            num = (int)num / gcd;
            den = (int)den / gcd;
        }

        private int greatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : greatestCommonDivisor(b, a % b);
        }
    }
}
