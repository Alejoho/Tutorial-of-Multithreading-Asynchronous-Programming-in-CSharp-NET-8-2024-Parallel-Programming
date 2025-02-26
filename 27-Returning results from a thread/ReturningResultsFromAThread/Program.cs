var lockObj = new object();
string? result = null;

var thread = new Thread(Work);
thread.Start();

thread.Join();

Console.WriteLine($"The result from the worker thread is: {result}");

void Work()
{
    Console.WriteLine("Started doing some work");
    Thread.Sleep(1000);

    lock (lockObj)
    {
        result = "Here is the result";
    }
}