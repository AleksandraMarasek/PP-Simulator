﻿using Simulator.Maps;


namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    
    public required string Description
    {
        get => _description;
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#');
            
            //string valueTrimmed = value.Trim();

            //if (valueTrimmed.Length < 3)
                //valueTrimmed = valueTrimmed.PadRight(3, '#');

            //if (valueTrimmed.Length > 15)
                //valueTrimmed = valueTrimmed.Substring(0, 15).TrimEnd();

            //if (valueTrimmed.Length > 0)
                //valueTrimmed = char.ToUpper(valueTrimmed[0]) + valueTrimmed.Substring(1).ToLower();

            //_description = valueTrimmed;
        }
    }
   

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public object Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Go(Direction direction)
    {
        throw new NotImplementedException();
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        throw new NotImplementedException();
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
