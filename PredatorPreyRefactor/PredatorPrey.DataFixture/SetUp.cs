using PredatorPrey.Model;
using System.Collections.Generic;
using System.Linq;
using TechnicalServices;

namespace PredatorPrey.DataFixture
{
    public abstract class SetUp : ISetUp
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
}
