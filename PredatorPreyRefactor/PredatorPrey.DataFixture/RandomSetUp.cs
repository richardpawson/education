using PredatorPrey.Model;
using TechnicalServices;

namespace PredatorPrey.DataFixture
{
    public class RandomSetUp : SetUp
    {
        int InitialWarrenCount;
        int InitialFoxCount;

        public RandomSetUp(int initialWarrenCount, int initialFoxCount, Landscape landscape, int variability, ILogger logger, IRandomGenerator randomGenerator) :
            base(landscape, variability, logger, randomGenerator)
        {
            this.InitialWarrenCount = initialWarrenCount;
            this.InitialFoxCount = initialFoxCount;
            CreateWarrens();
            CreateFoxes();
        }
        protected void CreateWarrens()
        {
            for (int w = 0; w < InitialWarrenCount; w++)
            {
                CreateRandomWarren();
            }
        }

        protected void CreateFoxes()
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
