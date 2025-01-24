Queue<string?> requests = new Queue<string?>();
const int maxseats = 10;
int availableSeats = maxseats;

object requestsLock = new object();

// Start the request queue monitoring thread
Thread processorThread = new Thread(StartProcesses);
processorThread.Start();

Console.WriteLine("Server is running. \r\nType 'b' to book a ticket. \r\nType 'c' to cancel. \r\nType 'exit' to stop.");

// Enqueue the requests
while (true)
{
    string? input = Console.ReadLine();
    if (input?.ToLower() == "exit")
    {
        break;
    }

    requests.Enqueue(input);
}

// Monitor
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

// Process the request
void ProcessInput(string? input)
{
    // Simulate processing time
    //Thread.Sleep(5000);

    // These 2 locks function as if they were only one lock because they are using
    // the same lock object
    if (input == "b")
    {
        lock (requestsLock)
        {
            if (availableSeats > 0)
            {
                availableSeats--;
                Console.WriteLine();
                Console.WriteLine($"One seat was booked. {availableSeats} seats are still available.");
            }
            else
            {
                Console.WriteLine("There's no seats available.");
            }
        }
    }
    else if (input == "c")
    {
        lock (requestsLock)
        {
            if (availableSeats < maxseats)
            {
                availableSeats++;
                Console.WriteLine();
                Console.WriteLine($"One seat was released. {availableSeats} seats are available.");
            }
            else
            {
                Console.WriteLine("There's no booked seat to cancel.");
            }
        }
    }
    else
    {
        Console.WriteLine("Input Error");
    }
}