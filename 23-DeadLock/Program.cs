// e-commerce: users and orders
// 1. managing users (user -> order)
// 2. managing orders (order -> user)

// Thread 1 wants to lock user first then lock order.
// Thread 2 wants to lock order first then lock the user.

object userLock = new object();
object orderLock = new object();

Thread thread = new Thread(ManageOrder);
thread.Name = "Thread-1";
thread.Start();

ManageUser();

thread.Join();
Console.WriteLine("End");
Console.ReadLine();

void ManageUser()
{
    lock (userLock)
    {
        Console.WriteLine("User management acquired the user lock.");
        Thread.Sleep(2000);

        lock (orderLock)
        {
            Console.WriteLine("User Management acquired the order lock.");
        }
    }
}

void ManageOrder()
{
    lock (orderLock)
    {
        Console.WriteLine("Order Management acquired the order lock.");
        Thread.Sleep(1000);

        lock (userLock)
        {
            Console.WriteLine("Order Management acquired the user lock.");
        }
    }
}