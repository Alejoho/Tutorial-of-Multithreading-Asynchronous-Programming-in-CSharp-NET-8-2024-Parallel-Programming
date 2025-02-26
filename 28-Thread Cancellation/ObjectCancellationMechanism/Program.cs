using ObjectCancellationMechanism;

CancellableObject cancellableObject = new CancellableObject();

CancellationTokenSource cts = new CancellationTokenSource();

cts.Token.Register(cancellableObject.CancelProcess);

Thread thread = new Thread(cancellableObject.Work);
thread.Start();

Console.WriteLine("Press 'C' to cancel");
if (Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() == "C")
    cts.Cancel();

Console.ReadLine();