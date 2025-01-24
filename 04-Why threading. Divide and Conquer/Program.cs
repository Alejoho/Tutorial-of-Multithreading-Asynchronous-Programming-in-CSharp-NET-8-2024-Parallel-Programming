using System.Diagnostics;

int[] array = new int[2000];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i;
    //Console.WriteLine(array[i]);
}


int SumSegment(int startIndex, int endIndex)
{
    int segmentSum = 0;

    for (int i = startIndex; i < endIndex; i++)
    {
        Thread.Sleep(1);
        segmentSum += array[i];
    }

    return segmentSum;
}

int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

int numberOfThreads = 4;
int segmentLength = array.Length / numberOfThreads;

Thread[] threads = new Thread[numberOfThreads];

threads[0] = new Thread(() => { sum1 = SumSegment(0, segmentLength); });
threads[1] = new Thread(() => { sum2 = SumSegment(segmentLength, 2 * segmentLength); });
threads[2] = new Thread(() => { sum3 = SumSegment(2 * segmentLength, 3 * segmentLength); });
threads[3] = new Thread(() => { sum4 = SumSegment(3 * segmentLength, array.Length); });

foreach (Thread thread in threads)
{
    thread.Start();
}

foreach (Thread thread in threads)
{
    thread.Join();
}

// for (int i = 0; i < array.Length; i++)
// {
//     Thread.Sleep(1);
//     sum1 += array[i];
//     //Console.WriteLine(sum1);
// }

stopwatch.Stop();

Console.WriteLine($"The sum is {sum1 + sum2 + sum3 + sum4}");
Console.WriteLine($"The time it takes: {stopwatch.Elapsed.TotalMilliseconds}");

Console.ReadLine();