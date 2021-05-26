using System;
using System.Threading;

namespace SyncronizingExercise
{
    class Program
    {
        static int counter = 0;
        static object _lock = new object();


        static void Main(string[] args)
        {
            Thread thread1 = new Thread(CountUp);
            Thread thread2 = new Thread(CountDown);       
            thread1.Start();
            Thread.Sleep(100);
            thread2.Start();           
        }

        static void CountUp()
        {
            while (true)
            {
            Monitor.Enter(_lock);            
                try
                {
                    counter = counter + 2;
                    Console.WriteLine(counter);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                };             
            }
        }


        static void CountDown()
        {
            while (true)
            {
            Monitor.Enter(_lock);
            try
            {
                counter = counter - 1;
                Console.WriteLine(counter);
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(_lock);
            };
            }
        }
    }
}
