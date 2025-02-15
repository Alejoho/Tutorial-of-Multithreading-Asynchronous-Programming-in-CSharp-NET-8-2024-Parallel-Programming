// See https://aka.ms/new-console-template for more information

Console.WriteLine("Start");

var number = 0;
Console.WriteLine($"number = {number}");

var thread = new Thread(Work) { Name = "Thread 1" };
thread.Start();

thread.Join();
Console.WriteLine($"number = {number}");
Console.WriteLine("End");

void Work()
{
    Console.WriteLine($"{Thread.CurrentThread.Name} is starting to work.");
    SpinWait.SpinUntil(
        () => ++number > 1000
        , TimeSpan.FromMilliseconds(200)
    );
    Console.WriteLine($"{Thread.CurrentThread.Name} is finishing to work.");
}