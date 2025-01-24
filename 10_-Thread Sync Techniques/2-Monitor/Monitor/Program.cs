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
        // If you had two pieces of code that both would represent a critical section
        // together you can put 2 lock using the same object. Go to the
        // AirplaneSeatBookingQuestion project to see the example.
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
    }
}