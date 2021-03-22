using System;
using System.Threading;

namespace ThreadSynchronizationExamples.SemaphoreUsage
{
    class Program
    {
        private static readonly Semaphore Semaphore = new Semaphore(2, 2);

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
        }

        public static void Write()
        {
            ThreadLogger("waiting...");
            Semaphore.WaitOne();
            ThreadLogger("writing...");
            Thread.Sleep(3000);
            ThreadLogger("completed!");
            Semaphore.Release();
        }

        private static void ThreadLogger(string msg)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is {msg}");
        }
    }
}
