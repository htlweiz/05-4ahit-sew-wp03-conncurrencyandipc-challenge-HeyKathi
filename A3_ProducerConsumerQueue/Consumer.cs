using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

public class Consumer
{
    private volatile bool shouldStop = false;
    private Thread consumerThread;
    private int sum = 0;

    public Consumer(ConcurrentQueue<int> concurrentQueue)
    {

        // Thread im Konstruktor starten
        consumerThread = new Thread(() => ConsumeNumbers(concurrentQueue));
        consumerThread.Start();
    }

    private void ConsumeNumbers(ConcurrentQueue<int> concurrentQueue)
    {
        while (!shouldStop)
        {
            if (concurrentQueue.TryDequeue(out int value))
            {
                sum += value;
                Console.WriteLine($"Consumer {value} | Summe: {sum}");
            }

            Thread.Sleep(250);
        }
    }

    public void Stop()
    {
        shouldStop = true;
    }

    public void JoinThread()
    {
        consumerThread.Join();
    }

    public int GetSum()
    {
        return sum;
    }
}
