using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            TPL.UmnozMatrix();
            TPL.UmnozMatrixWithToken();
            TPL.Shop();
        }
        public static class TPL
        {
            public static void UmnozMatrix()
            {
                Stopwatch stopw = new Stopwatch();
                Random rnd = new Random();
                List<Task> Tasks = new List<Task>();
                for (int i = 0; i < 5; i++)
                {
                    Tasks.Add(new Task(() =>
                    {
                        int[,] matrix = { { rnd.Next(1, 10), rnd.Next(1, 10) }, { rnd.Next(1, 10), rnd.Next(1, 10) } };
                        int[,] matrix2 = { { rnd.Next(1, 10), rnd.Next(1, 10) }, { rnd.Next(1, 10), rnd.Next(1, 10) } };
                        int[,] matrixres = new int[2, 2];
                        for (int k = 0; k < 2; k++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                matrixres[k, j] = matrix[k, j] * matrix2[k, j];
                            }

                        }
                    }));

                }
                Console.WriteLine(Tasks[0].Status);
                stopw.Start();
                foreach (var task in Tasks)
                    task.Start();
                Task.WaitAll(Tasks.ToArray());
                stopw.Stop();
                Console.WriteLine(Tasks[0].Status);
                Console.WriteLine("Количество тактов при использовании Task: " + stopw.ElapsedTicks);
            }
            public static void UmnozMatrixWithToken()
            {
                Stopwatch stopw = new Stopwatch();
                Random rnd = new Random();
                List<Task> Tasks = new List<Task>();
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                for (int i = 0; i < 5; i++)
                {
                    Tasks.Add(new Task(() =>
                    {
                        int[,] matrix = { { rnd.Next(1, 10), rnd.Next(1, 10) }, { rnd.Next(1, 10), rnd.Next(1, 10) } };
                        int[,] matrix2 = { { rnd.Next(1, 10), rnd.Next(1, 10) }, { rnd.Next(1, 10), rnd.Next(1, 10) } };
                        int[,] matrixres = new int[2, 2];
                        for (int k = 0; k < 2; k++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                matrixres[k, j] = matrix[k, j] * matrix2[k, j];
                            }

                        }
                    },tokenSource.Token));

                }
                Console.WriteLine(Tasks[0].Status);
                stopw.Start();
                foreach (var task in Tasks)
                    task.Start();
                tokenSource.Cancel();
                stopw.Stop();
                Console.WriteLine(Tasks[4].Status);
                Console.WriteLine("Количество тактов при использовании Task: " + stopw.ElapsedTicks);
            }
            public static void ParallelInvoke()
            {
                Parallel.Invoke(() => { Console.WriteLine("First function"); }, () => { Console.WriteLine("Second function"); }, () => { Console.WriteLine("Third function"); });
            }
            public static void Contwith()
            {
                Task<double> task1 = Task.Run(() => { return Math.Pow(5, 6); });
                Task<double> task2 = task1.ContinueWith(x => { return Math.Pow(5, 6) * 5; });
                Task task3 = task2.ContinueWith(x => { Console.WriteLine("Ответ: " + x.Result * 10); });
                task3.GetAwaiter().GetResult();
            }
            public static async void AsyncDemonstration()
            {
                await Task.Run(Contwith);
            }
           
            public static void Shop()
            {
                Dictionary<int?, string> Product = new Dictionary<int?, string>();
                Product.Add(0, "Sofa");
                Product.Add(1, "Armchair");
                Product.Add(2, "Table");
                Product.Add(3, "Poster");
                Product.Add(4, "Stool");
                Product.Add(5, "Linoleum");
                Mutex mutex = new Mutex();
                BlockingCollection<int> SHOP = new BlockingCollection<int>();
                for (int i = 0; i < 5; i++)
                {
                    Task task1=Task.Run(() =>
                    {
                        Random rnd = new Random();

                            Thread.Sleep(rnd.Next(1000, 5000));
                            mutex.WaitOne();
                            int Counter = 0;
                            SHOP.Add(rnd.Next(0, 4));
                            Console.WriteLine("SHOP: ");
                            foreach (var product in SHOP)
                            {
                                Console.WriteLine(Product[product]);
                                Counter++;
                            }
                        if (Counter == 0)
                        {
                            Console.WriteLine("Nothing");
                        }
                            Console.WriteLine("-------------------");
                            mutex.ReleaseMutex();
                            Thread.Sleep(rnd.Next(1000, 5000));
                    });
                }
                for (int i = 0; i < 10; i++)
                {
                    Task task2=Task.Run(() =>
                    {
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(1000, 5000));
                        foreach (var product in SHOP)
                        {
                            if (true)
                            {
                                mutex.WaitOne();
                                Console.WriteLine(Product[product] + " bought");
                                Console.ResetColor();
                                Console.WriteLine("-------------------");

                                int p = product;
                                int Counter = 0;
                                SHOP.TryTake(out p);
                                Console.WriteLine("SHOP: ");
                                Counter++;
                                foreach (var productt in SHOP)
                                {
                                    Console.WriteLine(Product[productt]);

                                }
                                if (Counter == 0)
                                {
                                    Console.WriteLine("Nothing");
                                    Console.ResetColor();

                                }
                                else
                                    Counter = 0;
                                Console.WriteLine("-------------------");
                                mutex.ReleaseMutex();
                                break;
                            }
                        }
                    }); 
                }
                Thread.Sleep(5000);
            }
            public static void ParallelFor()
            {
                BlockingCollection<int> Arr = new BlockingCollection<int>();
                BlockingCollection<int> Arr2 = new BlockingCollection<int>();
                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                Parallel.For(0, 1000000, i => { Arr.Add(rnd.Next(1, 100)); Arr2.Add(rnd.Next(1, 100)); });
                stopwatch.Stop();

                Console.WriteLine("Parallel.For: \t" + stopwatch.ElapsedTicks + " ticks");

                stopwatch.Reset();
                stopwatch.Start();
                List<int> Array = new List<int>();
                for (int i = 0; i < 1000000; i++)
                    Array.Add(rnd.Next(1, 100));
                stopwatch.Stop();

                Console.WriteLine("For:\t\t" + stopwatch.ElapsedTicks + " ticks");
            }
        }
       
    }
}
