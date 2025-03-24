var tasks = new List<Task<int>>();

for (int ctr = 1; ctr <= 10; ctr++)
{
    int baseValue = ctr;
    tasks.Add(Task.Factory.StartNew(b => (int)b! * (int)b, baseValue));
}

var results = Task.WhenAll(tasks).Result;

int sum = 0;
for (int ctr = 0; ctr <= results.Length - 1; ctr++)
{
    var result = results[ctr];
    Console.Write($"{result} {((ctr == results.Length - 1) ? "=" : "+")} ");
    sum += result;
}

Console.WriteLine(sum);