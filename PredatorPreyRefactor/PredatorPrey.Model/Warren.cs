using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalServices;

namespace PredatorPrey.Model
{
    public class Warren
    {
        private const int MaxRabbitsInWarren = 99;
        private List<Rabbit> Rabbits = new List<Rabbit>();
        private int PeriodsRun = 0;
        private bool AlreadySpread = false;
        private int Variability;
        private IRandomGenerator RandomGenerator;
        private ILogger Logger;
        public Location Location { get; private set; }

        public Warren(Location loc, int variability, ILogger logger, IRandomGenerator randomGenerator, int? rabbitCount = null)
        {
            RandomGenerator = randomGenerator;
            Location = loc;
            Variability = variability;
            Logger = logger;
            if (rabbitCount == null)
            {
                rabbitCount = (int)(CalculateRandomValue(MaxRabbitsInWarren / 4, this.Variability));
            }
            for (int r = 0; r < rabbitCount; r++)
            {
                Rabbits.Add(new Rabbit(loc, variability, logger, randomGenerator));
            }
        }

        public int RabbitCount
        {
            get { return Rabbits.Count; }
        }

        private double CalculateRandomValue(int baseValue, int variability)
        {
            return baseValue - (baseValue * variability / 100) + (baseValue * RandomGenerator.Next(0, (variability * 2) + 1) / 100);
        }

        public bool NeedToCreateNewWarren()
        {
            if ((RabbitCount == MaxRabbitsInWarren) && (!AlreadySpread))
            {
                AlreadySpread = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdvanceGeneration()
        {
            PeriodsRun++;
            if (RabbitCount > 0)
            {
                KillByOtherFactors();
            }
            if (RabbitCount > 0)
            {
                AgeRabbits();
            }
            if ((RabbitCount > 0) && (RabbitCount <= MaxRabbitsInWarren) && ContainsMales())
            {
                MateRabbits();
            }
            if (RabbitCount == 0)
            {
                Logger.WriteLine("  All rabbits in warren are dead");
            }
        }

        public int EatRabbits(int rabbitsToEat)
        {
            int DeathCount = 0;
            if (rabbitsToEat > RabbitCount)
            {
                rabbitsToEat = RabbitCount;
            }
            while (DeathCount < rabbitsToEat)
            {
                Rabbits.Remove(GetRandomRabbit());
                DeathCount++;
            }
            return rabbitsToEat;
        }

        private void KillByOtherFactors()
        {
            int DeathCount = 0;
            foreach (Rabbit rabbit in Rabbits.ToArray())
            {
                if (rabbit.CheckIfKilledByOtherFactor())
                {
                    Rabbits.Remove(rabbit);
                    DeathCount++;
                }
            }
            Logger.WriteLine("  " + DeathCount + " rabbits killed by other factors.");
        }

        private void AgeRabbits()
        {
            int DeathCount = 0;
            foreach (Rabbit rabbit in Rabbits.ToArray())
            {
                rabbit.CalculateNewAge();
                if (rabbit.IsDead())
                {
                    Rabbits.Remove(rabbit);
                    DeathCount++;
                }
            }
            Logger.WriteLine("  " + DeathCount + " rabbits die of old age.");
        }

        private void MateRabbits()
        {
            int babies = 0;
            double combinedReproductionRate;
            foreach (Rabbit female in Rabbits.Where(r => r.IsFemale()).ToArray())
            {
                if ((RabbitCount + babies) < MaxRabbitsInWarren)
                {
                    var male = GetRandomMale();
                    combinedReproductionRate = (female.ReproductionRate + male.ReproductionRate) / 2;
                    if (combinedReproductionRate >= 1)
                    {
                        Rabbits.Add(new Rabbit(Location, Variability, combinedReproductionRate, Logger, RandomGenerator));
                        babies++;
                    }
                }
            }
            Logger.WriteLine("  " + babies + " baby rabbits born.");
        }

        private Rabbit GetRandomRabbit()
        {
            return Rabbits[RandomGenerator.Next(0, RabbitCount)];
        }

        private Rabbit GetRandomMale()
        {
            var males = Rabbits.Where(r => !r.IsFemale()).ToArray();
            return males[RandomGenerator.Next(0, males.Count())];
        }

        private bool ContainsMales()
        {
            return Rabbits.Any(r => !r.IsFemale());
        }

        public string Inspect()
        {
            return "Periods Run " + PeriodsRun + " Size " + RabbitCount + "\n";
        }

        public string InspectAllRabbits()
        {
            var sb = new StringBuilder();
            foreach (Rabbit r in Rabbits)
            {
                sb.Append(r.Inspect());
            }
            return sb.ToString();
        }
    }
}