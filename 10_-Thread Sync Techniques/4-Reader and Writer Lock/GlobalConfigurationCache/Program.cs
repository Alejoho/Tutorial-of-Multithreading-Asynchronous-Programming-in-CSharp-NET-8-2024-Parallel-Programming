Console.WriteLine("Execution started.");

// Initializing some share resources
GlobalConfigurationCache cache = new GlobalConfigurationCache(100, 100);
// flag to stop reading
bool areReading = true;

// Creating the reader threads
Thread readerThread1 = new Thread(Read);
readerThread1.Name = "reader 1";
Thread readerThread2 = new Thread(Read);
readerThread2.Name = "reader 2";
Thread readerThread3 = new Thread(Read);
readerThread3.Name = "reader 3";

// Creating the writing threads
Thread writerThread1 = new Thread(Update);
writerThread1.Name = "writer 1";
Thread writerThread2 = new Thread(Update);
writerThread2.Name = "writer 2";

// Starting the threads
readerThread1.Start();
readerThread2.Start();
readerThread3.Start();

writerThread1.Start();
//writerThread2.Start();

// Method to read the share resource
void Read()
{
    while (areReading)
    {
        cache.Get(0);
    }
}

// Method to write the share resource
void Update()
{
    for (int j = 0; j < 100; j++)
    {
        cache.UpdateValue(0, 1);
    }
}

// Waiting for the writing threads to finish
writerThread1.Join();
//writerThread2.Join();

Thread.Sleep(20);

// Stop the reading threads
areReading = false;

readerThread1.Join();
readerThread2.Join();
readerThread3.Join();

// End of the execution
Console.WriteLine("Execution ended.");
Console.ReadLine();