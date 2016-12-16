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
            RunSimulation(Sim);
        }

        private static void RunSimulation(Simulation Sim)
        {
            DrawLandscape(Sim);
            int menuOption;
            int x;
            int y;
            string viewRabbits;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Advance to next time period showing detail");
                Console.WriteLine("2. Advance to next time period hiding detail");
                Console.WriteLine("3. Inspect fox");
                Console.WriteLine("4. Inspect warren");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Select option: ");
                menuOption = Convert.ToInt32(Console.ReadLine());
                if (menuOption == 1)
                {
                    Sim.ShowDetail = true;
                    Sim.AdvanceTimePeriod();
                    DrawLandscape(Sim);
                }
                if (menuOption == 2)
                {
                    Sim.ShowDetail = false;
                    Sim.AdvanceTimePeriod();
                    DrawLandscape(Sim);
                }
                if (menuOption == 3)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    if (Sim.Landscape[x, y].Fox != null)
                    {
                        Sim.Landscape[x, y].Fox.Inspect();
                    }
                }
                if (menuOption == 4)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    if (Sim.Landscape[x, y].Warren != null)
                    {
                        Sim.Landscape[x, y].Warren.Inspect();
                        Console.Write("View individual rabbits (y/n)?");
                        viewRabbits = Console.ReadLine();
                        if (viewRabbits == "y")
                        {
                            Sim.Landscape[x, y].Warren.ListRabbits();
                        }
                    }
                }
            } while (((Sim.WarrenCount > 0) || (Sim.FoxCount > 0)) && (menuOption != 5));
            Console.ReadKey();
        }

        private static void DrawLandscape(Simulation Sim)
        {
            Console.WriteLine();
            Console.WriteLine("TIME PERIOD: " + Sim.TimePeriod);
            Console.WriteLine();
            Console.Write("    ");
            for (int x = 0; x < Sim.LandscapeSize; x++)
            {
                if (x < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(x + " |");
            }
            Console.WriteLine();
            for (int x = 0; x <= Sim.LandscapeSize * 4 + 3; x++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int y = 0; y < Sim.LandscapeSize; y++)
            {
                if (y < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(" " + y + "|");
                for (int x = 0; x < Sim.LandscapeSize; x++)
                {
                    if (Sim.Landscape[x, y].Warren != null)
                    {
                        if (Sim.Landscape[x, y].Warren.GetRabbitCount() < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(Sim.Landscape[x, y].Warren.GetRabbitCount());
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (Sim.Landscape[x, y].Fox != null)
                    {
                        Console.Write("F");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        private static int InputCoordinate(char Coordinatename)
        {
            Console.Write("  Input " + Coordinatename + " coordinate: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static int InputInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}