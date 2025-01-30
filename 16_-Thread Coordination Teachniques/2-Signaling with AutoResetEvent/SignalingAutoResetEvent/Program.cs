using AutoResetEvent autoResetEvent = new AutoResetEvent(false);

string input = string.Empty;

// Worker thread

Thread thread = new Thread(Work);
thread.Name = "Worker thread";
thread.Start();

// Producer thread
while (true)
{
    input = Console.ReadLine() ?? "";

    if (input == "go")
    {
        autoResetEvent.Set();
        //Console.WriteLine("The signal is ON");
    }
}

// Work of the worker thread
void Work()
{
    while (true)
    {
        Console.WriteLine("Working thread is waiting for the signal");
        autoResetEvent.WaitOne();
        Console.WriteLine("Working thread is working");
        Thread.Sleep(5000);
        Console.WriteLine("Working thread finished its work");
    }
}