﻿using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    private string _name = "Unknown";
    private int _level = 1 ;

    public string Name
    {
        get => _name;
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
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
            if (_level < 10) _level++;
        }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (!map.Exist(position)) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds");

        Map = map;
        Position = position;
        Map.Add(this, position);
    }

    public string Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("The creature can't move while not being on the map.");
        var move= Map.Next(Position,direction);

        Map.Move(this, Position, move);
        Position = move;

        return $"{Name} goes {direction.ToString().ToLower()}.";
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}

