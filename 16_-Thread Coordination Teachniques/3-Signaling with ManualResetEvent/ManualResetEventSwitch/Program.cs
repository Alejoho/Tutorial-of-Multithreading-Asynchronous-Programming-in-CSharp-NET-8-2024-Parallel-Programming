using ManualResetEventSlim manualResetEvent = new ManualResetEventSlim(false);

for (int i = 1; i <= 3; i++)
{
    Thread thread = new Thread(Work);
    thread.Name = $"Thread {i}";
    thread.Start();
}

while (true)
{
    Console.WriteLine("Press enter to send the signal.");
    Console.ReadLine();

    manualResetEvent.Set();

    Console.WriteLine("Press enter to stop sending the signal.");
    Console.ReadLine();

    manualResetEvent.Reset();
}

void Work()
{
    while (true)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for the signal.");

        manualResetEvent.Wait();

        Console.WriteLine($"{Thread.CurrentThread.Name} has been released.");

        Thread.Sleep(3000);

        Console.WriteLine($"{Thread.CurrentThread.Name} has finished.");
    }
}