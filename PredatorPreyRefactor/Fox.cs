using System.Text;

namespace PredatorPrey
{
    public class Fox : Animal
    {
        private int FoodUnitsNeeded = 10;
        private int FoodUnitsConsumedThisPeriod = 0;
        private const int DefaultLifespan = 7;
        private const double DefaultProbabilityDeathOtherCauses = 0.1;

        public Fox(Location loc, int variability, ILogger logger, IRandomGenerator randomGenerator)
            : base(loc, DefaultLifespan, DefaultProbabilityDeathOtherCauses, variability, logger, randomGenerator)
        {
            FoodUnitsNeeded = (int)(10 * base.CalculateRandomValue(100, variability) / 100);
        }

        public void AdvanceGeneration()
        {
            if (FoodUnitsConsumedThisPeriod == 0)
            {
                IsAlive = false;
                Logger.WriteLine("  Fox dies as has eaten no food this period.");
            }
            else
            {
                if (CheckIfKilledByOtherFactor())
                {
                    IsAlive = false;
                    Logger.WriteLine("  Fox killed by other factor.");
                }
                else
                {
                    if (FoodUnitsConsumedThisPeriod < FoodUnitsNeeded)
                    {
                        CalculateNewAge();
                        Logger.WriteLine("  Fox ages further due to lack of food.");
                    }
                    CalculateNewAge();
                    if (!IsAlive)
                    {
                        Logger.WriteLine("  Fox has died of old age.");
                    }
                }
            }
        }

        public void ResetFoodConsumed()
        {
            FoodUnitsConsumedThisPeriod = 0;
        }

        public bool ReproduceThisPeriod()
        {
            const double ReproductionProbability = 0.25;
            if (RandomGenerator.Next(0, 100) < ReproductionProbability * 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GiveFood(int foodUnits)
        {
            FoodUnitsConsumedThisPeriod = FoodUnitsConsumedThisPeriod + foodUnits;
        }

        public override string Inspect()
        {
            var sb = new StringBuilder();
            sb.Append(base.Inspect());
            sb.Append("Food needed " + FoodUnitsNeeded + " ");
            sb.Append("Food eaten " + FoodUnitsConsumedThisPeriod + " ");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}