using ObjectCancellationMechanism;

CancellableObject cancellableObject = new CancellableObject();

CancellationTokenSource cts = new CancellationTokenSource();

cts.Token.Register(cancellableObject.CancelProcess);

Task task = new Task(cancellableObject.Work);
task.Start();

Console.WriteLine("Press 'C' to cancel");
if (Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() == "C")
    cts.Cancel();

Console.ReadLine();