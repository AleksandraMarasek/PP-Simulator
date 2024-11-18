using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Xunit;

public class PointTests
{
    [Theory]
    [InlineData(1,1,"(1, 1)")]
    [InlineData(-10,23,"(-10, 23)")]

    public void ToString_ShouldReturnCorrectString(int x, int y, string expected)
    {
        var result = new Point(x,y);

        Assert.Equal(expected, result.ToString());
    }

    [Theory]
    [InlineData(0,0,Direction.Up,0,1)]
    [InlineData(0,0,Direction.Right,1,0)]
    [InlineData(0,0,Direction.Down,0,-1)]
    [InlineData(0,0,Direction.Left,-1,0)]


    public void Next_ShouldReturnCorrectPoint(int x, int y,Direction direction,int xexpected,int yexpected)
    {
        var p = new Point(x,y);
        var result = p.Next(direction);
        var expected= new Point(xexpected,yexpected);
        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Up, 1, 1)]

    public void NextDiagonal_ShouldReturnCorectPoint(int x, int y, Direction direction, int xexpected, int yexpected)
    {
        var p = new Point(x, y);
        var result = p.NextDiagonal(direction);
        var expected = new Point(xexpected,yexpected);
        Assert.Equal(expected, result);
    }
}