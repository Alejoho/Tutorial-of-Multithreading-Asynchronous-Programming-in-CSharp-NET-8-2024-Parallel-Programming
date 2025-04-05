namespace AsyncAndAwaitBasicSyntax2;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Start");
        string data = await FetchDataAsync();
        Console.WriteLine($"The result was: {data}");
        Console.WriteLine("End");
    }

    static async Task<string> FetchDataAsync()
    {
        Console.WriteLine("Starting to work");
        await Task.Delay(4000);
        Console.WriteLine("Finishing work");
        return "DATA";
    }
}