using System;
using System.Text;

namespace PredatorPrey
{
    class Animal
    {
        protected double NaturalLifespan;
        protected int ID;
        protected static int NextID = 1;
        protected int Age = 0;
        protected double ProbabilityOfDeathOtherCauses;
        protected bool IsAlive;
        protected IRandomGenerator Rnd;
        protected ILogger Logger;

        public Animal(int AvgLifespan, double AvgProbabilityOfDeathOtherCauses, int Variability, ILogger Logger, IRandomGenerator Rnd)
        {
            this.Rnd = Rnd;
            NaturalLifespan = AvgLifespan * CalculateRandomValue(100, Variability) / 100;
            ProbabilityOfDeathOtherCauses = AvgProbabilityOfDeathOtherCauses * CalculateRandomValue(100, Variability) / 100;
            IsAlive = true;
            ID = NextID;
            NextID++;
            this.Logger = Logger;
        }

        public virtual void CalculateNewAge()
        {
            Age++;
            if (Age >= NaturalLifespan)
            {
                IsAlive = false;
            }
        }

        public virtual bool CheckIfDead()
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
            if (Rnd.Next(0, 100) < ProbabilityOfDeathOtherCauses * 100)
            {
                IsAlive = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual double CalculateRandomValue(int BaseValue, int Variability)
        {
            return BaseValue - (BaseValue * Variability / 100) + (BaseValue * Rnd.Next(0, (Variability * 2) + 1) / 100);
        }
    }
}
