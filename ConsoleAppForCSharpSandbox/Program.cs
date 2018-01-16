using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppForCSharpSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => DoWork(1, 1500));
            t1.Start();

            var t2 = new Task(() => DoWork(2, 3000));
            t2.Start();

            var t3 = new Task(() => DoWork(3, 100));
            t3.Start();

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        static void DoWork(int id, int sleepTime)
        {
            Console.WriteLine($"task {id} is beginning");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} has completed");
        }
    }
}
