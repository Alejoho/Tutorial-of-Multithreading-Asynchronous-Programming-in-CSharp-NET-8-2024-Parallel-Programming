using System.Runtime.CompilerServices;

int counter = 0;

object counterLock = new object();

Thread thread1 = new Thread(IncrementCounter);
Thread thread2 = new Thread(IncrementCounter);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine($"Final counter value is: {counter}");

void IncrementCounter()
{
    for (int i = 0; i < 100000; i++)
    {
        Monitor.Enter(counterLock);
        try
        {
            int temp = counter;
            counter = temp + 1;
        }
        finally
        {
            Monitor.Exit(counterLock);
        }

        // If you want to lock a whole method you can do it by using an attribute.
        // Go to the end to see the example.
        //IncrementbyOne();
    }
}

[MethodImpl(MethodImplOptions.Synchronized)]
void IncrementbyOne()
{
    int temp = counter;
    counter = temp + 1;
}