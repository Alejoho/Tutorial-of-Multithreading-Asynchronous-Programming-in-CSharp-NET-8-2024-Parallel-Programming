﻿using System.Diagnostics;

namespace AsyncBreakfast1;

class Program
{
    static async Task Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Coffee cup = PourCoffee();
        Console.WriteLine("coffee is ready");

        Task<Egg> taskEgg = FryEggs(2);
        Task<Bacon> taskBacon = FryBacon(3);
        Task<Toast> taskToast = MakeToastWithButterAndJamAsync(2);

        Toast toast = await taskToast;
        Console.WriteLine("toast is ready");

        Egg eggs = await taskEgg;
        Console.WriteLine("eggs are ready");

        Bacon bacon = await taskBacon;
        Console.WriteLine("bacon is ready");

        Juice oj = PourOJ();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
        sw.Stop();
        Console.WriteLine($"The breakfast was ready in {sw.ElapsedMilliseconds}");
    }

    private static Juice PourOJ()
    {
        Console.WriteLine("Pouring orange juice");
        return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("Putting butter on the toast");

    private async static Task<Toast> ToastBreadAsync(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }

        Console.WriteLine("Start toasting...");
        await Task.Delay(3000);
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }

    private async static Task<Bacon> FryBacon(int slices)
    {
        Console.WriteLine($"putting {slices} slices of bacon in the pan");
        Console.WriteLine("cooking first side of bacon...");
        await Task.Delay(3000);
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("flipping a slice of bacon");
        }

        Console.WriteLine("cooking the second side of bacon...");
        await Task.Delay(3000);
        Console.WriteLine("Put bacon on plate");

        return new Bacon();
    }

    private async static Task<Egg> FryEggs(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        await Task.Delay(3000);
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        await Task.Delay(3000);
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        Console.WriteLine("Pouring coffee");
        return new Coffee();
    }

    private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    {
        Toast toast = await ToastBreadAsync(2);
        ApplyButter(toast);
        ApplyJam(toast);

        return toast;
    }
}

// These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
internal class Bacon
{
}

internal class Coffee
{
}

internal class Egg
{
}

internal class Juice
{
}

internal class Toast
{
}