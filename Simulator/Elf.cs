using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCtr = 0;

    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    
    public Elf() : base() { }
    public Elf(string name, int level = 1, int agility =1) : base(name, level) 
    {
        Agility = agility;
    }
    
    
    public override int Power => Level * 8 + agility * 2;
    public override string Info => $"{Name} [{Level}][{Agility}]";

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCtr++;

        if (singCtr % 3 == 0 && agility < 10) agility++;
    }

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );
}
