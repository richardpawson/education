using System;

namespace PredatorPrey
{

    class Simulation
    {
        public Location[,] Landscape { get; private set; }
        public int TimePeriod { get; private set; }
        public int WarrenCount { get; private set; }
        public int FoxCount { get; private set; }
        public int LandscapeSize { get; private set; }
        private int Variability;
        protected IRandomGenerator Rnd;
        private ILogger Logger;

        public Simulation(int LandscapeSize, int InitialWarrenCount, int InitialFoxCount,
            int Variability, bool FixedInitialLocations, ILogger Logger, IRandomGenerator Rnd)
        {
            this.Logger = Logger;
            this.Rnd = Rnd;
            this.LandscapeSize = LandscapeSize;
            this.Variability = Variability;
            Landscape = new Location[LandscapeSize, LandscapeSize];
            CreateLandscapeAndAnimals(InitialWarrenCount, InitialFoxCount, FixedInitialLocations);
        }

        public void AdvanceTimePeriod()
        {
            int NewFoxCount = 0;
            Logger.WriteLine();
            TimePeriod++;
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    if (Landscape[x, y].Warren != null)
                    {
                        Logger.WriteLine("Warren at (" + x + "," + y + "):");
                        Logger.Write("  Period Start: ");
                        Logger.Write(Landscape[x, y].Warren.Inspect());
                        if (FoxCount > 0)
                        {
                            FoxesEatRabbitsInWarren(x, y);
                        }
                        if (Landscape[x, y].Warren.NeedToCreateNewWarren())
                        {
                            CreateNewWarren();
                        }
                        Landscape[x, y].Warren.AdvanceGeneration();
                        Logger.Write("  Period End: ");
                        Logger.Write(Landscape[x, y].Warren.Inspect());
                        Logger.PageBreak();
                        if (Landscape[x, y].Warren.WarrenHasDiedOut())
                        {
                            Landscape[x, y].Warren = null;
                            WarrenCount--;
                        }
                    }
                }
            }
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    if (Landscape[x, y].Fox != null)
                    {
                        Logger.WriteLine("Fox at (" + x + "," + y + "): ");
                        Landscape[x, y].Fox.AdvanceGeneration();
                        if (Landscape[x, y].Fox.CheckIfDead())
                        {
                            Landscape[x, y].Fox = null;
                            FoxCount--;
                        }
                        else
                        {
                            if (Landscape[x, y].Fox.ReproduceThisPeriod())
                            {
                                Logger.WriteLine("  Fox has reproduced. ");
                                NewFoxCount++;
                            }
                            Logger.Write(Landscape[x, y].Fox.Inspect());
                            Landscape[x, y].Fox.ResetFoodConsumed();
                        }
                    }
                }
            }
            if (NewFoxCount > 0)
            {
                Logger.WriteLine("New foxes born: ");
                for (int f = 0; f < NewFoxCount; f++)
                {
                    CreateNewFox();
                }
            }
            Logger.PageBreak();
            Logger.WriteLine();
        }

        private void CreateLandscapeAndAnimals(int InitialWarrenCount, int InitialFoxCount, bool FixedInitialLocations)
        {
            for (int x = 0; x < LandscapeSize; x++)
            {
                for (int y = 0; y < LandscapeSize; y++)
                {
                    Landscape[x, y] = new Location();
                }
            }
            if (FixedInitialLocations)
            {
                Landscape[1, 1].Warren = new Warren(Variability, 38, Logger, Rnd);
                Landscape[2, 8].Warren = new Warren(Variability, 80, Logger, Rnd);
                Landscape[9, 7].Warren = new Warren(Variability, 20, Logger, Rnd);
                Landscape[10, 3].Warren = new Warren(Variability, 52, Logger, Rnd);
                Landscape[13, 4].Warren = new Warren(Variability, 67, Logger, Rnd);
                WarrenCount = 5;
                Landscape[2, 10].Fox = new Fox(Variability, Logger, Rnd);
                Landscape[6, 1].Fox = new Fox(Variability, Logger, Rnd);
                Landscape[8, 6].Fox = new Fox(Variability, Logger, Rnd);
                Landscape[11, 13].Fox = new Fox(Variability, Logger, Rnd);
                Landscape[12, 4].Fox = new Fox(Variability, Logger, Rnd);
                FoxCount = 5;
            }
            else
            {
                for (int w = 0; w < InitialWarrenCount; w++)
                {
                    CreateNewWarren();
                }
                for (int f = 0; f < InitialFoxCount; f++)
                {
                    CreateNewFox();
                }
            }
        }

        private void CreateNewWarren()
        {
            int x, y;
            do
            {
                x = Rnd.Next(0, LandscapeSize);
                y = Rnd.Next(0, LandscapeSize);
            } while (Landscape[x, y].Warren != null);
            Logger.WriteLine("New Warren at (" + x + "," + y + ")");
            Landscape[x, y].Warren = new Warren(Variability, Logger, Rnd);
            WarrenCount++;
        }

        private void CreateNewFox()
        {
            int x, y;
            do
            {
                x = Rnd.Next(0, LandscapeSize);
                y = Rnd.Next(0, LandscapeSize);
            } while (Landscape[x, y].Fox != null);
            Logger.WriteLine("  New Fox at (" + x + "," + y + ")");
            Landscape[x, y].Fox = new Fox(Variability, Logger, Rnd);
            FoxCount++;
        }

        private void FoxesEatRabbitsInWarren(int WarrenX, int WarrenY)
        {
            int FoodConsumed;
            int PercentToEat;
            double Dist;
            int RabbitsToEat;
            int RabbitCountAtStartOfPeriod = Landscape[WarrenX, WarrenY].Warren.GetRabbitCount();
            for (int FoxX = 0; FoxX < LandscapeSize; FoxX++)
            {
                for (int FoxY = 0; FoxY < LandscapeSize; FoxY++)
                {
                    if (Landscape[FoxX, FoxY].Fox != null)
                    {
                        Dist = DistanceBetween(FoxX, FoxY, WarrenX, WarrenY);
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
                        FoodConsumed = Landscape[WarrenX, WarrenY].Warren.EatRabbits(RabbitsToEat);
                        Landscape[FoxX, FoxY].Fox.GiveFood(FoodConsumed);
                        Logger.WriteLine("  " + FoodConsumed + " rabbits eaten by fox at (" + FoxX + "," + FoxY + ").");
                    }
                }
            }
        }

        private double DistanceBetween(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }

}
