public class GlobalConfigurationCache
{
    private Dictionary<int, int> _cache;
    private ReaderWriterLockSlim _lock;
    private int _writeSleep = 0;
    private int _readSleep = 0;

    public GlobalConfigurationCache(int writeSleep, int readSleep)
    {
        _cache = new Dictionary<int, int>();
        _cache.Add(0, 0);
        _lock = new ReaderWriterLockSlim();
        _writeSleep = writeSleep;
        _readSleep = readSleep;
    }


    public void UpdateValue(int key, int value)
    {
        bool lockAcquired = false;
        int newValue = 0;

        try
        {
            _lock.EnterWriteLock();

            lockAcquired = true;
            Thread.Sleep(_writeSleep);
            newValue = _cache[key] + value;
            _cache[key] = newValue;
        }
        finally
        {
            if (lockAcquired)
                _lock.ExitWriteLock();
        }

        Console.WriteLine($"\t\t\t\t{Thread.CurrentThread.Name} updates value {newValue}");
    }


    public int Get(int key)
    {
        bool lockAcquired = false;
        try
        {
            _lock.EnterReadLock();
            lockAcquired = true;
            Thread.Sleep(_readSleep);
            int value = _cache.GetValueOrDefault(key, 0);
            Console.WriteLine($"{Thread.CurrentThread.Name} reads value {value}");
            return value;
        }
        finally
        {
            if (lockAcquired)
                _lock.ExitReadLock();
        }
    }
}