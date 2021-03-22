using System;
using System.Threading;

namespace ThreadSynchronizationExamples.AutoResetEvent_MutexUsage
{
    class Program
    {
        //private static readonly AutoResetEvent Are = new AutoResetEvent(true);
        private static readonly Mutex Mutex = new Mutex();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            //int count = 0;
            //foreach (var result in GetCalculations(100))
            //{
            //    count++;
            //    Console.WriteLine($"Result of {count} --> {result}");
            //}

            //Thread.Sleep(3000);
            //Are.Set();
        }

        //public static IEnumerable<int> GetCalculations(int size)
        //{
        //    var random = new Random();

        //    var a = new List<int>(size);
        //    var b = new List<int>(size);

        //    for (int i = 0; i < size; i++)
        //    {
        //        a.Add(random.Next(100, 1000));
        //        b.Add(random.Next(100, 1000));
        //    }

        //    for (int i = 0; i < size; i++)
        //    {
        //        Thread.Sleep(50);
        //        yield return a[i] * b[i];
        //    }
        //}

        public static void Write()
        {
            ThreadLogger("waiting...");
            Mutex.WaitOne();
            ThreadLogger("writing...");
            Thread.Sleep(1000);
            ThreadLogger("completed!");
            Mutex.ReleaseMutex();
        }

        private static void ThreadLogger(string msg)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is {msg}");
        }
    }
}
