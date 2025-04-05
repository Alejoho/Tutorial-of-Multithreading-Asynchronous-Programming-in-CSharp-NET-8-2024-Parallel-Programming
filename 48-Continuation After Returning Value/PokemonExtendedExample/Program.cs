using System.Text.Json;

using HttpClient client = new HttpClient();

// 1st task
var listJson = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon");

// 2nd task
JsonDocument doc = JsonDocument.Parse(listJson);
JsonElement root = doc.RootElement;
JsonElement results = root.GetProperty("results");
JsonElement firstPokemon = results[0];

string firstPokemonUrl = firstPokemon.GetProperty("url").ToString();

// 3rd task
var detailsJson = await client.GetStringAsync(firstPokemonUrl);

// 4th task
doc = JsonDocument.Parse(detailsJson);
root = doc.RootElement;
Console.WriteLine($"Name: {root.GetProperty("name").ToString()}");
Console.WriteLine($"Weight: {root.GetProperty("weight").ToString()}");
Console.WriteLine($"Height: {root.GetProperty("height").ToString()}");

Console.ReadLine();