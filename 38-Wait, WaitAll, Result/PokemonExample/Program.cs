using HttpClient client = new HttpClient();
Task<string> task = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/20/");
string result = task.Result;

Console.WriteLine(result);