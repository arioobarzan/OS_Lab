using System;
using System.Threading;

class Program
{
    static Semaphore semaphore = new Semaphore(2, 2); // ظرفیت Semaphore: 2

    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(WithdrawMoney);
            thread.Start(i + 1);
        }
        Console.ReadKey();
    }

    static void WithdrawMoney(object accountId)
    {
        semaphore.WaitOne(); 
        Console.WriteLine($"Account {accountId} is withdrawing money...");
        Thread.Sleep(2000); 
        Console.WriteLine($"Account {accountId} has withdrawn money.");
        semaphore.Release(); 
    }
}
