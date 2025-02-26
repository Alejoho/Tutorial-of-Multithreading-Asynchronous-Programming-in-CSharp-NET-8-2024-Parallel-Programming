using GlobalMutex;

string filePath = "counter.txt";

using (var mutex = new Mutex(false, filePath))
{
    mutex.WaitOne();
    try
    {
        for (int i = 0; i < 1000; i++)
        {
            int counter = HelperFunctions.ReadCounter(filePath);
            counter++;
            HelperFunctions.WriteCounter(filePath, counter);
        }
    }
    finally
    {
        mutex.ReleaseMutex();
    }
}

Console.WriteLine("Process finished.");

Console.ReadLine();

