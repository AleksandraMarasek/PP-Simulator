using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Xunit;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5,1,15,5)]
    [InlineData(1,10,15,10)]
    [InlineData(20,10,15,15)]
    [InlineData(5,5,15,5)]

    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("name", 3, 6, '_', "Name")]
    [InlineData("",5,15,'_',"_____")]
    [InlineData("too short",15,20,'#',"Too short######")]
    [InlineData("name that is too long",3,10,'-',"Name that")]
    [InlineData("         name      ",3,10,'-',"Name")]
    [InlineData("abc                            def",5,10,'*',"Abc**")]

    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }


}
