Console.WriteLine("Server is running. Type 'exit' to stop.");

Queue<string> requests = new Queue<string>();

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
            Thread thread = new Thread(() => { ProcessInput(input); });
            thread.Start();
        }
    }
}

static void ProcessInput(string? input)
{
    // Simulate processing time
    Thread.Sleep(10000);
    Console.WriteLine($"Processed input: {input}");
}