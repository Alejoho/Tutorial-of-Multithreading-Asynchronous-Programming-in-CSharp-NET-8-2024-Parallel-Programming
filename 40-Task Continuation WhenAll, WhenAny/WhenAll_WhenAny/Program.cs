int[] array = new int[2000];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i;
}

int numberOfTasks = 4;
int segmentLength = array.Length / numberOfTasks;

Task<int>[] tasks = new Task<int>[numberOfTasks];

tasks[0] = Task.Run(() => SumSegment(0, segmentLength));
tasks[1] = Task.Run(() => SumSegment(segmentLength, 2 * segmentLength));
tasks[2] = Task.Run(() => SumSegment(2 * segmentLength, 3 * segmentLength));
tasks[3] = Task.Run(() => SumSegment(3 * segmentLength, array.Length));

Task<Task<int>> whenAnyTask = Task.WhenAny(tasks);

whenAnyTask.ContinueWith(t =>
{
    Console.WriteLine(t);
    Console.WriteLine(t.Result);
    Console.WriteLine(t.Result.Result);
});

Task<int[]> whenAllTasks = Task.WhenAll(tasks);

whenAllTasks.ContinueWith(t => Console.WriteLine($"The sum is {whenAllTasks.Result.Sum()}"));

Console.WriteLine("End of the execution");

Console.ReadLine();
return;

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