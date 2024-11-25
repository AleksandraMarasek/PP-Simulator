using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;


namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_Size_ShouldCreateMap(int size)
    {
        var map = new SmallSquareMap(size);

        Assert.Equal(size, map.SizeX);

    }


    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {

        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }


    [Theory]
    [InlineData(10,1,1,true)]
    [InlineData(10,12,1,false)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int size, int x, int y, bool expected)
    {
        var map = new SmallSquareMap(size);
        var p = new Point(x, y);
        var result = map.Exist(p);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(5,5,Direction.Right,6,5)]
    [InlineData(1,1,Direction.Left,0,1)]
    [InlineData(6,6,Direction.Up,6,7)]
    [InlineData(10,5,Direction.Down,10,4)]
    [InlineData(0,0,Direction.Left,0,0)]

    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int xexpected, int yexpected)
    {
        var map = new SmallSquareMap(20);
        var p = new Point(x, y);
        var result = map.Next(p, direction);
        var expected = new Point(xexpected, yexpected);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    [InlineData(6, 6, Direction.Up, 7, 7)]
    [InlineData(10, 5, Direction.Down, 9, 4)]
    [InlineData(0, 0, Direction.Left, 0, 0)]

    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int xexpected, int yexpected)
    {
        var map = new SmallSquareMap(20);
        var p = new Point(x, y);
        var result = map.NextDiagonal(p, direction);
        var expected = new Point(xexpected, yexpected);

        Assert.Equal(expected, result);
    }
}
