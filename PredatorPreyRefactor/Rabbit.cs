using System;
using System.Text;

namespace PredatorPrey
{
    public class Rabbit : Animal
    {
        enum Sexes
        {
            Male,
            Female
        }
        private const double DefaultReproductionRate = 1.2;
        private const int DefaultLifespan = 4;
        private const double DefaultProbabilityDeathOtherCauses = 0.05;
        private Sexes Sex;
        public double ReproductionRate { get; private set; }

        public Rabbit(Location loc, int variability, ILogger logger, IRandomGenerator randomGenerator)
            : base(loc, DefaultLifespan, DefaultProbabilityDeathOtherCauses, variability, logger, randomGenerator)
        {
            ReproductionRate = DefaultReproductionRate * CalculateRandomValue(100, variability) / 100;
            DetermineSex();
        }

        public Rabbit(Location loc, int variability, double parentsReproductionRate, ILogger logger, IRandomGenerator randomGenerator)
            : base(loc, DefaultLifespan, DefaultProbabilityDeathOtherCauses, variability, logger, randomGenerator)
        {
            ReproductionRate = parentsReproductionRate * CalculateRandomValue(100, variability) / 100;
            DetermineSex();
        }

        private void DetermineSex()
        {
            if (RandomGenerator.Next(0, 100) < 50)
            {
                Sex = Sexes.Male;
            }
            else
            {
                Sex = Sexes.Female;
            }
        }

        public override string Inspect()
        {
            var sb = new StringBuilder();
            sb.Append(base.Inspect());
            sb.Append("Rep rate " + Math.Round(ReproductionRate, 1) + " ");
            sb.AppendLine("Gender " + Sex + " ");
            return sb.ToString();
        }

        public bool IsFemale()
        {
            return Sex == Sexes.Female;
        }
    }
}