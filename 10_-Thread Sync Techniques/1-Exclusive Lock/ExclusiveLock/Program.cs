int counter = 0;

object counterLock = new object();

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
    for (int i = 0; i < 200000; i++)
    {
        // If you had two pieces of code that both would represent a critical section
        // together you can put 2 lock using the same object. 
        lock (counterLock)
        {
            int temp = counter;
            counter = temp + 1;
        }
    }
}
