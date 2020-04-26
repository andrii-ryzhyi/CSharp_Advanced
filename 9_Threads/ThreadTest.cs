using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IteaThreads
{
    public class ThreadTest
    {
        public static long[] count = new long[5];
        public static long sharedCounter;
        public static Thread[] pool = new Thread[5];
        public static string[] priority = new string[5];
        public static bool running;
        public static long[,] stats;
        static Semaphore semaphore = new Semaphore(3, 3);
        public static void InitThreads()
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = new Thread(DoWork)
                {
                    Name = $"{i}",
                    Priority = (ThreadPriority)i
                };
                priority[i] = pool[i].Priority.ToString();
            }
        }
        public static void DoWork()
        {
            var name = Thread.CurrentThread.Name;
            var idx = Int32.Parse(name);
            while (running)
            {
                count[idx]++;
            }
        }
        public static void DoFixedWork()
        {
            Thread thread = Thread.CurrentThread;
            for (int i = 0; i < 10000; i++)
            {
                sharedCounter++;
            }
            Console.WriteLine($"{thread.Name}, {thread.Priority}: job completed, counter: {sharedCounter}");
        }
        public static void DoFixedWorkSemaphore()
        {
            semaphore.WaitOne();
            Thread thread = Thread.CurrentThread;
            for (int i = 0; i < 10000; i++)
            {
                sharedCounter++;
            }
            Console.WriteLine($"{thread.Name}, {thread.Priority}: job completed, counter: {sharedCounter}");
            semaphore.Release();
        }
        private static void _launch()
        {
            running = true;
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i].Start();
            }
            // Main thread sleeps while threads run for 10 sec in background
            Thread.Sleep(1000);
            running = false;
        }

        public static void LaunchFixedTime(int iterations = 1)
        {
            stats = new long[iterations, pool.Length];
            for (int i = 0; i < iterations; i++)
            {
                InitThreads();
                _launch();
                // Gather post run stats
                for (int j = 0; j < pool.Length; j++)
                {
                    stats[i, j] = count[j];
                  //  count[j] = 0; // reset counter
                }
                Console.WriteLine($"Threads iteration {i + 1} counter stats:");
                for (int j = 0; j < pool.Length; j++)
                {
                    Console.WriteLine($"Thread {j}, Priority {priority[j]}: {stats[i, j]}");
                }
            }
            GetStats(iterations);
        }
        public static void LaunchFixedWork(int iterations, bool withSemaphore = false)
        {
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < pool.Length; j++)
                {
                    pool[j] = withSemaphore ? new Thread(() => DoFixedWorkSemaphore()) : new Thread(() => DoFixedWork())
                    {
                        Name = $"{j}",
                        Priority = (ThreadPriority)j
                    };
                    pool[j].Start();
                }
            }
            sharedCounter = 0;
        }

        public static void GetStats(int iterations)
        {
            long[] average = new long[pool.Length];
            Console.WriteLine($"Threads Summary stats:");
            for (int i = 0; i < pool.Length; i++)
            {
                average[i] = (long)count[i] / iterations;
                Console.WriteLine($"Thread {i}, Priority {priority[i]}: {average[i]}");
            }
        }
    }
}
