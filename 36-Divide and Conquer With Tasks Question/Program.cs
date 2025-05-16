using System.Diagnostics;

int[] array = new int[2000];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i;
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

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

int numberOfTasks = 4;
int segmentLength = array.Length / numberOfTasks;

Task<int>[] tasks = new Task<int>[numberOfTasks];

tasks[0] = new Task<int>(() => SumSegment(0, segmentLength));
tasks[1] = new Task<int>(() => SumSegment(segmentLength, 2 * segmentLength));
tasks[2] = new Task<int>(() => SumSegment(2 * segmentLength, 3 * segmentLength));
tasks[3] = new Task<int>(() => SumSegment(3 * segmentLength, array.Length));

foreach (Task<int> task in tasks)
{
    task.Start();
}

Console.WriteLine($"The sum is {tasks.Sum(t=>t.Result)}");
stopwatch.Stop();
Console.WriteLine($"The time it takes: {stopwatch.Elapsed.TotalMilliseconds}");

Console.ReadLine();