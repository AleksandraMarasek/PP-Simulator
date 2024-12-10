using Simulator;
using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private readonly List<State> _history = new();

    public void SaveCurrentTurn(int turn, Dictionary<IMappable, Point> positions, IMappable currentMappable, Direction? currentMove) =>
        _history.Add(new State
        {
            Turn = turn,
            Positions = new Dictionary<IMappable, Point>(positions),
            CurrentMappable = currentMappable,
            CurrentMove = currentMove
        });


    public void ShowSpecificTurns(IEnumerable<int> turns)
    {
        foreach (var turn in turns)
        {
            Console.WriteLine($"Turn {turn}");
            var state = _history[turn];
            if (state.CurrentMappable != null && state.CurrentMove.HasValue) Console.WriteLine($"{state.CurrentMappable.ToString()} moved {state.CurrentMove}");

            foreach (var mappable in state.Positions) Console.WriteLine($"{mappable.Key} - {mappable.Value}");
            Console.WriteLine();
        }
    }

    public class State
    {
        public int Turn { get; set; }
        public Dictionary<IMappable, Point> Positions { get; set; } = new();
        public IMappable? CurrentMappable { get; set; }
        public Direction? CurrentMove { get; set; }
    }
}