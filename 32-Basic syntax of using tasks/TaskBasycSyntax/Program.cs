// Thread thread = new Thread(Work);
// thread.Start();

// Task task = new Task(Work);
// task.Start();

Task.Run(Work);

Console.ReadLine();

void Work()
{
    Console.WriteLine("Working");
    //Thread.Sleep(3000);
    Console.WriteLine($"IsBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
}