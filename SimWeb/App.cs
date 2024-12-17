using Simulator;
using Simulator.Maps;

namespace SimWeb;

public static class App
{
    public readonly static SimulationHistory _historia;

    static App()
    {
        try
        {
            BigTorusMap mapa = new(6, 7);
            List<IMappable> creatures =
                [new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals() { Description = "Rabbits", Size = 7 },
                new Birds() { Description = "Eagles", Size = 2 },
                new Birds() { Description = "Ostriches", CanFly = false }];

            List<Point> points =
                [new(1, 2),
                new(1, 1),
                new(1, 3),
                new(5, 4),
                new(5, 3)];

            string moves = "llllulludddlrdlrulrdruld";

            Simulation simulation = new(mapa, creatures, points, moves);

            _historia = new(simulation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas inicjalizacji: {ex.Message}");
        }
    }
}