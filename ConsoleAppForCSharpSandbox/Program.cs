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
            Task.Factory.StartNew(() => DoWork(1, 1500)).ContinueWith((prevTask) => DoAdditionalWork(1, 1000)).ContinueWith((anotherTask) => DoAdditionalWork(1, 4000));
            Task.Factory.StartNew(() => DoWork(2, 3000)).ContinueWith((prevTask) => DoAdditionalWork(2, 2000));
            Task.Factory.StartNew(() => DoWork(3, 1000)).ContinueWith((prevTask) => DoAdditionalWork(3, 750));

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        static void DoWork(int id, int sleepTime)
        {
            Console.WriteLine($"task {id} is beginning");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} has completed");
        }

        static void DoAdditionalWork(int id, int sleepTime)
        {
            Console.WriteLine($"task {id} is beginning additional work");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} has completed additional work");
        }
    }
}
