for (int i = 0; i < 10; i++)
{
    Thread thread = new Thread(Work);
    thread.Name = $"Thread {i}";
    if (i % 2 == 0)
    {
        thread.Priority = ThreadPriority.Highest;
    }

    if(i==4)
    {
        thread.IsBackground = true;
    }
    thread.Start();
}

Thread.CurrentThread.Name = "Master Thread";
Work();

void Work()
{
    Console.WriteLine($"{Thread.CurrentThread.Name} started working");
    Thread.Sleep(10000);
    Console.WriteLine($"{Thread.CurrentThread.Name} finished working");
}