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
        Console.WriteLine("Starting simulation!\n");

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
        SimulationHistory history = simulation.History;
        MapVisualizer mapVisualizer = new(simulation.Map);

        var turn = 1;
        mapVisualizer.Draw();

       
        while (!simulation.Finished)
        {
            Console.ReadKey(intercept: true);
            Console.WriteLine($"Turn {turn}");
            Console.WriteLine($"{simulation.CurrentMappable} goes {simulation.CurrentMoveName}");

            simulation.Turn();
            mapVisualizer.Draw();

            turn++;

        }
        simulation.ShowTurns(new List<int> { 5, 10, 15, 20,0 });

    }
}