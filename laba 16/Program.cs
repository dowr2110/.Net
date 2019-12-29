using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba_16
{

    class Program
    {
        

        public static CancellationTokenSource cancelTokenSource;
        public static CancellationToken token;
        static BlockingCollection<string> BlockColl;


        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            //Console.WriteLine("\nЗадание 1\n");



            Task task00 = new Task(()=>factorial(10));
            task00.Start();
            stopWatch.Start();

            Console.WriteLine($"Статус задачи - {task00.Status}; ID - {task00.Id}");
            task00.Wait();
            stopWatch.Stop();
            Console.WriteLine($"Статус задачи - {task00.Status}; Статус завершения - {task00.IsCompleted}");
            
            Console.WriteLine("Время : " + stopWatch.ElapsedMilliseconds+"мс");
            task00.Dispose();


            Console.WriteLine("\nЗадание 2\n");
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        
            Task task01 = new Task(() => factorial(10));
            task01.Start();
            Console.WriteLine("Введите 'y' для отмены операции :");
            string g = Console.ReadLine();
            if (g=="y")
            {
                cancelTokenSource.Cancel();
            }
            task01.Wait();
            task01.Dispose();
            
           


            Console.WriteLine("\nЗадание 3\n");

            var task1 = Task.Factory.StartNew<int>(() => task11(10));//создаем использовании статического метода Task.Factory.StartNew()
            var task2 = Task.Factory.StartNew<int>(() => task22(10));
            var task3 = Task.Factory.StartNew<int>(() => task33(10));
            var task4 = new Task(() => task44(task1.Result, task2.Result, task3.Result)); //Создание объекта Task и вызова у него метода Start
            task4.Start();
            task4.Wait();//Wait Ожидает завершения выполнения задачи Task(конкретной).
            task1.Dispose();//освобождает
            task2.Dispose();

            task3.Dispose();

            Console.WriteLine("\nЗадание 4 \n");
            //задача продолжения 
            Task task5 = new Task(() => { Console.WriteLine($"ID: {Task.CurrentId}"); });
            Task task6 = task5.ContinueWith(task55);//ContinueWith, который в качестве параметра принимает делегат Action<Task>. То есть метод, который передается в данный метод в качестве значения параметра, должен принимать параметр типа Task.
            task5.Start();
            task6.Wait();//ожидавет завершение выполнение задачи таск
            task5.Dispose();//освобождает
            task6.Dispose();

            var task7 = Task.Factory.StartNew<int>(() => task11(10));////создаем использовании статического метода Task.Factory.StartNew()
            task7.Wait();
            var awaiter = task7.GetAwaiter();
            if (awaiter.IsCompleted)
            {
                Task task8 = new Task(() => { Console.WriteLine("GetAwaiter"); });
                task8.Start();
                task8.Wait();
                task8.Dispose();
            }
            task7.Dispose();
            Console.WriteLine("\nЗадание 5\n");
            int[] arr1 = new int[1000000];//генерация нескольких массивов по 1000000 элементов,
            int[] arr2 = new int[1000000];
            Random random = new Random();

            stopWatch.Restart();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next(0, 200);
                arr2[i] = random.Next(0, 200);
            }
            stopWatch.Stop();
            Console.WriteLine($"Генерация 2х массивов в for \tВремя - {stopWatch.ElapsedMilliseconds}мс");//смотрим с обычный For
            int[] arr3 = new int[1000000];
            int[] arr4 = new int[1000000];
            stopWatch.Restart();
            Parallel.For(0, arr3.Length, i =>
            {
                arr3[i] = random.Next(0, 200);
                arr4[i] = random.Next(0, 200);
            });
            stopWatch.Stop();
            Console.WriteLine($"Генерация 2х массивов в ParallelFor \tВремя - {stopWatch.ElapsedMilliseconds}мс\n");//смотрим с parallelFor
            /*Метод Parallel.For позволяет выполнять итерации цикла параллельно. Он имеет следующее определение: For(int, int, Action<int>), 
             * где первый параметр задает начальный индекс элемента в цикле, а второй параметр - конечный индекс.
             * Третий параметр - делегат Action - указывает на метод, который будет выполняться один раз за итерацию:*/
            Console.WriteLine("Задание 6\n");
            Parallel.Invoke(Inv1, Inv2);
            /*Метод Parallel.Invoke в качестве параметра принимает массив объектов Action, 
             * то есть мы можем передать в данный метод набор методов, 
             * которые будут вызываться при его выполнении.
             * Количество методов может быть различным, 
             * Опять же как и в случае с классом Task мы можем передать либо название метода, либо лямбда-выражение.

И таким образом, при наличии нескольких ядер на целевой машине данные
методы будут выполняться параллельно на различных ядрах.*/
            Console.WriteLine("\nЗадание 7>\n");
            BlockColl = new BlockingCollection<string>(5);
            //это потокобезопасный класс коллекции

            Task Sup = new Task(Supplier);
            Task Con = new Task(Consumer);
            Sup.Start();
            Con.Start();

            Task.WaitAll(Sup, Con);//WaitAll Ожидает завершения выполнения всех указанных объектов Task 
            Sup.Dispose();
            Con.Dispose();

            Console.WriteLine("\nЗадание 8 \n");

            AsyncEvenNum();

        }

        static async void AsyncEvenNum()
        {
            Console.WriteLine("Начало асинхронного метода");
            await Task.Run(() => EvenNum());
            Console.WriteLine("\nКонец асинхронного метода");
        }

        static void EvenNum()
        {
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + ", ");
                }
            }
        }

        static void Supplier()
        {
            Random random = new Random();

            int x, z;
            List<string> products = new List<string>() { "стул", "стол", "кровать", "шкаф", "тумба" };
            for (int i = 0; i < 5; i++)
            {
                x = random.Next(0, products.Count - 1);
                BlockColl.Add(products[x]);
                Console.WriteLine($"Добавлен продукт - {products[x]}");
                products.RemoveAt(x);
                Thread.Sleep(random.Next(1, 3));
            }
            BlockColl.CompleteAdding();
        }

        static void Consumer()
        {
            string str;
            while (!BlockColl.IsCompleted)
            {
                if (BlockColl.TryTake(out str))
                {
                    Console.WriteLine($"Был куплен товар - {str}");
                }
                else
                {
                    Console.WriteLine($"Покупатель ушел");
                }
            }
        }

        static void Inv1()
        {
            Console.WriteLine("Inv1 запущен");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Inv1 =" + i);
            }
            Console.WriteLine("Inv1 завершен");
        }

        static void Inv2()
        {
            Console.WriteLine("Inv2 запущен");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Inv2 =" + i);
            }
            Console.WriteLine("Inv2 завершен");
        }

        static void task55(Task t)
        {
            Console.WriteLine("Continuation Task");
            Thread.Sleep(2000);
        }

        public static int task11(int i)
        {
            i *= DateTime.Now.Day;
            return i;
        }

        static int task22(int i)
        {
            i += DateTime.Now.Day;
            return i;
        }

        static int task33(int i)
        {
            i -= DateTime.Now.Day;
            return i;
        }

        static void task44(int a, int b, int c)
        {
            int res;
            res = a + b + c;
            Console.WriteLine($"Результат: {res}");
        }


        static void factorial(int n)
        {

            int result = 1;
            for (int i = 1; i <= n; i++)
            {

                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine($"{i}! = "+result);
                Thread.Sleep(500);
            }
           
        }




    }
}


/*1) Создание объекта Task и вызова у него метода Start
Task task = new Task(() => Console.WriteLine("Hello Task!"));
task.Start();
2) использовании статического метода Task.Factory.StartNew()
Task task = Task.Factory.StartNew(() => Console.WriteLine("Hello Task!"));
3) использование статического метода Task.Run()
Task task = Task.Run(() => Console.WriteLine("Hello Task!"));
*/
