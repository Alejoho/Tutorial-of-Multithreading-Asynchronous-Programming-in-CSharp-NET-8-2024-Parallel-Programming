namespace AsyncAndAwaitBasicSyntax2;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Start");
        Console.WriteLine("1. Current thread: {0}", Thread.CurrentThread.ManagedThreadId);

        string data = await FetchDataAsync();

        Console.WriteLine($"The result was: {data}");
        Console.WriteLine("2. Current thread: {0}", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("End");
    }

    static async Task<string> FetchDataAsync()
    {
        Console.WriteLine("Starting to work");
        Console.WriteLine("3. Current thread: {0}", Thread.CurrentThread.ManagedThreadId);

        await Task.Delay(4000);

        Console.WriteLine("Finishing work");
        Console.WriteLine("4. Current thread: {0}", Thread.CurrentThread.ManagedThreadId);

        return "DATA";
    }
}