namespace DeadLockExample;

internal class Program
{
    private static ReaderWriterLockSlim lock1 = new ReaderWriterLockSlim();
    private static ReaderWriterLockSlim lock2 = new ReaderWriterLockSlim();
    static void Main(string[] args)
    {
        Console.WriteLine("Start");
        Thread thread1 = new Thread(() => AccessResources(lock1, lock2));
        Thread thread2 = new Thread(() => AccessResources(lock2, lock1));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("End");
        Console.ReadLine();
    }

    private static void AccessResources(ReaderWriterLockSlim firstLock, ReaderWriterLockSlim secondLock)
    {
        const int timeout = 5000; // 5 seconds

        try
        {
            // Acquire the first lock
            if (firstLock.TryEnterWriteLock(timeout))
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired the first lock.");

                // Simulate work
                Thread.Sleep(1000);

                // Acquire the second lock
                if (secondLock.TryEnterReadLock(timeout))
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} acquired the second lock.");

                    // Simulate work
                    Thread.Sleep(1000);

                    // Release the second lock
                    secondLock.ExitReadLock();
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} released the second lock.");
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} failed to acquire the second lock.");
                }

                // Release the first lock
                firstLock.ExitWriteLock();
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} released the first lock.");
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} failed to acquire the first lock.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}