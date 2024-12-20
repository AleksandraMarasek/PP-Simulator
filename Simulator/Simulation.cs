﻿using Simulator.Maps;
using System.Diagnostics.Metrics;

namespace Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> IMappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    private List<Direction> DirectionsParsed { get; }

    public bool Finished = false;

    private int _currentTurn = 0;
    public IMappable CurrentMappable => IMappables[_currentTurn % IMappables.Count];
    public string CurrentMoveName
    {
        get => DirectionsParsed[_currentTurn % DirectionsParsed.Count].ToString().ToLower();
    }

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
            .Where(c => "lurd".Contains(char.ToLower(c)))
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault()) 
            .ToList();
    }


}