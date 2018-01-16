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
            var t1 = Task.Factory.StartNew(() => DoWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DoWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DoWork(3, 1000));

            var taskList = new List<Task> { t1, t2, t3 };

            Task.WaitAll(taskList.ToArray());

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
