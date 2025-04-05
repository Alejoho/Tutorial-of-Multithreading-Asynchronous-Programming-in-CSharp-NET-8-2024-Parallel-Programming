Console.WriteLine("Start");

Task<int>[] tasks =
[
    Task.Run(() =>
    {
        throw new InvalidOperationException("Invalid Operation");
        return 1;
    }),
    Task.Run(() =>
    {
        throw new ArgumentNullException("Empty", "Argument null");
        return 2;
    }),
    Task.Run(() =>
    {
        throw new Exception("General exception");
        return 3;
    }),
];


var c = Task.WhenAll(tasks).ContinueWith((t) =>
{
    if (t.IsFaulted && t.Exception != null)
    {
        foreach (Exception ex in t.Exception.InnerExceptions)
        {
            Console.WriteLine(ex.Message);
        }
    }
});

var t = Task.WhenAll(tasks);

// Either of these 2 lines will propagate the exceptions of the tasks to the main thread.
var outputs = t.Result;
//t.Wait();


Console.WriteLine("Press a key to exit.");
Console.ReadLine();