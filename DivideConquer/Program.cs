using System.Diagnostics;

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int sum = 0;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

foreach (var num in array)
{
    Thread.Sleep(100);
    sum += num;
}

stopwatch.Stop();

Console.WriteLine($"The sum is {sum}");
Console.WriteLine($"The time it takes: {stopwatch.Elapsed.TotalMilliseconds}");

Console.ReadLine();