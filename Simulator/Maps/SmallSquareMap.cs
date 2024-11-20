using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Xml.Schema;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    
    public int Size { get; }

    
    public SmallSquareMap(int size)  : base(size,size)
    {
        
        
    }
    
    //public override bool Exist(Point p) => _map.Contains(p); 

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return Exist(moved) ? moved : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return Exist(moved) ? moved : p;
    }
}