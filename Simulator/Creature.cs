using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public class Creature
{
    private string _name = "Unknown";
    private int _level = 1 ;

    public string Name
    {
        get => _name;
        init
        {
            if (_name != "Unknown")
                throw new InvalidOperationException("Name can only be set once.");

            string trimmed = value.Trim();

            if (trimmed.Length < 3) 
                trimmed = trimmed.PadRight(3,'#');

            if (trimmed.Length > 25)
                trimmed = trimmed.Substring(0, 25).TrimEnd();

            trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);
            
            _name = trimmed;
        }
    }

    public int Level
    {
        get => _level;
        init
        {
            _level = value < 1 ? 1 : value > 10 ? 10 : value;
        }
    }
   
    public Creature() { }

    public Creature(string name, int level =1)
    {
        Name = name;
        Level = level;
    }

    public string Info => $"{Name} [{Level}]";
   
    public void Upgrade()
    {

        if (_level < 10)
            _level++;
        else if (_level > 10)
        {
            Console.WriteLine("Maximum level reached. You can't upgrade it anymore.");
        }
    }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public void Go(Direction direction) 
    {
        string directionString = direction.ToString().ToLower();
        
        Console.WriteLine($"{Name} goes {directionString}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        Go(directions); 
    }

}

