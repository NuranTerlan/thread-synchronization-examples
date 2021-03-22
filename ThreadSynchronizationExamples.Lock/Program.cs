using System;
using System.Threading;

namespace ThreadSynchronizationExamples.LockUsage
{
    class Program
    {
        private static readonly object Locker = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork).Start();
            }
        }

        public static void DoWork()
        {
            lock (Locker)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting...");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed!");
            }
        }
    }
}
