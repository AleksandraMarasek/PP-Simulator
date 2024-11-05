using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1 ;

    public string Name
    {
        get => _name;
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
            //przed walidatorami
            //string trimmed = value.Trim();

            //if (trimmed.Length < 3) 
                //trimmed = trimmed.PadRight(3,'#');

            //if (trimmed.Length > 25)
                //trimmed = trimmed.Substring(0, 25).TrimEnd();

            //trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);
            
            //_name = trimmed;
        }
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);     //value < 1 ? 1 : value > 10 ? 10 : value;
        
    }

      
    public Creature() { }
    public Creature(string name, int level =1)
    {
        Name = name;
        Level = level;
    }

    public abstract int Power { get; } 
    
    public abstract void SayHi();
    public abstract string Info { get; }
    
    public void Upgrade()
        {

            if (_level < 10)
                _level++;
            //else
                //Console.WriteLine("Maximum level reached. You can't upgrade it anymore.");
        
        }


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
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}

