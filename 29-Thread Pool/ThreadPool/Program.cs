ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxIOThreads);

Console.WriteLine($"Max worker threads: {maxWorkerThreads}");
Console.WriteLine($"Max IO threads: {maxIOThreads}");

ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableIOThreads);

Console.WriteLine($"Active worker threads: {maxWorkerThreads - availableWorkerThreads}");
Console.WriteLine($"Active IO threads: {maxIOThreads - availableIOThreads}");

ThreadPool.QueueUserWorkItem(Work, "Alejo");

Thread.Sleep(4000);

Console.WriteLine("Main thread finished");

void Work(object? data)
{
    string msg = (string)data;

    Console.WriteLine("Processing");
    Console.WriteLine($"This thread is ThreadPool thread: {Thread.CurrentThread.IsThreadPoolThread}");
    Thread.Sleep(2000);
    Console.WriteLine($"Output: {msg}");
}