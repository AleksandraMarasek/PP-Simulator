using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;


    private int _currentTurn = 0;
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get => Creatures[_currentTurn % Creatures.Count ]; }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get => DirectionParser.Parse(Moves[_currentTurn%Moves.Length].ToString()).ToString().ToLower(); }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    { 
        if (creatures == null || creatures.Count == 0) throw new ArgumentException("The list of creatures cannot be empty.", nameof(positions));
        if (positions == null || positions.Count != creatures.Count) throw new ArgumentException("Number of starting positions must be the same as the number of creatures.", nameof(positions));
        if (string.IsNullOrEmpty(moves)) throw new ArgumentException("Moves string cannot be null or empty.", nameof(moves));

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves.ToLower();

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");


        var direction = DirectionParser.Parse(Moves[_currentTurn % Moves.Length].ToString())[0];
        CurrentCreature.Go(direction);

        CurrentCreature.Go(direction);

        _currentTurn++;

        if (_currentTurn >= Moves.Length)
            Finished = true;

    }
}