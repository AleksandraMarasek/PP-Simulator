using Simulator.Maps;
using System.Diagnostics;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        lab5a();
        lab5b();
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

    static void lab5b()
    {
        Console.WriteLine("\nSprawdzanie poprawności rozmiarów map:");
        int[] sizes = [4, 5, 8, 16, 21, 40];        // błąd, 5x5, 8x8, 16x16, błąd, błąd
        foreach (int s in sizes)
        {
            try
            {
                Maps.SmallSquareMap m1 = new(s);
                Console.WriteLine($"map size:{s}x{s}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        Maps.SmallSquareMap m2 = new(10);

        Console.WriteLine("\nSprawdzanie czy dany punkt istnieje na mapie:");
        Point[] points = [new(0, 0), new(2, 1), new(1, 3), new(6, 14), new(-1, 8)];     //true, true, true, false, false
        foreach (Point p in points) { Console.WriteLine($"{m2.Exist(p)}"); }

        Console.WriteLine("\nSprawdzanie poprawności metod Next i NextDiagonal:");
        Point p1 = new(1, 0);
        Console.WriteLine("\np1=(1,0)");
        Console.WriteLine($"{m2.Next(p1,Direction.Left)}");     // (0, 0)
        Console.WriteLine($"{m2.Next(p1, Direction.Right)}");       // (2, 0)
        Console.WriteLine($"{m2.Next(p1, Direction.Up)}");      // (1, 1)
        Console.WriteLine($"{m2.Next(p1, Direction.Down)}");        // (1, 0)

        Point p2 = new(5, 5);
        Console.WriteLine("\np2=(5,5)");
        Console.WriteLine($"{m2.Next(p2, Direction.Left)}");        // (4,5)
        Console.WriteLine($"{m2.Next(p2, Direction.Right)}");       // (6,5)
        Console.WriteLine($"{m2.Next(p2, Direction.Up)}");      // (5,6)
        Console.WriteLine($"{m2.Next(p2, Direction.Down)}");        // (5,4)

        Point p3 = new(9,10);
        Console.WriteLine("\np3=(9,10)");
        Console.WriteLine($"{m2.NextDiagonal(p3, Direction.Left)}");        // (9,10)
        Console.WriteLine($"{m2.NextDiagonal(p3, Direction.Right)}");       // (9,10)
        Console.WriteLine($"{m2.NextDiagonal(p3, Direction.Up)}");      // (9,10)
        Console.WriteLine($"{m2.NextDiagonal(p3, Direction.Down)}");        // (8,9)

    }
}




