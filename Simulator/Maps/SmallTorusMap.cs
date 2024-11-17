using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private readonly Rectangle _map;
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Zły rozmiar mapy!");
        Size = size;
        _map = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    

    public override bool Exist(Point p) => _map.Contains(p);

    public override Point Next(Point p, Direction d)
    {

        //if (_map.Contains(p.Next(d))) { return p.Next(d); }
        //return p;
        if (p.X == 0 && d == Direction.Left) return new Point(Size - 1, p.Y);
        else if (p.X == Size - 1 && d == Direction.Right) return new Point(0, p.Y);
        else if (p.Y == 0 && d == Direction.Down) return new Point(p.X, Size - 1);
        else if (p.Y == Size - 1 && d == Direction.Up) return new Point(p.X,0);
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextD = p.NextDiagonal(d);

        int x = (nextD.X + Size)%Size;
        int y = (nextD.Y + Size)%Size;

        return new Point(x, y);
    }
}