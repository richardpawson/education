using System;
using System.Collections.Generic;
using System.Linq;

namespace PredatorPrey
{
    public abstract class SetUp
    {
        public Landscape Landscape { get; protected set; }
        public List<Warren> Warrens { get; protected set; } 
        public List<Fox> Foxes { get; protected set; }
        public int Variability { get; protected set; }
        protected ILogger Logger;
        protected IRandomGenerator RandomGenerator;

        public SetUp(Landscape landscape, int variability, ILogger logger, IRandomGenerator randomGenerator)
        {
            Warrens = new List<Warren>();
            Foxes =  new List<Fox>();
            this.Variability = variability;
            this.Logger = logger;
            this.RandomGenerator = randomGenerator;
            this.Landscape = landscape;
        }

        protected Fox GetFox(Location loc)
        {
            return Foxes.FirstOrDefault(f => f.Location == loc);
        }

        protected Warren GetWarren(Location loc)
        {
            return Warrens.FirstOrDefault(w => w.Location == loc);
        }
    }

    public class FixedLocationSetUp : SetUp
    {
        public FixedLocationSetUp(Landscape landscape, int variability, ILogger logger, IRandomGenerator randomGenerator):
            base(landscape, variability, logger, randomGenerator)
        {
            CreateWarrens();
            CreateFoxes();
        }

        protected void CreateWarrens()
        {
            CreateNewWarren(1, 1, 38);
            CreateNewWarren(2, 8, 80);
            CreateNewWarren(9, 7, 20);
            CreateNewWarren(10, 3, 52);
            CreateNewWarren(3, 4, 67);
        }

        protected void CreateFoxes()
        {
            CreateNewFox(2, 10);
            CreateNewFox(6, 1);
            CreateNewFox(8, 6);
            CreateNewFox(11, 13);
            CreateNewFox(12, 4);
        }

        protected void CreateNewWarren(int x, int y, int rabbitCount)
        {
            var loc = Landscape.GetLocation(x, y);
            var warren = new Warren(loc, Variability, Logger, RandomGenerator, rabbitCount);
            Warrens.Add(warren);
        }

        protected void CreateNewFox(int x, int y)
        {
            var loc = Landscape.GetLocation(x, y);
            var fox = new Fox(loc, Variability, Logger, RandomGenerator);
            Foxes.Add(fox);
        }
    }

    public class RandomSetUp : SetUp
    {
        int InitialWarrenCount;
        int InitialFoxCount;

        public RandomSetUp(int initialWarrenCount, int initialFoxCount, Landscape landscape, int variability, ILogger logger, IRandomGenerator randomGenerator):
            base(landscape, variability, logger, randomGenerator)
        {
            this.InitialWarrenCount = initialWarrenCount;
            this.InitialFoxCount = initialFoxCount;
            CreateWarrens();
            CreateFoxes();
        }
        protected  void CreateWarrens()
        {
            for (int w = 0; w < InitialWarrenCount; w++)
            {
                CreateRandomWarren();
            }
        }

        protected  void CreateFoxes()
        {
            for (int f = 0; f < InitialFoxCount; f++)
            {
                CreateRandomFox();
            }
        }


        protected void CreateRandomWarren()
        {
            Location loc;
            do
            {
                loc = Landscape.RandomLocation();
            } while (GetWarren(loc) != null);
            var warren = new Warren(loc, Variability, Logger, RandomGenerator);
            Warrens.Add(warren);
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
        }
    }
}
