using System;
using System.Diagnostics;
using System.Threading;
public static class Program
{
    static int steps;
    static int chews;
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
        //sw.Start();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Left");
            Console.WriteLine("Right");
            //Thread.Sleep(10);
            steps += 1;
            Console.WriteLine("Steps: " + steps + "Chews: "+ chews);
        }
    }
    public static void ChewGum()
    {
        for (int i = 0; i < 100; i++)
        {
            chews += 1;
            Console.WriteLine("Open jaws");
            //Thread.Sleep(1000);
            Console.WriteLine("Close jaws");
            //Thread.Sleep(1000);
            Console.WriteLine("Chews: " + chews + " Steps: "+ steps);
        }
    }
    public static void Main()
    {
        Console.WriteLine("Starting ...");
        var walk = new Thread(new ThreadStart(Walk));
        var chew = new Thread(new ThreadStart(ChewGum));
        walk.Start();
        chew.Start();
        //heart.Start();

        Console.ReadKey();
    }
}