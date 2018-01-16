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
            // TPL example from Clint Eastwood @ - https://www.youtube.com/watch?v=gfkuD_eWM5Y

            var source = new CancellationTokenSource();

            try
            {
                var t1 = Task.Factory.StartNew(() => DoWork(1, 2000, source.Token)).ContinueWith((prevTask) => DoAdditionalWork(1, 3000, source.Token));

                // Slow down screen some so that you can see the message before cancel.
                Thread.Sleep(1000);
                Console.WriteLine("Abort! Abort! Abort!  Cancelling NOW");
                source.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }            

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        static void DoWork(int id, int sleepTime, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }

            Console.WriteLine($"task {id} is beginning");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} has completed");
        }

        static void DoAdditionalWork(int id, int sleepTime, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }

            Console.WriteLine($"task {id} is beginning additional work");
            Thread.Sleep(sleepTime);
            Console.WriteLine($"task {id} has completed additional work");
        }
    }
}
