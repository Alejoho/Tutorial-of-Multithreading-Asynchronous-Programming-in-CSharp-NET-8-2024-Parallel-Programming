// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int a = 1;

void WriteThreadId()
{
    int b = 2;
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        //Thread.Sleep(50);
    }
}

Thread thread1 = new Thread(WriteThreadId);
Thread thread2 = new Thread(WriteThreadId);

thread1.Name="Thread1";

thread1.Priority = ThreadPriority.Highest;
thread2.Priority = ThreadPriority.Lowest;
Thread.CurrentThread.Priority = ThreadPriority.Normal;

thread1.Start();
thread2.Start();

WriteThreadId();

Console.ReadLine();