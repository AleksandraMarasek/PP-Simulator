using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        Point pointN = p.Next(d);

        //OX
        if (pointN.X < 0)
        {
            pointN = new Point(-pointN.X, pointN.Y);
        }
        else if (pointN.X >= SizeX)
        {
            pointN = new Point(2 * (SizeX - 1) - pointN.X, pointN.Y);
        }
        //OY
        if (pointN.Y < 0)
        {
            pointN = new Point(pointN.X, -pointN.Y);
        }
        else if (pointN.Y >= SizeY)
        {
            pointN = new Point(pointN.X , 2* (SizeY -1) - pointN.Y);
        }

        return pointN;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (p.X == 0 && p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p;
                case Direction.Left:
                    return p;
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }
        else if (p.X == SizeX - 1 && p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
                case Direction.Down:
                    return p;
                case Direction.Up:
                    return p;
            }
        }
        else if (p.X == SizeX - 1 && p.Y == SizeY - 1)
        {
            switch (d)
            {
                case Direction.Right:
                    return p;
                case Direction.Left:
                    return p;
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
            }
        }
        else if (p.X == 0 && p.Y == SizeX - 1)
        {
            switch (d)
            {
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
                case Direction.Down:
                    return p;
                case Direction.Up:
                    return p;
            }
        }
        else if (p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }
        else if (p.X == SizeX - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
            }
        }
        else if (p.Y == SizeY - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
            }
        }
        else if (p.X == 0)
        {
            switch (d)
            {
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }

        return p.NextDiagonal(d);

    }

}
