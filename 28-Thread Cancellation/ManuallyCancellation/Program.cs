var cancelThread = false;

var thread = new Thread(Work);
thread.Start();

Console.WriteLine("To cancel press 'c'");
var input = Console.ReadLine();

if (input == "c") cancelThread = true;

thread.Join();
Console.ReadLine();

void Work()
{
    Console.WriteLine("The thread started doing its work.");

    for (var i = 0; i < 10000; i++)
    {
        if (cancelThread)
        {
            Console.WriteLine($"User requested cancelation at iteration {i}");
            return;
        }

        Thread.SpinWait(300000);
    }

    Console.WriteLine("Work is done");
}