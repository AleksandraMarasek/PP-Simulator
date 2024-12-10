using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public override void Add(IMappable mappable, Point position)
    {
        if (!_fields.ContainsKey(position)){ _fields[position] = new List<IMappable>(); }
        _fields[position].Add(mappable);
        //mappable.InitMapAndPosition(this, position);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        _fields[position].Remove(mappable);
    }

    public override List<IMappable> At(int x, int y)
    {
        var p = new Point(x , y);
        if (_fields.ContainsKey(p))
        {
            return _fields[p];
        }
        return new List<IMappable>();

    }

    public override List<IMappable> At(Point p)
    {
        if (_fields.ContainsKey(p)) { return _fields[p]; }
        return new List<IMappable>();
    }

    public override void Move(IMappable mappable, Point p, Point pn)
    {
        Remove(mappable, p);
        Add(mappable, pn);
    }
}

