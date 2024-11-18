using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Xml.Schema;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    
    public int Size { get; }
    
    public SmallSquareMap(int size)  
    {
        if (size<5 || size>20) throw new ArgumentOutOfRangeException("Zły rozmiar mapy!");
        Size = size;
        _map = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    private readonly Rectangle _map;
    public override bool Exist(Point p) => _map.Contains(p); 

    public override Point Next(Point p, Direction d)
    {

        if (_map.Contains(p.Next(d))) { return p.Next(d); } return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (_map.Contains(p.NextDiagonal(d))) { return p.NextDiagonal(d); } return p;
    }
}