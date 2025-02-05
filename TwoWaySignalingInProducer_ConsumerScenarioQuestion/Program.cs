Queue<int> queue = new Queue<int>();

object lockObj = new object();

const int count = 3;

AutoResetEvent autoResetEvent = new AutoResetEvent(true);
ManualResetEvent manualResetEvent = new ManualResetEvent(false);

for (int i = 1; i <= count; i++)
{
    Thread thread = new Thread(ProcessQueue);
    thread.Name = $"T-{i}";
    thread.Start();
}

while (true)
{
    autoResetEvent.WaitOne();

    Console.WriteLine("Main thread start creating items.");

    for (int i = 1; i <= count; i++)
    {
        queue.Enqueue(i);
        Console.WriteLine($"{queue.Count} items in the queue.");
    }

    Console.WriteLine($"Write 'p' to start processing.");
/*
    while (Console.ReadLine() != signal)
    {
        Console.WriteLine($"Please, write {signal} to start processing.");
    }
*/
    Thread.Sleep(30);

    manualResetEvent.Set();
    //manualResetEvent.Reset();
}

// If I don't put a time sleep, sometimes the threads are so fast that one
// can actually make a dequeue over the queue when this is already empty

void ProcessQueue()
{
    while (true)
    {
        manualResetEvent.WaitOne();

        if (queue.TryDequeue(out int item))
            Console.WriteLine($"Item {item} processed");

        Thread.Sleep(200);

        if (queue.Count == 0)
        {
            manualResetEvent.Reset();
            autoResetEvent.Set();
        }
    }
}