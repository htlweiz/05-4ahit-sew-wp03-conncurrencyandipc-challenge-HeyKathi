using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

       // TODO
        List<Producer> producer = new List<Producer> ();
        ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>(); 
        for (int i = 0; i < 5; i++)
        {
            Producer p = new Producer(i, concurrentQueue);
            producer.Add(p);
        }

        Consumer consumer = new Consumer(concurrentQueue);

        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        
        // TODO
        while(concurrentQueue.Count() < 50)
        {
            Thread.Sleep(1000);
        }

        // Alle Producer stoppen
       

        // Consumer stoppen
       
       
    }
}
