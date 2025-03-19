/*
int sum = 0;

var task = Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        Task.Delay(100);
        sum += i;
    }
});

task.Wait();

Console.WriteLine($"The result is: {sum}");
*/

var task = Task.Run(() =>
{
    int sum = 0;

    for (int i = 0; i < 100; i++)
    {
        Task.Delay(100);
        sum += i;
    }

    return sum;
});

Console.WriteLine($"The result is: {task.Result}");

Console.ReadLine();