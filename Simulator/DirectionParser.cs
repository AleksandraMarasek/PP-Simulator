using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directionsList = new List<Direction>();

        foreach (char ch in input.ToUpper())
        {
            switch (ch)
            {
                case 'U':
                    directionsList.Add(Direction.Up);
                    break;
                case 'R':
                    directionsList.Add(Direction.Right);
                    break;
                case 'D':
                    directionsList.Add(Direction.Down);
                    break;
                case 'L':
                    directionsList.Add(Direction.Left);
                    break;
                default:
                    // Ignoruj inne znaki
                    break;
            }
        }
        
        return directionsList;
    }
}

