using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace laba_15
{
    class Program
    {
        static FileInfo oshfile = new FileInfo("obshfile.txt");
        static AutoResetEvent waitHandler = new AutoResetEvent(false);//??
        static AutoResetEvent waitHandler2 = new AutoResetEvent(false);
        static int w = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 1");
            //работаем с процессами//запущенные процессы
            foreach (Process pr in Process.GetProcesses())
            {
                Console.WriteLine("Имя процесса: " + pr.ProcessName + " Приоритет: " + pr.BasePriority + /*" Время запуска: " + pr.StartTime + */" Состояние: " + pr.Responding + /*" Использование времени процессора: " + pr.PrivilegedProcessorTime*/ " ID: " + pr.Id);
            }


            Console.WriteLine("\nЗАДАНИЕ 2");
            // исследуем текущий домен
            Console.WriteLine("исследуем текущий домен");
            AppDomain domain = AppDomain.CurrentDomain;//cto takoye domen?
            Console.WriteLine("Name: " + domain.FriendlyName);//imya domena
            Console.WriteLine("Directory: " + domain.BaseDirectory);//?
            foreach (Assembly a in domain.GetAssemblies())//sborki domena
            {
                Console.WriteLine(a.GetName().Name);
            }
            //создаем домен, загружаем туда сборку, выгружаем домен
            Console.WriteLine("создаем домен, загружаем туда сборку, выгружаем домен");
            AppDomain secdomain = AppDomain.CreateDomain("Second Domain");//sozdaem
            secdomain.Load(new AssemblyName("laba 15"));//zagrujaem nashu sborku
            Console.WriteLine("Name: " + secdomain.FriendlyName);//imya domena
            foreach (Assembly a in secdomain.GetAssemblies())//vyvodim vse sborki
            {
                Console.WriteLine(a.GetName().Name);
            }
            AppDomain.Unload(secdomain);//vygrujaem domena



            Console.WriteLine("\nЗАДАНИЕ 3");
            //работаем с потоками
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Thread mythread = new Thread(new ParameterizedThreadStart(ToConsoleFile));//делегат threadstart
            mythread.Start(n);
            mythread.Name = "MyThread00";
            Console.WriteLine("Поток: " + mythread.Name + " Состояние: " + mythread.ThreadState + " Приоритет: " + mythread.Priority);
            for (int i = 1; i <= n; i++)
            {

                Console.WriteLine("Главный поток: " + i);//glavnyy potok eto main
                Thread.Sleep(500);//priostanavlivaem glavn potok na 500millisekunt
                mythread.Suspend();//priostanavlivaem nash potok
            }
            mythread.Resume();//kak zakoncirsya gl potok , nash potok vozobnavlyaetsya



            Console.WriteLine("ЗАДАНИЕ 4");
            Console.WriteLine("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            using (FileStream fs = new FileStream(oshfile.ToString(), FileMode.Create, FileAccess.Write))
            { }
            Thread first = new Thread(new ParameterizedThreadStart(Chet));//thread-sazdaet potok
            Thread second = new Thread(new ParameterizedThreadStart(Nechet));
            second.Priority = ThreadPriority.Highest;//Поменяйте приоритет одного из потоков.
            Console.WriteLine("приоритет второго потока : ");
            Console.WriteLine(second.Priority);
            Console.WriteLine("приоритет первого потока :");
            Console.WriteLine(first.Priority);
            //последовательно выводились одно четное, другое нечетное.
            first.Start(x);
            second.Start(x);

            Console.WriteLine("ЗАДАНИЕ 5");
            Console.WriteLine("Введите количество секунд(таймер): ");
            int ch;
            ch = int.Parse(Console.ReadLine());
            ///////////////////////////////////////////////////////////////////////////////////////
            TimerCallback tm = new TimerCallback(TimerSec); // метод обратного вызова
            Timer tmr = new Timer(tm, ch, 500, 1000);
            Thread.Sleep(ch * 10000);
            tmr.Dispose();
            Console.ReadKey();
        }





        public static void TimerSec(object obj)
        {
            w++;
            int x = (int)obj;
            Console.WriteLine("Таймер: {0}", w);
            if (w == x)
            {
                Console.WriteLine("Время вышло!");
                Process music = Process.Start("shum.mp3");
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////

        public static void Chet(object x)//why object
        {
            int n = (int)x;
            for (int i = 1; i < n; i++)
            {
                if ((i % 2) == 0)
                {
                    Console.WriteLine("First Thread: " + i);
                    Thread.Sleep(300);

                    using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write("First Thread: " + i + " ");
                    }
                    waitHandler.WaitOne();
                    waitHandler2.Set();
                }
            }
            //waitHandler.Set(); // 4.1)
        }
        
        public static void Nechet(object x)
        {
            //waitHandler.WaitOne(); // 4.1) 
            int n = (int)x;
            for (int i = 1; i < n; i++)
            {
                if ((i % 2) != 0)
                {
                    Console.WriteLine("Second Thread: " + i);
                    Thread.Sleep(500);
                    using (StreamWriter writer = new StreamWriter(oshfile.ToString(), true, System.Text.Encoding.Default))
                    {
                        writer.Write(" Second Thread: " + i + " ");
                    }
                    waitHandler.Set();
                    waitHandler2.WaitOne();
                }

            }
        }
        
        public static void ToConsoleFile(object x)
        {
            FileInfo file = new FileInfo("file.txt");
            int n = (int)x;
            for (int i = 1; i <= n; i++)
            {

                Console.Write("Второстепенный поток: " + i + "\n");
                using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
                {
                    writer.Write(i + " ");
                }
                Thread.Sleep(500);//priostanavlivaet potok na zadannyy millisekunt
            }
        }


    }
}
