using System.Text.Json;

Console.WriteLine("Start");

PrintPokemonResult();

Console.WriteLine("This is the end of the program");
for (int i = 0; i < 15; i++)
{
    Thread.Sleep(500);
    Console.WriteLine($"{i} - Ending");
}

Console.ReadLine();
return;


async void PrintPokemonResult()
{
    using HttpClient client = new HttpClient();
    Thread.Sleep(10000);
    Task<string> taskGetPokemonList = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon");

    string response = await taskGetPokemonList;

    Console.WriteLine("Continuing with the 2nd task");
    Thread.Sleep(3000);

    JsonDocument doc = JsonDocument.Parse(response);
    JsonElement root = doc.RootElement;
    JsonElement results = root.GetProperty("results");
    JsonElement firstPokemon = results[0];

    Console.WriteLine($"First pokemon name: {firstPokemon.GetProperty("name")}");
    Console.WriteLine($"First pokemon url: {firstPokemon.GetProperty("url")}");
}