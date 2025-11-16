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
        List<Producer> producer = new List<Producer>();
        ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
        for (int i = 0; i < 5; i++)
        {
            Producer p = new Producer(i, concurrentQueue);
            producer.Add(p);
        }

        Consumer consumer = new Consumer(concurrentQueue);

        Console.WriteLine("Producer und Consumer gestartet...\n");

        // TODO

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        while (concurrentQueue.Count <= 50)
        {
            Console.WriteLine($"Queue-Füllmenge: {concurrentQueue.Count} Einträge");
            Thread.Sleep(1000);
        }

        Console.WriteLine("\nQueue hat mehr als 50 Einträge! Programm wird beendet...\n");

        // Alle Producer stoppen
        foreach (var p in producer)
        {
            p.Stop();
        }

        // Consumer stoppen
        consumer.Stop();

        // Auf Abschluss der Threads warten
        foreach (var p in producer)
        {
            p.JoinThread();
        }
        consumer.JoinThread();

        Console.WriteLine($"Programm beendet. Endfüllmenge: {concurrentQueue.Count} Einträge.");
        Console.WriteLine("==========================================");
    }
}