using AutoResetEvent autoResetEvent = new AutoResetEvent(false);

// Worker thread

for (int i = 0; i < 3; i++)
{
    Thread thread = new Thread(Work);
    thread.Name = $"Thread-{i + 1}";
    thread.Start();
}

// Producer thread
while (true)
{
    var input = Console.ReadLine() ?? "";

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
        Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for the signal");
        autoResetEvent.WaitOne();
        Console.WriteLine($"{Thread.CurrentThread.Name} is working");
        Thread.Sleep(5000);
        Console.WriteLine($"{Thread.CurrentThread.Name} finished its work");
    }
}