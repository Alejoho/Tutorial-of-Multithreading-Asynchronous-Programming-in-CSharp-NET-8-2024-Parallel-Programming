using CancellationTokenSource cancTokenSource = new CancellationTokenSource();

Thread thread = new Thread(Work);
thread.Start(cancTokenSource.Token);

Console.WriteLine("To cancel press 'c'");
var input = Console.ReadLine();

if (input == "c") cancTokenSource.Cancel();

thread.Join();
Console.ReadLine();

void Work(object? boxedToken)
{
    CancellationToken token = (CancellationToken)boxedToken;

    Console.WriteLine("The thread started doing its work.");

    for (var i = 0; i < 10000; i++)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine($"User requested cancellation at iteration {i}");
            return;
        }

        Thread.SpinWait(300000);
    }

    Console.WriteLine("Work is done");
}