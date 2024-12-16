using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

internal class LogVisualizer
{
    private SimulationHistory Log { get; }

    public LogVisualizer(SimulationHistory log)
    {
        Log = log ?? throw new ArgumentNullException(nameof(log));
    }

    /// <summary>
    /// Renders the state of the map for a specific turn index.
    /// </summary>
    /// <param name="turnIndex">The index of the turn to visualize.</param>
    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Invalid turn index.");
        }

        var turnLog = Log.TurnLogs[turnIndex];
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write(Box.TopLeft);
        for (int x = 0; x < Log.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int y = Log.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < Log.SizeX; x++)
            {
                var position = new Point(x, y);
                if (turnLog.Symbols.TryGetValue(position, out var symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < Log.SizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < Log.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
        Console.WriteLine();
    }
}