bool cancelThread = false;

Task task = new Task(Work);
task.Start();

Console.WriteLine("To cancel press 'c'");
string? input = Console.ReadLine();

if (input == "c") cancelThread = true;

task.Wait();
Console.ReadLine();
return;

void Work()
{
    Console.WriteLine("The thread started doing its work.");

    for (var i = 0; i < 10000; i++)
    {
        if (cancelThread)
        {
            Console.WriteLine($"User requested cancellation at iteration {i}");
            return;
        }

        Console.WriteLine($"Iteration at {DateTime.Now.TimeOfDay}");
        Thread.Sleep(1000);
    }

    Console.WriteLine("Work is done");
}