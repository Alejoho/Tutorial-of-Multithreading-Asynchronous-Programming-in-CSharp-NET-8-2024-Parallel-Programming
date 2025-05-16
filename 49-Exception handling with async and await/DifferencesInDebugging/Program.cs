Console.WriteLine("Start");



//Task.Run(() =>
Thread t1 = new Thread(() =>
{
    Console.WriteLine("Doing task 1 work");
    int sum1 = 0;
    for (int i = 0; i < 10; i++)
    {
        sum1++;
    }
    Console.WriteLine("Finishing task 2 work");
});
t1.Start();

//Task.Run(() =>
Thread t2 = new Thread(() =>
{
    Console.WriteLine("Doing task 2 work");
    int sum2 = 0;
    for (int i = 0; i < 10; i++)
    {
        sum2++;
    }
    Console.WriteLine("Finishing task 2 work");
});
t2.Start();

Console.WriteLine("Created 2 tasks");

int total = 0;
for (int i = 0; i < 10; i++)
{
    total++;
}


Console.WriteLine("End");
