using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    
    private List<Direction> DirectionsParsed { get; }

    public bool Finished = false;
    private int _currentTurn = 0;
    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => IMappables[_currentTurn % IMappables.Count ]; 

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    /// 

    public string CurrentMoveName
    {
        get => DirectionsParsed[_currentTurn % DirectionsParsed.Count].ToString().ToLower();
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    { 
        if (mappables == null || mappables.Count == 0) throw new ArgumentException("The list of mappables cannot be empty.", nameof(positions));
        if (positions == null || positions.Count != mappables.Count) throw new ArgumentException("Number of starting positions must be the same as the number of mappables.", nameof(positions));
        if (string.IsNullOrEmpty(moves)) throw new ArgumentException("Moves string cannot be null or empty.", nameof(moves));

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;

        Moves = moves;
        DirectionsParsed = ValidateMoves(moves);




        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        var direction = DirectionsParsed[_currentTurn % DirectionsParsed.Count];
        CurrentMappable.Go(direction);
        _currentTurn++;
        if (_currentTurn >= DirectionsParsed.Count)
            Finished = true;

    }

    private List<Direction> ValidateMoves(string moves)
    {
        return moves
            .Where(c => "urdl".Contains(char.ToLower(c))) // Filtruj tylko poprawne znaki ruchów
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault()) // Parsuj je do Direction
            .Where(d => d != default(Direction)) // Usuń potencjalne null/invalid
            .ToList();
    }

}