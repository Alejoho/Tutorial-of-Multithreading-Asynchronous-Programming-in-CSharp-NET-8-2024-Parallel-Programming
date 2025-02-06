const int amountOfThreads = 3;
const int amountOfItems = 10;

Queue<int> queue = new Queue<int>();

int threadsCompleted = 0;

object countLock = new object();

using AutoResetEvent producerEvent = new AutoResetEvent(true);
using SemaphoreSlim consumerSemaphore = new SemaphoreSlim(0, 3);

for (int i = 1; i <= amountOfThreads; i++)
{
    Thread thread = new Thread(Consume);
    thread.Name = $"Consumer {i}";
    thread.Start();
}

// Producer
while (true)
{
    producerEvent.WaitOne();

    Console.WriteLine("Press 'p' to produce.");

    if (Console.ReadLine() == "p")
    {
        for (int i = 1; i <= amountOfItems; i++)
        {
            queue.Enqueue(i);
            Console.WriteLine($"Produced: {i}");
        }

        consumerSemaphore.Release(amountOfThreads);
    }
}

// Consumer
void Consume()
{
    while (true)
    {
        consumerSemaphore.Wait();

        while (queue.TryDequeue(out int item))
        {
            Console.WriteLine($"Consumed: {item} from thread: {Thread.CurrentThread.Name}");
            Thread.Sleep(500);
        }

        lock (countLock)
        {
            threadsCompleted++;
            if (threadsCompleted == amountOfThreads)
            {
                threadsCompleted = 0;
                producerEvent.Set();
                Console.WriteLine("******************************");
                Console.WriteLine("******** More Please! ********");
                Console.WriteLine("******************************");
            }
        }
    }
}