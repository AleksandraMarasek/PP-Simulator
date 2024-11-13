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
    
    public abstract string Greeting();
    public abstract string Info { get; }
    
    public void Upgrade()
        {

            if (_level < 10)
                _level++;
            //else
                //Console.WriteLine("Maximum level reached. You can't upgrade it anymore.");
        
        }


    public string Go(Direction direction) => 
        $"{direction.ToString().ToLower()}.";


    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i]= Go(directions[i]);
        }
        return result;
    }

    public string[] Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        return Go(directions); 
    }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}

