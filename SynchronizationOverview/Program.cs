﻿int counter = 0;

object counterLock = new object();

Thread thread1 = new Thread(IncrementCounter);
Thread thread2 = new Thread(IncrementCounter);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine($"Final counter value is: {counter}");
Console.ReadLine();

void IncrementCounter()
{
    for (int i = 0; i < 100000; i++)
    {
        lock (counterLock)
        {
            int temp = counter;
            counter = temp + 1;
        }
    }
}