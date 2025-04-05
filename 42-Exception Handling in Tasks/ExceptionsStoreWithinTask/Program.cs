using System.Text.Json;

using HttpClient client = new HttpClient();


// This line of code throws an exception because the url doesn't exist
Task<string> task1 = client.GetStringAsync("https://pokeapi123.co/api/v2/pokemon");
Task task2 = task1.ContinueWith(t =>
{
    Console.WriteLine("Continuing with the 2nd task");

    // Also this line throws another exception because the antecedent was faulty
    string result = t.Result;
    JsonDocument doc = JsonDocument.Parse(result);
    JsonElement root = doc.RootElement;
    JsonElement results = root.GetProperty("results");
    JsonElement firstPokemon = results[0];

    Console.WriteLine($"First pokemon name: {firstPokemon.GetProperty("name")}");
    Console.WriteLine($"First pokemon url: {firstPokemon.GetProperty("url")}");
});

Thread.Sleep(1000);
Console.WriteLine(task1.Status);
Console.WriteLine(task2.Status);

Console.WriteLine("\nExceptions of the 1st task\n");

if (task1.IsFaulted && task1.Exception != null)
{
    foreach (Exception exception in task1.Exception.InnerExceptions)
    {
        Console.WriteLine(exception.Message);
    }
}

Console.WriteLine("\n\nInner Exceptions\n");
Exception? ex = task2.Exception;
int tab = 0;

while (ex != null)
{
    for (int i = 0; i < tab; i++)
    {
        Console.Write("\t");
    }

    Console.Write("-> ");
    Console.WriteLine(ex.Message);
    ex = ex.InnerException;
    tab++;
}


Console.WriteLine("This is the end of the program");
Console.ReadLine();