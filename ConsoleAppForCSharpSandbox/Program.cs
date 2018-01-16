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
            var t1 = new Task(() => {
                Console.WriteLine("task 1 is beginning");
                Thread.Sleep(1000);
                Console.WriteLine("task 1 has completed");
            });
            t1.Start();

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
