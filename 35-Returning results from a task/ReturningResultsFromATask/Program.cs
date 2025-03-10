// See https://aka.ms/new-console-template for more information

//var t = Task.Run(() => Work(5));

Task<int> t = new Task<int>(() => Work(5));
t.Start();

Console.WriteLine("Main thread");

Console.WriteLine($"The result from the work is {t.Result}");

Console.WriteLine("Result returned");

Console.ReadLine();


int Work(int iterations)
{
    Console.WriteLine("Work started");

    Thread.Sleep(5000);
    int output = 0;

    for (int i = 0; i < iterations; i++)
    {
        output += i;
    }

    return output;
}