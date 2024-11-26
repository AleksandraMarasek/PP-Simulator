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
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(7);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Elf("Ann")];
        List<Point> points = [new(2, 2), new(3, 1), new(1,1)];
        string moves = "dlrludlluur";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);
        mapVisualizer.Draw();

        Console.WriteLine("SIMULATION");
        Console.WriteLine("Starting positions:");


        while (!simulation.Finished)
        {
        
            Console.WriteLine("Press any key to make a move...");
            Console.ReadKey(true);

            try
            {
               
                simulation.Turn();

                
                Console.Clear();
                Console.WriteLine($"Move: {simulation.CurrentMoveName}, Creature: {simulation.CurrentCreature.Name}");
                mapVisualizer.Draw();
            }
            catch (InvalidOperationException ex)
            {
                
                Console.WriteLine($"Simulation error: {ex.Message}");
                break;
            }
        }

        Console.WriteLine("Simulation is finished!");
    }
}
