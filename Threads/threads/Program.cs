using System;
using System.Threading;
using System.Threading.Tasks;

namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {
            th();
            //fact();
        }
        static void th()
        {
            Thread th1 = new Thread(Do1);
            Thread th2 = new Thread(Do2);

            th1.Start();
            th2.Start();
            Console.ReadKey();
        }
        static void Do1()
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("th1 : " + i);
                Thread.Sleep(1000);
            }
        }
        static void Do2()
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("th2 : " + i);
                Thread.Sleep(1500);
            }
        }
        static void fact()
        {
            int[] ar = new int[] { 5, 6, 7, 8, 9 };
            foreach (int a in ar)
            {
                Task.Run(() =>
                {
                    Console.WriteLine("fact: " + a + " is:" + factorial(a));
                });
            }
            Console.ReadKey();
        }
        static int factorial(int x) 
        {
            if (x == 1) return 1;
            else return x * factorial(x-1);
        }

    }
}
