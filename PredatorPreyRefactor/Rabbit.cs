using System;
using System.Text;

namespace PredatorPrey
{
    class Rabbit : Animal
    {
        enum Genders
        {
            Male,
            Female
        }
        private double ReproductionRate;
        private const double DefaultReproductionRate = 1.2;
        private const int DefaultLifespan = 4;
        private const double DefaultProbabilityDeathOtherCauses = 0.05;
        private Genders Gender;

        public Rabbit(int Variability)
            : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
        {
            ReproductionRate = DefaultReproductionRate * CalculateRandomValue(100, Variability) / 100;
            if (Rnd.Next(0, 100) < 50)
            {
                Gender = Genders.Male;
            }
            else
            {
                Gender = Genders.Female;
            }
        }

        public Rabbit(int Variability, double ParentsReproductionRate)
            : base(DefaultLifespan, DefaultProbabilityDeathOtherCauses, Variability)
        {
            ReproductionRate = ParentsReproductionRate * CalculateRandomValue(100, Variability) / 100;
            if (Rnd.Next(0, 100) < 50)
            {
                Gender = Genders.Male;
            }
            else
            {
                Gender = Genders.Female;
            }
        }

        public override string Inspect()
        {
            var sb = new StringBuilder();
            sb.Append(base.Inspect());
            sb.Append("Rep rate " + Math.Round(ReproductionRate, 1) + " ");
            sb.AppendLine("Gender " + Gender + " ");
            return sb.ToString();
        }

        public bool IsFemale()
        {
            if (Gender == Genders.Female)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetReproductionRate()
        {
            return ReproductionRate;
        }
    }
}
