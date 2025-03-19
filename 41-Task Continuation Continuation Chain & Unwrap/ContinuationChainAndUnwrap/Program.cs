using System.Text.Json;

using HttpClient client = new HttpClient();

// 1st task
var taskListJson = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon");

// 2nd task
var taskGetFirstUrl = taskListJson.ContinueWith(t =>
{
    string result = t.Result;
    JsonDocument doc = JsonDocument.Parse(result);
    JsonElement root = doc.RootElement;
    JsonElement results = root.GetProperty("results");
    JsonElement firstPokemon = results[0];

    return firstPokemon.GetProperty("url").ToString();
});

// 3rd task
var taskGetDetailsJson = taskGetFirstUrl.ContinueWith(t =>
{
    var result = t.Result;
    return client.GetStringAsync(result);
}).Unwrap();

// 4th task
var displayTask = taskGetDetailsJson.ContinueWith(t =>
{
    var result = t.Result;
    var doc = JsonDocument.Parse(result);
    JsonElement root = doc.RootElement;
    Console.WriteLine($"Name: {root.GetProperty("name").ToString()}");
    Console.WriteLine($"Weight: {root.GetProperty("weight").ToString()}");
    Console.WriteLine($"Height: {root.GetProperty("height").ToString()}");
});

Console.ReadLine();