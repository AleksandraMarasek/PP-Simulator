using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");

        _fields = new List<Creature>?[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                _fields[i, j] = new List<Creature>();
            }
        }
    }
    public override void Add(Creature creature, Point position)
    {
        _fields[position.X,position.Y]?.Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y]?.Remove(creature);
    }

    public override List<Creature> At(int x, int y)
    {
        return _fields[x, y];
    }

    public override List<Creature> At(Point p)
    {
        return _fields[p.X, p.Y];
    }


    


    


}