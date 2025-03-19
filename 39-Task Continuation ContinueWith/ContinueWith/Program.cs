using System.Text.Json;

using HttpClient client = new HttpClient();
Task<string> task = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon");
Task t2 = task.ContinueWith(t =>
{
    Console.WriteLine("Continuing with the 2nd task");
    Thread.Sleep(3000);

    string result = t.Result;
    JsonDocument doc = JsonDocument.Parse(result);
    JsonElement root = doc.RootElement;
    JsonElement results = root.GetProperty("results");
    JsonElement firstPokemon = results[0];

    Console.WriteLine($"First pokemon name: {firstPokemon.GetProperty("name")}");
    Console.WriteLine($"First pokemon url: {firstPokemon.GetProperty("url")}");

    //Console.WriteLine(t.Result);
});

Console.WriteLine("This is the end of the program");
for (int i = 0; i < 30; i++)
{
    Thread.Sleep(500);
    Console.WriteLine($"{i} - Ending");
}

Console.ReadLine();