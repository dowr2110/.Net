using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Испытание, Тест, Экзамен, Выпускной экзамен, Вопрос;*/
namespace ConsoleApp1
{
    interface Datak //интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    interface ITakoije // интерфейс для работы с одноименным методом
    {
        void TotJe();
    }

    public static class Printer
    {
        public static void iAmPrinting(Ispitanie isp)
        {
            Console.WriteLine(isp.GetType());
            Console.WriteLine(isp.ToString());
        }
    }


    class Glavni
    {
        static void Main(string[] args)
        {
            Test test = new Test("Kontrol", "Hard", 10);
            Test test2 = new Test("Obichni", "Easy", 10);
            Vopros vopr = new Vopros("", "Easy", 10);
            Ekzamen ekzam = new Ekzamen("Math");
            VipusknoiEkzamen vipusk = new VipusknoiEkzamen();
            Console.WriteLine(test.Tst + " " + test.Diffic + " " + test.Maxb);
            test.Tst = "Kontrolni";
            Console.WriteLine(test2.Tst + " " + test2.Diffic + " " + test2.Maxb);
            Console.WriteLine("------------------");
            test.ToConsole();
            test.Info();
            Console.WriteLine("------------------");
            test2.ToConsole();
            test2.Info();
            Console.WriteLine("------------------");
            // работа с одноименными методами
            test.TotJe();
            ((ITakoije)test).TotJe();
            Console.WriteLine("------------------");
            ((test2 as ITakoije)).TotJe(); // работа по ссылке (as)
            test2.TotJe();
            Console.WriteLine(test.Tst is string ? "is" : "is not");
            Console.WriteLine("------------------");
            Printer.iAmPrinting(test);
            Printer.iAmPrinting(test2);
            Printer.iAmPrinting(vopr);
            object[] mas = { test, test2, vopr, ekzam, vipusk };
        }
    }
}
