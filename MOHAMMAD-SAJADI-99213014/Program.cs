// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

Console.WriteLine("choose one option :");
Console.WriteLine("1.run a process : ");
Console.WriteLine("2.show all processes : ");
Console.WriteLine("3.kill a process : ");
Console.WriteLine("4.show parent of the process : ");
string option = Console.ReadLine();

switch (option)
{
    case "1":
        Console.WriteLine("please enter process name  :");
        string pName = Console.ReadLine();
        Process.Start(pName);
        

        break;

    case "2":
        Process[] processesList = Process.GetProcesses();
        foreach (Process process in processesList)
        {
            Console.WriteLine(process.ProcessName);
        }
        break;
    case "3":
        Console.WriteLine("please enter process name  :");
        string pName2 = Console.ReadLine();
        Process[] processes2 = Process.GetProcessesByName(pName2);
        foreach (Process process in processes2)
        {
            process.Kill();
        }
        break;

    case "4":
    Console.WriteLine("please enter process name  :");
    string processName = Console.ReadLine();
    Process[] processes = Process.GetProcessesByName(processName);
    foreach(Process process in processes){

       Console.WriteLine($"{process.Handle}");
    }
    break;

}

