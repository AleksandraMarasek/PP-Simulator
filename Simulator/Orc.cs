using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int huntCtr = 0;

    public override char Symbol => 'O';

    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override int Power => Level * 7 + Rage * 3;
    public override string Info => $"{Name} [{Level}][{Rage}]";

    public void Hunt()
    {
        huntCtr++;
        if (huntCtr % 3 == 0 && rage < 10) rage++;
    }



    public override string Greeting()
    {return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";}
}

