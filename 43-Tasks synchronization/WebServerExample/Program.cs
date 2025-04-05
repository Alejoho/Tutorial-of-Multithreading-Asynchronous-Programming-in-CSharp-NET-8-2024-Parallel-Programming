Console.WriteLine("Server is running. Type 'exit' to stop.");

Queue<string> requests = new Queue<string>();


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
            Task task = new Task(() => { ProcessInput(input); });
            task.Start();
        }

        Task.Delay(100).Wait();
    }
}

static void ProcessInput(string? input)
{
    // Simulate processing time
    Task.Delay(10000).Wait();
    Console.WriteLine($"Processed input: {input}");
}