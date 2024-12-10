using Simulator.Maps;


namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    public required string Description
    {
        get => _description;
        init{_description = Validator.Shortener(value, 3, 15, '#');}
    }
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }
    public virtual char Symbol => 'A';

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

   
    protected virtual Point NewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }


    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("The animal can't move while not being on the map.");
        var _move = NewPosition(direction);
        if (!Map.Exist(_move))
            throw new InvalidOperationException("The animal can't move outside the map boundaries.");

        Map.Move(this, Position, _move);
        Position = _move;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("This animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentOutOfRangeException(nameof(point), "Position is not in the map.");

        Map = map;
        Position = point;
        map.Add(this, point);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
