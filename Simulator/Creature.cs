using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }

    //public string Info => $"{Name} [{Level}]";
    public Creature()
    {
        Name = "Unknown";
        Level = 1;
    }
    

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }


    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");


    public void Info() => Console.WriteLine($"{Name} [{Level}]");




}

