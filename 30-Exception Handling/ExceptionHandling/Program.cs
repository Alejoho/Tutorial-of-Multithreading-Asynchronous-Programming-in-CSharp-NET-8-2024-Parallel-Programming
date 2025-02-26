Thread thread = null!;

// Exceptions can't propagate outside the thread in which was thrown. So you 
// need to handle them within the thread

/*thread = new Thread(() =>
{
    try
    {
        throw new InvalidOperationException("An error ocurred in this worker thread. This was expected");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
});*/


// This is what happens if you manage exceptions in a thread outside of it

try
{
    thread = new Thread(() =>
    {
        throw new InvalidOperationException("An error ocurred in this worker thread. This was expected");
    });
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

thread?.Start();
thread?.Join();

Console.WriteLine("End of execution");