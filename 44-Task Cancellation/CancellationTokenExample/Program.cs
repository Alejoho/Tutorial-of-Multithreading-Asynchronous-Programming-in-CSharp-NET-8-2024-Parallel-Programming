using CancellationTokenSource cancTokenSource = new CancellationTokenSource();
CancellationToken cancellationToken = cancTokenSource.Token;

WorkClass workClass = new WorkClass();


Task task = new Task(workClass.WorkMethod, cancellationToken);
task.Start();

Console.WriteLine(task.Status);

Console.WriteLine("To cancel press 'c'");
Console.WriteLine(task.Status);
if (Console.ReadKey().KeyChar == 'c') cancTokenSource.Cancel();

//task.Wait();
Thread.Sleep(3000);

Console.WriteLine(task.Status);
Console.ReadLine();
return;

public class WorkClass
{
    public void WorkMethod(object? boxedToken)
    {
        CancellationToken token = (CancellationToken)boxedToken;

        Console.WriteLine("The thread started doing its work.");

        for (var i = 0; i < 10; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"User requested cancellation at iteration {i}");
                // After this line status is "RanToCompletion"
                // break;

                // After this line status is "Faulted"
                // throw new OperationCanceledException();

                // After this line status is "Faulted"
                token.ThrowIfCancellationRequested();
            }

            Console.WriteLine($"Iteration at {DateTime.Now.TimeOfDay}");

            Thread.Sleep(1000);
        }

        Console.WriteLine("Work is done");
    }
}