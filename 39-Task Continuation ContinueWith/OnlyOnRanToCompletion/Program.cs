var task = Task.Run(
    () =>
    {
        DateTime date = DateTime.Now;
        Console.WriteLine("Processing");
        //throw new Exception("Expected exception");
        return date.Hour > 17
            ? "evening"
            : date.Hour > 12
                ? "afternoon"
                : "morning";
    });
task.ContinueWith(
    antecedent =>
    {
        Console.WriteLine($"Good {antecedent.Result}!");
        Console.WriteLine($"And how are you this fine {antecedent.Result}?");
    }, TaskContinuationOptions.OnlyOnRanToCompletion);

Console.WriteLine("End");
Console.ReadLine();