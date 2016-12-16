using System;
using System.Text;

namespace PredatorPrey
{
    class Warren
    {
        private const int MaxRabbitsInWarren = 99;
        private Rabbit[] Rabbits;
        private int RabbitCount = 0;
        private int PeriodsRun = 0;
        private bool AlreadySpread = false;
        private int Variability;
        protected IRandomGenerator Rnd;
        private ILogger Logger;

        public Warren(int Variability, ILogger Logger, IRandomGenerator Rnd) 
        {
            this.Rnd = Rnd;
            var rabbitCount = (int)(CalculateRandomValue(MaxRabbitsInWarren / 4, this.Variability));
            CommonSetUp(Variability, rabbitCount, Logger);
        }

        public Warren(int Variability, int rabbitCount, ILogger Logger, IRandomGenerator Rnd) 
        {
            this.Rnd = Rnd;
            CommonSetUp(Variability, rabbitCount, Logger);
        }

        private void CommonSetUp(int Variability, int rabbitCount, ILogger Logger)
        {
            this.Variability = Variability;
            this.Logger = Logger;
            this.RabbitCount = rabbitCount;
            Rabbits = new Rabbit[MaxRabbitsInWarren];
            for (int r = 0; r < RabbitCount; r++)
            {
                Rabbits[r] = new Rabbit(Variability, Logger, Rnd);
            }
        }

        private double CalculateRandomValue(int BaseValue, int Variability)
        {
            return BaseValue - (BaseValue * Variability / 100) + (BaseValue * Rnd.Next(0, (Variability * 2) + 1) / 100);
        }

        public int GetRabbitCount()
        {
            return RabbitCount;
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

        public bool WarrenHasDiedOut()
        {
            if (RabbitCount == 0)
            {
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
            if ((RabbitCount > 0) && (RabbitCount <= MaxRabbitsInWarren))
            {
                if (ContainsMales())
                {
                    MateRabbits();
                }
            }
            if (RabbitCount == 0)
            {
                Logger.WriteLine("  All rabbits in warren are dead");
            }
        }

        public int EatRabbits(int RabbitsToEat)
        {
            int DeathCount = 0;
            int RabbitNumber;
            if (RabbitsToEat > RabbitCount)
            {
                RabbitsToEat = RabbitCount;
            }
            while (DeathCount < RabbitsToEat)
            {
                RabbitNumber = Rnd.Next(0, RabbitCount);
                if (Rabbits[RabbitNumber] != null)
                {
                    Rabbits[RabbitNumber] = null;
                    DeathCount++;
                }
            }
            CompressRabbitList(DeathCount);
            return RabbitsToEat;
        }

        private void KillByOtherFactors()
        {
            int DeathCount = 0;
            for (int r = 0; r < RabbitCount; r++)
            {
                if (Rabbits[r].CheckIfKilledByOtherFactor())
                {
                    Rabbits[r] = null;
                    DeathCount++;
                }
            }
            CompressRabbitList(DeathCount);
                Logger.WriteLine("  " + DeathCount + " rabbits killed by other factors.");
        }

        private void AgeRabbits()
        {
            int DeathCount = 0;
            for (int r = 0; r < RabbitCount; r++)
            {
                Rabbits[r].CalculateNewAge();
                if (Rabbits[r].CheckIfDead())
                {
                    Rabbits[r] = null;
                    DeathCount++;
                }
            }
            CompressRabbitList(DeathCount);
                Logger.WriteLine("  " + DeathCount + " rabbits die of old age.");
        }

        private void MateRabbits()
        {
            int Mate = 0;
            int Babies = 0;
            double CombinedReproductionRate;
            for (int r = 0; r < RabbitCount; r++)
            {
                if ((Rabbits[r].IsFemale()) && (RabbitCount + Babies < MaxRabbitsInWarren))
                {
                    do
                    {
                        Mate = Rnd.Next(0, RabbitCount);
                    } while ((Mate == r) || (Rabbits[Mate].IsFemale()));
                    CombinedReproductionRate = (Rabbits[r].GetReproductionRate() + Rabbits[Mate].GetReproductionRate()) / 2;
                    if (CombinedReproductionRate >= 1)
                    {
                        Rabbits[RabbitCount + Babies] = new Rabbit(Variability, CombinedReproductionRate, Logger, Rnd);
                        Babies++;
                    }
                }
            }
            RabbitCount = RabbitCount + Babies;
                Logger.WriteLine("  " + Babies + " baby rabbits born.");
        }

        private void CompressRabbitList(int DeathCount)
        {
            if (DeathCount > 0)
            {
                int ShiftTo = 0;
                int ShiftFrom = 0;
                while (ShiftTo < RabbitCount - DeathCount)
                {
                    while (Rabbits[ShiftFrom] == null)
                    {
                        ShiftFrom++;
                    }
                    if (ShiftTo != ShiftFrom)
                    {
                        Rabbits[ShiftTo] = Rabbits[ShiftFrom];
                    }
                    ShiftTo++;
                    ShiftFrom++;
                }
                RabbitCount = RabbitCount - DeathCount;
            }
        }

        private bool ContainsMales()
        {
            bool Males = false;
            for (int r = 0; r < RabbitCount; r++)
            {
                if (!Rabbits[r].IsFemale())
                {
                    Males = true;
                }
            }
            return Males;
        }

        public string Inspect()
        {
           return "Periods Run " + PeriodsRun + " Size " + RabbitCount + "\n";
        }

        public string InspectAllRabbits()
        {
            var sb = new StringBuilder();
            if (RabbitCount > 0)
            {
                for (int r = 0; r < RabbitCount; r++)
                {
                    sb.Append(Rabbits[r].Inspect());
                }
            }
            return sb.ToString();
        }
    }

}
