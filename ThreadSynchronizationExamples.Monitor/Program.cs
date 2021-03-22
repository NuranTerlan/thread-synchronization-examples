using System;
using System.Threading;

namespace ThreadSynchronizationExamples.MonitorUsage
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
            try
            {
                Monitor.Enter(Locker);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting...");
                Thread.Sleep(2000);
                throw new CustomThreadException();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed!");
            }
            catch (CustomThreadException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Monitor.Exit(Locker);
            }
        }
    }

    public class CustomThreadException : Exception
    {
        public CustomThreadException()
            :base("Error occured while completing thread.")
        {
            
        }
    }
}
