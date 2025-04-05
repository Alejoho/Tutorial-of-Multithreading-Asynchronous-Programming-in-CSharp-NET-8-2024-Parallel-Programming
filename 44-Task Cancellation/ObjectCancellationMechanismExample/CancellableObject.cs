namespace ObjectCancellationMechanism;

public class CancellableObject
{
    private bool cancelSign;

    public CancellableObject()
    {
        cancelSign = false;
    }

    public void Work()
    {
        Console.WriteLine("Started the work");
        Console.WriteLine("Stage 1");
        for (int i = 0; i < 10; i++)
        {
            if (cancelSign)
            {
                Console.WriteLine($"Cancelation requested at stage 1 in iteration {i}");
                return;
            }

            Console.WriteLine($"Working 1-{i}");
            Thread.Sleep(500);
        }

        Console.WriteLine("Stage 2");
        for (int i = 0; i < 10; i++)
        {
            if (cancelSign)
            {
                Console.WriteLine($"Cancelation requested at stage 2 in iteration {i}");
                return;
            }

            Console.WriteLine($"Working 2-{i}");
            Thread.Sleep(500);
        }

        Console.WriteLine("Stage 3");
        for (int i = 0; i < 10; i++)
        {
            if (cancelSign)
            {
                Console.WriteLine($"Cancelation requested at stage 3 in iteration {i}");
                return;
            }

            Console.WriteLine($"Working 3-{i}");
            Thread.Sleep(500);
        }

        Console.WriteLine("Work Done");
    }

    public void CancelProcess()
    {
        cancelSign = true;
    }
}