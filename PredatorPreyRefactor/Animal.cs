using System;
using System.Text;

namespace PredatorPrey
{
    public class Animal
    {
        public Location Location { get; private set; }
        protected double NaturalLifespan;
        protected int ID;
        protected static int NextID = 1;
        protected int Age = 0;
        protected double ProbabilityOfDeathOtherCauses;
        protected bool IsAlive;
        protected IRandomGenerator RandomGenerator;
        protected ILogger Logger;

        public Animal(Location loc, int avgLifespan, double avgProbabilityOfDeathOtherCauses, int variability, ILogger logger, IRandomGenerator randGen)
        {
            Location = loc;
            this.RandomGenerator = randGen;
            NaturalLifespan = avgLifespan * CalculateRandomValue(100, variability) / 100;
            ProbabilityOfDeathOtherCauses = avgProbabilityOfDeathOtherCauses * CalculateRandomValue(100, variability) / 100;
            IsAlive = true;
            ID = NextID;
            NextID++;
            this.Logger = logger;
        }

        public virtual void CalculateNewAge()
        {
            Age++;
            if (Age >= NaturalLifespan)
            {
                IsAlive = false;
            }
        }

        public virtual bool IsDead()
        {
            return !IsAlive;
        }

        public virtual string Inspect()
        {
            var sb = new StringBuilder();
            sb.Append("  ID " + ID + " ");
            sb.Append("Age " + Age + " ");
            sb.Append("LS " + NaturalLifespan + " ");
            sb.Append("Pr dth " + Math.Round(ProbabilityOfDeathOtherCauses, 2) + " ");
            return sb.ToString();
        }

        public virtual bool CheckIfKilledByOtherFactor()
        {
            if (RandomGenerator.Next(0, 100) < ProbabilityOfDeathOtherCauses * 100)
            {
                IsAlive = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual double CalculateRandomValue(int baseValue, int variability)
        {
            return baseValue - (baseValue * variability / 100) + (baseValue * RandomGenerator.Next(0, (variability * 2) + 1) / 100);
        }
    }
}