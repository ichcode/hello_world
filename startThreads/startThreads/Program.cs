using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace startThreads
{
    public class SimpleThreadExample
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            Thread t1 = new Thread(() =>
            {
                
                int numberOfSeconds = 0;
                while (numberOfSeconds < 5)
                {
                    Thread.Sleep(1000);

                    numberOfSeconds++;
                }

                Console.WriteLine("t1 -> I ran for 5 seconds");
            });

            t1.Name = "Thread T1";

            Thread t2 = new Thread(() =>
            {
                int numberOfSeconds = 0;
                while (numberOfSeconds < 8)
                {
                    Thread.Sleep(1000);

                    numberOfSeconds++;
                }

                Console.WriteLine("t2 -> I ran for 8 seconds");
            });

            t2.Name = "Thread T2";

            //parameterized thread
            Thread t3 = new Thread(p =>
            {
                int numberOfSeconds = 0;
                while (numberOfSeconds < Convert.ToInt32(p))
                {
                    Thread.Sleep(1000);

                    numberOfSeconds++;
                }

                Console.WriteLine("t3 ->I ran for {0} seconds", numberOfSeconds);
            });

            t3.Name = "Thread T3";

            Thread t4 = new Thread(() =>
            {
                int numberOfSeconds = 0;
                while (numberOfSeconds < 16)
                {
                    Thread.Sleep(1000);

                    numberOfSeconds++;
                }

                Console.WriteLine("t4 -> I ran for 16 seconds");
            });

            t4.Name = "Thread T4";

           
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);
            t1.Start();
            Console.WriteLine("\nCurrent thread: {0}",Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);
            t2.Start();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);
            //passing parameter to parameterized thread
            t3.Start(6);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);
            t4.Start();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);

            //wait for t1 to fimish
            t1.Join();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}\n\n", t3.ThreadState);


            //wait for t2 to finish
            t2.Join();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);

            //wait for t3 to finish
            t3.Join();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);
            //wait for t4 to finish
            t4.Join();
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread T1 {0}", t1.ThreadState);
            Console.WriteLine("Thread T2 {0}", t2.ThreadState);
            Console.WriteLine("Thread T3 {0}", t3.ThreadState);
            Console.WriteLine("Thread T4 {0}\n\n", t4.ThreadState);


            Console.WriteLine("All Threads Exited in {0} secods.", (DateTime.Now - startTime).TotalSeconds);
           

            

        }
    }
}
