using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(3,3,9,9,"(3,3):(9,9)")]
    [InlineData(4,-1,9,0, "(4,-1):(9,0)")]
    [InlineData(10,10,1,1, "(1,1):(10,10)")]

    public void Rectangle_ShouldCreateCorrectRectangle(int x1, int y1, int x2, int y2, string expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);

        var results = rectangle.ToString();

        Assert.Equal(expected, results);
    }


    [Theory]
    [InlineData(0,10,0,12)]
    [InlineData(5,10,5,20)]
    [InlineData(0,0,0,1)]
    [InlineData(5,5,5,5)]

    public void Rectangle_ShouldThrowAArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }


    [Theory]
    [InlineData(1,1,7,7,5,5,true)]
    [InlineData(-10,-10,-1,-1,0,0,false)]
    [InlineData(0,0,10,10,0,0,true)]
    [InlineData(0,0,10,10,10,10,true)]
    [InlineData(0,0,10,10,-1,-1,false)]

    public void Rectangle_Contains_ShouldReturnCorrectBool(int x1, int y1, int x2, int y2, int p1, int p2 , bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2,y2);
        var p = new Point(p1, p2);
        var result = rectangle.Contains(p);

        Assert.Equal(expected, result);
    }

}
