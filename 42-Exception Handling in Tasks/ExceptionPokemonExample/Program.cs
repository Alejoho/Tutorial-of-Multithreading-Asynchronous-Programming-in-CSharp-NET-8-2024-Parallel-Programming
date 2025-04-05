using System.Text.Json;

using HttpClient client = new HttpClient();

// This line of code throws an exception because the url doesn't exist
Task<string> task1 = client.GetStringAsync("https://pokeapi123.co/api/v2/pokemon");
Task task2 = task1.ContinueWith(t =>
{
    Console.WriteLine("Continuing with the 2nd task");
    Thread.Sleep(1000);

    // Also this line throws another exception because the antecedent was faulty
    string result = t.Result;
    JsonDocument doc = JsonDocument.Parse(result);
    JsonElement root = doc.RootElement;
    JsonElement results = root.GetProperty("results");
    JsonElement firstPokemon = results[0];

    Console.WriteLine($"First pokemon name: {firstPokemon.GetProperty("name")}");
    Console.WriteLine($"First pokemon url: {firstPokemon.GetProperty("url")}");
});

// But unless you call the wait method or try to access the result property,
// the exception won't bubble up

//task1.Wait();
//task2.Wait();

//var output = task1.Result;

Console.WriteLine("This is the end of the program");
Console.ReadLine();