using System;
using System.Net.Http.Headers;
using System.Text;
using Simulator;
using Simulator.Maps;


namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        
        BigBounceMap map = new(8, 6);
        List<IMappable> creatures =
            [new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals() { Description = "Rabbits", Size = 7 },
            new Birds() { Description = "Eagles", Size = 2 },
            new Birds() { Description = "Ostriches", CanFly = false }];

        List<Point> points =
            [new(1,2),
            new(1,1),
            new(1,3),
            new(5,4),
            new(5,3)];

        string moves = "llllulludddlrdlrulrdruld";

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory simulationHistory = new(simulation);
        LogVisualizer logVisualizer = new(simulationHistory);



        Console.Clear();
        Console.WriteLine("Starting Simulation!");
        logVisualizer.Draw(0);
        
        foreach (var creature in creatures)
        {
            Console.WriteLine($"{creature} is at position {creature.Position}");
        }

        Console.WriteLine("\nPress any key to start the simulation...");

        Console.ReadKey(intercept: true);





        for (int i = 1; i < simulationHistory.TurnLogs.Count; i++)
        {
            Console.Clear();
            Console.WriteLine($"Turn {i}:");
            logVisualizer.Draw(i);

            var currentLog = simulationHistory.TurnLogs[i-1];
            Console.WriteLine($"{currentLog.Mappable} moves {currentLog.Move}");

            Console.ReadKey(intercept: true);
        }

        Console.ReadKey(intercept: true);
        Console.Clear();
       
        Console.WriteLine("\nHistory of selected turns:");
        int[] selectedTurns = { 5, 10, 12 };
        foreach (int turn in selectedTurns)
        {
            if (turn > simulationHistory.TurnLogs.Count || turn < 1)
            {
                Console.WriteLine($"Turn {turn} does not exist.");
                continue;
            }

            Console.WriteLine($"\nTurn {turn}:");
            logVisualizer.Draw(turn - 1);
            var log = simulationHistory.TurnLogs[turn - 1];
            Console.WriteLine($"{log.Mappable} moved {log.Move}");
        }

        Console.WriteLine("\nSimulation finished!");
    }
}