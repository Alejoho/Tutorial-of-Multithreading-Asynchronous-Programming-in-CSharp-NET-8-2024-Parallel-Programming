// See https://aka.ms/new-console-template for more information

Console.WriteLine("Start");

/*var thread1 = new Thread(Work) { Name = "Thread 1" };
thread1.Start();*/

for (var i = 0; i < 10; i++)
{
    var thread = new Thread(Work) { Name = $"Thread {i}" };
    thread.Start();
}

Thread.CurrentThread.Name = "Master thread";
Work();

void Work()
{
    Console.WriteLine($"{Thread.CurrentThread.Name} is starting to work.");
    Thread.SpinWait(99999999); // This number has eights 9
    Console.WriteLine($"{Thread.CurrentThread.Name} is finishing to work.");
}