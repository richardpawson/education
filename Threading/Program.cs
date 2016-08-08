using System;
using System.Threading;

public static class MyProgram
{
    public static void HeartBeat()
    {
        while(true)
        {
            Console.WriteLine("Beat");
            Thread.Sleep(100);
        }

    }

    public static void Walk()
    {
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine("Left");
            Thread.Sleep(500);
            Console.WriteLine("Right");
            Thread.Sleep(500);
        }
    }

    public static void ChewGum()
    {
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine("Open jaws");
            Thread.Sleep(1000);
            Console.WriteLine("Close jaws");
            Thread.Sleep(1000);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Starting ...");

        var walk = new Thread(new ThreadStart(Walk));
        var chew = new Thread(new ThreadStart(ChewGum));
        var heart = new Thread(new ThreadStart(HeartBeat));

        walk.Start();
        chew.Start();
        heart.Start();

        Console.ReadKey();
    }
}