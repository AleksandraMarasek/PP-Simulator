using System.Diagnostics;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        lab5a();
    }


    
    static void lab5a()
    {
        //Point p = new(10, 25);
        //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

        Console.WriteLine("Poprawne tworzenie prostokątów:");
        Rectangle r1 = new(13, 12, 17, 20);     // (13,12):(17,20)
        Console.WriteLine(r1);
        Rectangle r2 = new(3, 8, 2, 4);     // (2,4):(3,8) ,współrzędne powinny zamienić się miejscami
        Console.WriteLine(r2);


        Console.WriteLine("\nKonstruktor wykorzystujący Point:");
        Point p1 = new(1, 2);
        Point p2 = new(2, 4);
        Rectangle r3 = new(p1, p2);     // (1,2):(2,4)
        Console.WriteLine(r3);
        Rectangle r4 = new(p2, p1);     // (1,2):(2,4)
        Console.WriteLine(r4);


        Console.WriteLine("\nWspółrzędne współliniowe:");
        try
        {
            Rectangle r5 = new(0, 1, 0, 5);
            Console.WriteLine(r5);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);      //"nie chcemy "chudych" prostokątów"
        }

        Rectangle r6 = new(0, 0, 10, 10);
        Console.Write("\nSprawdzanie, czy punkt znajduje się w prostokącie:\n");
        Point[] punkty =
            [
            new (4,6+1), new(-1,3), new(11,11), new(0,0), new(6+5,4)       //True,False,False,True,False
            ];
        foreach (Point i in punkty)
        {
            Console.WriteLine($"{r6.Contains(i)}");
        }
    }
}


