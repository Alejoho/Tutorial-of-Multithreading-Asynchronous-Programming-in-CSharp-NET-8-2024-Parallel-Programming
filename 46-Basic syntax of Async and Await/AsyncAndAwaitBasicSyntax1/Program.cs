namespace AsyncAndAwaitBasicSyntax1;

class Program
{
    // Old way
    // static void Main(string[] args)
    // {
    //     Console.WriteLine("Start");
    //     Task.Run(Work).Wait();
    //     Console.WriteLine("End");
    // }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Start");
        await WorkAsync();
        Console.WriteLine("End");
    }

    // Old way
    // static void Work()
    // {
    //     Console.WriteLine("Starting to work");
    //     Task.Delay(3000).Wait();
    //     Console.WriteLine("Finishing work");
    // }

    static async Task WorkAsync()
    {
        Console.WriteLine("Starting to work");
        await Task.Delay(4000);
        Console.WriteLine("Finishing work");
    }
}