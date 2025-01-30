Console.WriteLine("Server is running. Type 'exit' to stop.");

Queue<string> requests = new Queue<string>();

SemaphoreSlim semaphore = new SemaphoreSlim(3, 3);

Thread processorThread = new Thread(StartProcesses);
processorThread.Start();

while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        break;
    }

    requests.Enqueue(input);
}

void StartProcesses()
{
    while (true)
    {
        string? input;
        if (requests.TryDequeue(out input))
        {
            semaphore.Wait();
            Console.WriteLine($"Available threads {semaphore.CurrentCount}");
            Thread thread = new Thread(() => { ProcessInput(input); });
            thread.Start();
        }
    }
}

void ProcessInput(string? input)
{
    // Simulate processing time
    try
    {
        Thread.Sleep(5000);
        Console.WriteLine($"Processed input: {input}");
    }
    finally
    {
        int previousCount = semaphore.Release();
        Console.WriteLine($"The previous count is {previousCount}");
    }
}