using System;

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
        protected static Random Rnd = new Random();

        public Animal(int AvgLifespan, double AvgProbabilityOfDeathOtherCauses, int Variability)
        {
            NaturalLifespan = AvgLifespan * CalculateRandomValue(100, Variability) / 100;
            ProbabilityOfDeathOtherCauses = AvgProbabilityOfDeathOtherCauses * CalculateRandomValue(100, Variability) / 100;
            IsAlive = true;
            ID = NextID;
            NextID++;
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

        public virtual void Inspect()
        {
            Console.Write("  ID " + ID + " ");
            Console.Write("Age " + Age + " ");
            Console.Write("LS " + NaturalLifespan + " ");
            Console.Write("Pr dth " + Math.Round(ProbabilityOfDeathOtherCauses, 2) + " ");
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
