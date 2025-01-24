using GlobalMutex;

string filePath = "counter.txt";

//File.Delete(filePath);

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

//string content = File.ReadAllText(filePath);
//Console.WriteLine($"File content: {content}");

Console.ReadLine();