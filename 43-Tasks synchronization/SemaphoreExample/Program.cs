Console.WriteLine("Server is running. Type 'exit' to stop.");

Queue<string> requests = new Queue<string>();

SemaphoreSlim semaphore = new SemaphoreSlim(3, 3);

Task processorTask = new Task(StartProcesses);

processorTask.Start();


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
            Console.WriteLine($"Available tasks {semaphore.CurrentCount}");
            Task.Run(() => { ProcessInput(input); });
        }

        Task.Delay(100).Wait();
    }
}

void ProcessInput(string? input)
{
    // Simulate processing time
    try
    {
        Task.Delay(4000).Wait();
        Console.WriteLine($"Processed input: {input}");
    }
    finally
    {
        Console.WriteLine($"The previous count is {semaphore.Release()}");
    }
}