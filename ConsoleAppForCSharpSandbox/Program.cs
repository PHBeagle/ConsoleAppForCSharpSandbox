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
            var intList = new List<int> { 1, 2, 7, 9, 10, 12, 3, 6, 1, 4, 5, 8, 42, 3 };

            Parallel.For(0, 100, (i) => Console.WriteLine(i));

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
