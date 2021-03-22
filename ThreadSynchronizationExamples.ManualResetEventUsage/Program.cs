using System;
using System.Threading;

namespace ThreadSynchronizationExamples.ManualResetEventUsage
{
    class Program
    {
        private static readonly ManualResetEvent Mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(Write).Start();

            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
        }

        public static void Write()
        {
            ThreadLogger("writing...");
            Mre.Reset();
            Thread.Sleep(5000);
            ThreadLogger("completed!");
            Mre.Set();
        }

        public static void Read()
        {
            ThreadLogger("waiting to read...");
            Mre.WaitOne();
            ThreadLogger("reading...");
            Thread.Sleep(1000);
            ThreadLogger("completed!");
        }

        private static void ThreadLogger(string msg)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is {msg}");
        }
    }
}
