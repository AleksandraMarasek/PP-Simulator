using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";
    }

    protected override Point NewPosition(Direction direction) => CanFly
         ? Map.Next(Map.Next(Position, direction), direction)
         : Map.NextDiagonal(Position, direction);

}
