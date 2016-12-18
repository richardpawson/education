using PredatorPrey.Model;
using TechnicalServices;

namespace PredatorPrey.DataFixture
{
    public class FixedLocationSetUp : SetUp
    {
        public FixedLocationSetUp(Landscape landscape, int variability, ILogger logger, IRandomGenerator randomGenerator) :
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
}
