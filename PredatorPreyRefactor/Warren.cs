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
        private static Random Rnd = new Random();

        public Warren(int Variability)
        {
            this.Variability = Variability;
            Rabbits = new Rabbit[MaxRabbitsInWarren];
            RabbitCount = (int)(CalculateRandomValue((int)(MaxRabbitsInWarren / 4), this.Variability));
            for (int r = 0; r < RabbitCount; r++)
            {
                Rabbits[r] = new Rabbit(Variability);
            }
        }

        public Warren(int Variability, int rabbitCount)
        {
            this.Variability = Variability;
            this.RabbitCount = rabbitCount;
            Rabbits = new Rabbit[MaxRabbitsInWarren];
            for (int r = 0; r < RabbitCount; r++)
            {
                Rabbits[r] = new Rabbit(Variability);
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

        public void AdvanceGeneration(bool ShowDetail)
        {
            PeriodsRun++;
            if (RabbitCount > 0)
            {
                KillByOtherFactors(ShowDetail);
            }
            if (RabbitCount > 0)
            {
                AgeRabbits(ShowDetail);
            }
            if ((RabbitCount > 0) && (RabbitCount <= MaxRabbitsInWarren))
            {
                if (ContainsMales())
                {
                    MateRabbits(ShowDetail);
                }
            }
            if ((RabbitCount == 0) && (ShowDetail))
            {
                Console.WriteLine("  All rabbits in warren are dead");
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

        private void KillByOtherFactors(bool ShowDetail)
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
            if (ShowDetail)
            {
                Console.WriteLine("  " + DeathCount + " rabbits killed by other factors.");
            }
        }

        private void AgeRabbits(bool ShowDetail)
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
            if (ShowDetail)
            {
                Console.WriteLine("  " + DeathCount + " rabbits die of old age.");
            }
        }

        private void MateRabbits(bool ShowDetail)
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
                        Rabbits[RabbitCount + Babies] = new Rabbit(Variability, CombinedReproductionRate);
                        Babies++;
                    }
                }
            }
            RabbitCount = RabbitCount + Babies;
            if (ShowDetail)
            {
                Console.WriteLine("  " + Babies + " baby rabbits born.");
            }
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
