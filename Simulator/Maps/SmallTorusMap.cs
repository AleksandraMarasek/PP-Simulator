using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map 
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    //public override bool Exist(Point p) => _map.Contains(p);

    public override Point Next(Point p, Direction d)
    {

        //if (_map.Contains(p.Next(d))) { return p.Next(d); }
        //return p;
        if (p.X == 0 && d == Direction.Left) return new Point(SizeX - 1, p.Y);
        else if (p.X == SizeX - 1 && d == Direction.Right) return new Point(0, p.Y);
        else if (p.Y == 0 && d == Direction.Down) return new Point(p.X, SizeY - 1);
        else if (p.Y == SizeY - 1 && d == Direction.Up) return new Point(p.X,0);
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextD = p.NextDiagonal(d);

        int x = (nextD.X + SizeX)%SizeX;
        int y = (nextD.Y + SizeY)%SizeY;

        return new Point(x, y);
    }
}