Task<DateTime> task = Task.Run(() => DoWork());

var continuations = new List<Task<DateTime>>();
for (int i = 0; i < 5; i++)
{
    task = task.ContinueWith((antecedent, _) => DoWork(), DateTime.Now);
    continuations.Add(task);
}

await task;

foreach (Task<DateTime> continuation in continuations)
{
    DateTime start = (DateTime)continuation.AsyncState!;
    DateTime end = continuation.Result;

    Console.WriteLine($"Task was created at {start.TimeOfDay} and finished at {end.TimeOfDay}.");
}

Console.ReadLine();
return;

DateTime DoWork()
{
    Thread.Sleep(2000);

    return DateTime.Now;
}