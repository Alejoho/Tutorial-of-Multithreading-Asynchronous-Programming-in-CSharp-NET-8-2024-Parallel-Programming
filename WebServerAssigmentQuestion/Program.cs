Console.WriteLine("Server is running. Type 'exit' to stop.");

while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        break;
    }
    ProcessInput(input);
}

static void ProcessInput(string? input)
{
    // Simulate processing time
    Thread.Sleep(5000);
    Console.WriteLine($"Processed input: {input}");
}