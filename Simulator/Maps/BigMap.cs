namespace Simulator.Maps;

public abstract class BigMap : Map 
{
    Dictionary<Point, List<IMappable>> _fields;

    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000 ) throw new ArgumentException(nameof(sizeX), "Wrong width");
        if (sizeY > 1000 ) throw new ArgumentException(nameof(sizeY), "Wrong height");

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}

