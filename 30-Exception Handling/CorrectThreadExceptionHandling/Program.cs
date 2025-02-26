List<Exception> exceptions=new List<Exception>();
object lockObj= new object();

Thread thread1 = new Thread(Work);
Thread thread2 = new Thread(Work);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

foreach (var exception in exceptions)
{
    Console.WriteLine(exception.ToString());
    Console.WriteLine();
}

Console.WriteLine("End");


void Work()
{
    try
    {
        throw new InvalidOperationException("This error was expected");
    }
    catch (Exception ex)
    {
        lock (lockObj)
        {
            exceptions.Add(ex);
        }
    }
}