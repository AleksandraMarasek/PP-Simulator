namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        int xp = (p.Next(d).X + SizeX) % SizeX;
        int yp = (p.Next(d).Y + SizeY) % SizeY;

        return new Point(xp, yp);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextD = p.NextDiagonal(d);

        int x = (nextD.X + SizeX) % SizeX;
        int y = (nextD.Y + SizeY) % SizeY;

        return new Point(x, y);
    }
}