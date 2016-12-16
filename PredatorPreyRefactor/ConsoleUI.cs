using System;

namespace PredatorPrey
{
    class ConsoleUI
    {
        static void Main()
        {
            int LandscapeSize = 15;
            int InitialWarrenCount = 5;
            int InitialFoxCount = 5;
            int Variability = 0;
            bool FixedInitialLocations = true;
            do
            {
                Console.WriteLine("Predator Prey Simulation Main Menu");
                Console.WriteLine();
                Console.WriteLine("1. Run simulation with default settings");
                Console.WriteLine("2. Run simulation with custom settings");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Select option: ");
                string MenuOption = Console.ReadLine();
                if (MenuOption == "1")
                {
                    break;
                }
                else if (MenuOption == "2")
                {
                    LandscapeSize = InputInt("Landscape Size: ");
                    InitialWarrenCount = InputInt("Initial number of warrens: ");
                    InitialFoxCount = InputInt("Initial number of foxes: ");
                    Variability = InputInt("Randomness variability (percent): ");
                    FixedInitialLocations = false;
                    break;
                }
                else if (MenuOption == "3")
                {
                    return; //exit Main method
                }
            } while (true);
            Simulation Sim = new Simulation(LandscapeSize, InitialWarrenCount,
                InitialFoxCount, Variability, FixedInitialLocations);
        }

        private static int InputInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
    }




}