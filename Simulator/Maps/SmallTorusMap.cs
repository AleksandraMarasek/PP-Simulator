using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap 
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        int xp = (p.Next(d).X + SizeX) % SizeX;
        int yp = (p.Next(d).Y + SizeY) % SizeY;
        
        return new Point(xp, yp);
        //if (p.X == 0 && d == Direction.Left) return new Point(SizeX - 1, p.Y);
        //else if (p.X == SizeX - 1 && d == Direction.Right) return new Point(0, p.Y);
        //else if (p.Y == 0 && d == Direction.Down) return new Point(p.X, SizeY - 1);
        //else if (p.Y == SizeY - 1 && d == Direction.Up) return new Point(p.X,0);
        //return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextD = p.NextDiagonal(d);

        int x = (nextD.X + SizeX)%SizeX;
        int y = (nextD.Y + SizeY)%SizeY;

        return new Point(x, y);
    }

}