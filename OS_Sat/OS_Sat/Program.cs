using System;
using System.Diagnostics;
namespace OS_Sat
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("mspaint");
            Process[] prList = Process.GetProcesses();
            foreach (Process p in prList)
            {
                Console.WriteLine(p.Id + "\t" + p.ProcessName);
            }
            int pid = int.Parse(Console.ReadLine());
            foreach (Process p in prList)
            {
                if (p.Id == pid)
                    p.Kill();
            }
            Console.ReadKey();
        }
    }
}
