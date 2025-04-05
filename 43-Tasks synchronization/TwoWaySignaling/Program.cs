const int amountOfTasks = 3;
const int amountOfItems = 10;

Queue<int> queue = new Queue<int>();

int tasksCompleted = 0;

object countLock = new object();

using AutoResetEvent producerEvent = new AutoResetEvent(true);
using SemaphoreSlim consumerSemaphore = new SemaphoreSlim(0, 3);

for (int i = 1; i <= amountOfTasks; i++)
{
    Task task = new Task(Consume);
    task.Start();
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

        consumerSemaphore.Release(amountOfTasks);
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
            Console.WriteLine($"Consumed: {item} from task: {Task.CurrentId}");
            Task.Delay(500).Wait();
        }

        lock (countLock)
        {
            tasksCompleted++;
            if (tasksCompleted == amountOfTasks)
            {
                tasksCompleted = 0;
                producerEvent.Set();
                Console.WriteLine("******************************");
                Console.WriteLine("******** More Please! ********");
                Console.WriteLine("******************************");
            }
        }
    }
}