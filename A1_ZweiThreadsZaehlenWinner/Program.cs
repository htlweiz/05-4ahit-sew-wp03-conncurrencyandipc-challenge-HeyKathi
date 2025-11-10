using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
    static int threadACount = 0;
    static int threadBCount = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        
        Thread thread1 = new Thread(CountUpThreadA);
        Thread thread2 = new Thread(CountDownThreadB);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

    }
    
    private static void CountUpThreadA()
    {
        for (int i = 1; i == 100; i++)
        {
            threadACount = 1;
            if (threadBCount == threadACount)
            {
                break;
            }
        Thread.Sleep(100);
        }
    }
    
    private static void CountDownThreadB()
    {
        for (int i = 100; i == 1; i--)
        {
            threadBCount = 1;
            if (threadBCount == threadACount)
            {
                break;
            }
            Thread.Sleep(100);
        }
    }
}
