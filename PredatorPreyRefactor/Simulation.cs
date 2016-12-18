using System;
using System.Collections.Generic;
using System.Linq;

namespace PredatorPrey
{
    public class Simulation
    {
        private int Variability;
        private ILogger Logger;
        private IRandomGenerator RandomGenerator;
        private List<Fox> Foxes = new List<Fox>();
        private List<Warren> Warrens = new List<Warren>();
        public int TimePeriod { get; private set; }
        public Landscape Landscape { get; private set; }

        public Simulation(SetUp setUp, ILogger logger, IRandomGenerator randomGenerator)
        {
            Logger = logger;
            this.RandomGenerator = randomGenerator;
            this.Variability = setUp.Variability;
            Landscape = setUp.Landscape;
            Warrens.AddRange(setUp.Warrens);
            Foxes.AddRange(setUp.Foxes);
        }

        private void CreateRandomWarren()
        {
            Location loc;
            do
            {
                loc = Landscape.RandomLocation();
            } while (GetWarren(loc) != null);
            var warren = new Warren(loc, Variability, Logger, RandomGenerator);
            Warrens.Add(warren);
            Logger.WriteLine("New Warren at (" + loc.X + "," + loc.Y + ")");
        }

        private void CreateRandomFox()
        {
            Location loc;
            do
            {
                loc = Landscape.RandomLocation();
            } while (GetFox(loc) != null);
            var fox = new Fox(loc, Variability, Logger, RandomGenerator);
            Foxes.Add(fox);
            Logger.WriteLine("  New Fox at (" + loc.X + "," + loc.Y + ")");
        }


        public Fox GetFox(Location loc)
        {
            return Foxes.FirstOrDefault(f => f.Location == loc);
        }

        public Warren GetWarren(Location loc)
        {
            return Warrens.FirstOrDefault(w => w.Location == loc);
        }

        public bool HasLife()
        {
            return Warrens.Count > 0 || Foxes.Count > 0;
        }


        public void AdvanceTimePeriod()
        {
            TimePeriod++;
            Logger.WriteLine();
            ProcessWarrens();
            ProcessFoxes();
            Logger.PageBreak();
            Logger.WriteLine();
        }

        private void ProcessWarrens()
        {
            foreach (Warren warren in Warrens.ToArray()) //ToArray is to make copy so as not to modify the collection being looped over
            {
                var loc = warren.Location;
                Logger.WriteLine("Warren at (" + loc.X + "," + loc.Y + "):");
                Logger.Write("  Period Start: ");
                Logger.Write(warren.Inspect());
                if (Foxes.Count > 0)
                {
                    FoxesEatRabbitsInWarren(warren);
                }
                if (warren.NeedToCreateNewWarren())
                {
                    CreateRandomWarren();
                }
                warren.AdvanceGeneration();
                Logger.Write("  Period End: ");
                Logger.Write(warren.Inspect());
                Logger.PageBreak();
                if (warren.RabbitCount == 0)
                {
                    Warrens.Remove(warren);
                }
            }
        }

        private void ProcessFoxes()
        {
            int NewFoxCount = 0;
            foreach (Fox fox in Foxes.ToArray())
            {
                var loc = fox.Location;
                Logger.WriteLine("Fox at (" + loc.X + "," + loc.Y + "): ");
                fox.AdvanceGeneration();
                if (fox.IsDead())
                {
                    Foxes.Remove(fox);
                }
                else
                {
                    if (fox.ReproduceThisPeriod())
                    {
                        Logger.WriteLine("  Fox has reproduced. ");
                        NewFoxCount++;
                    }
                    Logger.Write(fox.Inspect());
                    fox.ResetFoodConsumed();
                }
            }
            if (NewFoxCount > 0)
            {
                Logger.WriteLine("New foxes born: ");
                for (int f = 0; f < NewFoxCount; f++)
                {
                    CreateRandomFox();
                }
            }
        }

        private void FoxesEatRabbitsInWarren(Warren warren)
        {
            int FoodConsumed;
            int PercentToEat;
            double Dist;
            int RabbitsToEat;
            int RabbitCountAtStartOfPeriod = warren.RabbitCount;
            foreach (Fox fox in Foxes)
            {
                Dist = warren.Location.DistanceFrom(fox.Location);
                if (Dist <= 3.5)
                {
                    PercentToEat = 20;
                }
                else if (Dist <= 7)
                {
                    PercentToEat = 10;
                }
                else
                {
                    PercentToEat = 0;
                }
                RabbitsToEat = (int)Math.Round((double)(PercentToEat * RabbitCountAtStartOfPeriod / 100.0));
                FoodConsumed = warren.EatRabbits(RabbitsToEat);
                fox.GiveFood(FoodConsumed);
                var loc = fox.Location;
                Logger.WriteLine("  " + FoodConsumed + " rabbits eaten by fox at (" + loc.X + "," + loc.Y + ").");
            }
        }
    }
}