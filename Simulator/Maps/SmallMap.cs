using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");

        _fields = new List<IMappable>?[sizeX, sizeY];
    }
    public override void Add(IMappable mappable, Point position)
    {
        if (_fields[position.X, position.Y] == null)
            _fields[position.X, position.Y] = new List<IMappable>();
        _fields[position.X, position.Y].Add(mappable);
        //_fields[position.X, position.Y] ??= new List<IMappable>();
        //_fields[position.X, position.Y].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (_fields[position.X, position.Y] != null)
            _fields[position.X, position.Y].Remove(mappable);
        //_fields[position.X, position.Y]?.Remove(mappable);
    }

    public override void Move(IMappable mappable, Point _from, Point _to)
    {
        Remove(mappable, _from);
        Add(mappable, _to);
    }

    public override List<IMappable> At(int x, int y) =>  At(new Point(x, y));

    public override List<IMappable> At(Point p)
    {
        return _fields[p.X, p.Y];
    }
}