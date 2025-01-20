int counter = 0;

Thread thread1 = new Thread(IncrementCounter);
thread1.Start();
thread1.Join();

Thread thread2 = new Thread(IncrementCounter);
thread2.Start();
thread2.Join();

Console.WriteLine($"Final counter value is: {counter}");

void IncrementCounter()
{
    for (int i = 0; i < 100000; i++)
    {
        counter = counter + 1;
    }
}