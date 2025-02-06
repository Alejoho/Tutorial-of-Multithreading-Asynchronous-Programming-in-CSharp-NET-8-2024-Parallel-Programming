const int threadAmount = 10;

Queue<int> queue = new Queue<int>();

object lockObj = new object();


AutoResetEvent autoResetEvent = new AutoResetEvent(true);
SemaphoreSlim semaphore = new SemaphoreSlim(0, threadAmount);

for (int i = 1; i <= threadAmount; i++)
{
    Thread thread = new Thread(ProcessQueue);
    thread.Name = $"T-{i}";
    thread.Start();
}

while (true)
{
    autoResetEvent.WaitOne();

    Console.WriteLine("Main thread start creating items.");

    for (int i = 1; i <= threadAmount; i++)
    {
        Thread.Sleep(500);
        queue.Enqueue(i);
        Console.WriteLine($"{i} items in the queue.");
    }

    Console.WriteLine($"Write 'p' to start processing.");

    while (Console.ReadLine() != "p")
    {
        Console.WriteLine($"Please, write 'p' to start processing.");
    }

    Thread.Sleep(1000);

    semaphore.Release(threadAmount);
}

// If I don't put a time sleep, sometimes the threads are so fast that one
// can actually make a dequeue over the queue when this is already empty

void ProcessQueue()
{
    while (true)
    {
        semaphore.Wait();

        if (queue.TryDequeue(out int item))
            Console.WriteLine($"Item {item} processed");

        Thread.Sleep(200);

        if (queue.Count == 0)
        {
            autoResetEvent.Set();
        }
    }
}