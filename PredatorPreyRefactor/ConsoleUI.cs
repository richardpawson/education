using System;

namespace PredatorPrey
{
    public class ConsoleUI
    {
       public static void Main()
        {
            int landscapeSize = 15;
            int initialWarrenCount = 5;
            int initialFoxCount = 5;
            int variability = 0;
            bool fixedInitialLocations = true;
            ILogger logger = new ConsoleLogger();
            IRandomGenerator randomGenerator = new SystemRandomGenerator();
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
                    landscapeSize = InputInt("Landscape Size: ");
                    initialWarrenCount = InputInt("Initial number of warrens: ");
                    initialFoxCount = InputInt("Initial number of foxes: ");
                    variability = InputInt("Randomness variability (percent): ");
                    fixedInitialLocations = false;
                    break;
                }
                else if (MenuOption == "3")
                {
                    return; //exit Main method
                }
            } while (true);
            SquareLandscape land = new SquareLandscape(landscapeSize, randomGenerator);
            Simulation sim = new Simulation(land, initialWarrenCount,
                initialFoxCount, variability, fixedInitialLocations, logger, randomGenerator);
            RunSimulation(sim, logger);
        }

        private static void RunSimulation(Simulation sim, ILogger logger)
        {
            int menuOption;
            int x;
            int y;
            string viewRabbits;

            DrawSquareLandscape(sim);
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
                    logger.StartLogging();
                    sim.AdvanceTimePeriod();
                    DrawSquareLandscape(sim);
                }
                if (menuOption == 2)
                {
                    logger.StopLogging();
                    sim.AdvanceTimePeriod();
                    DrawSquareLandscape(sim);
                }
                if (menuOption == 3)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    Location loc = sim.Landscape.GetLocation(x, y);
                    Fox fox = sim.GetFox(loc);
                    if (fox!= null)
                    {
                        Console.Write(fox.Inspect());
                    }
                }
                if (menuOption == 4)
                {
                    x = InputCoordinate('x');
                    y = InputCoordinate('y');
                    Location loc = sim.Landscape.GetLocation(x, y);
                    Warren warren = sim.GetWarren(loc);
                    if ( warren != null)
                    {
                        Console.Write(warren.Inspect());
                        Console.Write("View individual rabbits (y/n)?");
                        viewRabbits = Console.ReadLine();
                        if (viewRabbits == "y")
                        {
                            Console.Write(warren.InspectAllRabbits());
                        }
                    }
                }
            } while ((sim.HasLife()) && (menuOption != 5));
        }

        private static void DrawSquareLandscape(Simulation sim)
        {
            Console.WriteLine();
            Console.WriteLine("TIME PERIOD: " + sim.TimePeriod);
            Console.WriteLine();
            Console.Write("    ");
            var land = (SquareLandscape) sim.Landscape; //Down-cast is OK as this method is explicly for Square Landscapes only
            DrawColumnHeaders(land.Size);
            for (int y = 0; y <= land.Size; y++)
            {
                if (y < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(" " + y + "|");
                for (int x = 0; x < land.Size; x++)
                {
                    var loc = land.GetLocation(x, y);
                    DrawCellWithContents(loc, sim);
                }
                Console.WriteLine();
            }
        }

        private static void DrawColumnHeaders(int size)
        {
            for (int x = 0; x < size; x++)
            {
                if (x < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(x + " |");
            }
            Console.WriteLine();
            for (int x = 0; x <= size * 4 + 3; x++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private static void DrawCellWithContents(Location loc, Simulation sim)
        {
            var warren = sim.GetWarren(loc);
            if (warren != null)
            {
                if (warren.RabbitCount < 10)
                {
                    Console.Write(" ");
                }
                Console.Write(warren.RabbitCount);
            }
            else
            {
                Console.Write("  ");
            }
            if (sim.GetFox(loc) != null)
            {
                Console.Write("F");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("|");
        }

        private static int InputCoordinate(char coordinatename)
        {
            return InputInt("  Input " + coordinatename + " coordinate: ");
        }

        private static int InputInt(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}