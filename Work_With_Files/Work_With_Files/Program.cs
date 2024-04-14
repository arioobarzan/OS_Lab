using System;
using System.IO;

namespace Work_With_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\gheir\Downloads\s24.txt";
            if (!File.Exists(path))
            {
                var f = File.Create(path);
                f.Close();
            }
            string str = "salam\nkhobi?";
            File.WriteAllText(path, str);

            File.AppendAllText(path, "\nchetori?");
            //File.Move(path, "s24.exe");
            var d = File.GetCreationTime(path);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
