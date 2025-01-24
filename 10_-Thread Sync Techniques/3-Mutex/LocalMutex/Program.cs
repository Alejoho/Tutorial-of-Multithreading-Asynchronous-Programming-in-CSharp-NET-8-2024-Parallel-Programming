int counter = 0;

Mutex mutex = new Mutex();

Thread thread1 = new Thread(IncrementCounter);
Thread thread2 = new Thread(IncrementCounter);
Thread thread3 = new Thread(IncrementCounter);

thread1.Start();
thread2.Start();
thread3.Start();

thread1.Join();
thread2.Join();
thread3.Join();

Console.WriteLine($"Final counter value is: {counter}");
Console.ReadLine();

void IncrementCounter()
{
    for (int i = 0; i < 20000; i++)
    {
        mutex.WaitOne();
        try
        {
            int temp = counter;
            counter = temp + 1;
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}