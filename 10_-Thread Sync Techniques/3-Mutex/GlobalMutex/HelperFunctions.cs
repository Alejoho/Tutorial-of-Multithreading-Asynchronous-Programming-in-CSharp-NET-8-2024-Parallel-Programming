namespace GlobalMutex;

public static class HelperFunctions
{
    public static int ReadCounter(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
        using (var reader = new StreamReader(stream))
        {
            string content = reader.ReadToEnd();
            return string.IsNullOrEmpty(content) ? 0 : int.Parse(content);
        }
    }

    public static void WriteCounter(string filePath, int counter)
    {
        using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
        using (var writer = new StreamWriter(stream))
        {
            writer.Write(counter);
        }
    }
}