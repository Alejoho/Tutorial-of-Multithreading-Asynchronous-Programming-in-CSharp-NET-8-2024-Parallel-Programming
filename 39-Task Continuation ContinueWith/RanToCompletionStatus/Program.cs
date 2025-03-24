await Task.Run(
        () =>
        {
            DateTime date = DateTime.Now;
            Console.WriteLine("processing");
            throw new Exception("Expected ex");
            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                    ? "afternoon"
                    : "morning";
        })
    .ContinueWith(
        antecedent =>
        {
            if (antecedent.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine($"Good {antecedent.Result}!");
                Console.WriteLine($"And how are you this fine {antecedent.Result}?");
            }
            else if (antecedent.Status == TaskStatus.Faulted)
            {
                Console.WriteLine(antecedent.Exception!.GetBaseException().Message);
            }
        });

Console.WriteLine("End");