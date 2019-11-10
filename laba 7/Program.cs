using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace laba_7
{
    interface IDatak //интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    interface ITakoije // интерфейс для работы с одноименным методом
    {
        void TotJe();
    }
    struct Info
    {
        public string begin;
        public string predm;
        public string end;
    }

    enum Predm
    {
        Math, Russian, English, History
    }
    
    public static class Printer
    {
        public static void iAmPrinting(Ispitanie isp)
        {
            Console.WriteLine(isp.GetType());
            Console.WriteLine(isp.ToString());
        }
    }
   
    /// <summary>
    /// ////////////////////////////////////////////////////////// //////////////////////////////////////////////////////////
    /// </summary>
    class EkzamenException : Exception//sessiyada
    {
        public EkzamenException(string message) : base(message) { }
    }
    class PredmException : Exception//ekzamenda
    {
        public PredmException(string message) : base(message) { }
    }
    class MaxException : Exception//voprosda
    {
        public MaxException(string message) : base(message) { }
    }
    ////////////////////////////////////////////////////////// ///////////////////////////////////////////////////////////////
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
            Console.WriteLine("--00--00---- 6-aя лаба ----00--00--");
            Test test3 = new Test("Kont", "medium", 3);
            Console.WriteLine(test3.Type + " " + test3.Tst + " " + test3.Maxb + " ");
            Info ekzm;
            ekzm.begin = "30.10.2017";
            ekzm.predm = "Math";
            ekzm.end = "7.11.2017";
            Console.WriteLine("Информация о тесте: Дата начала: " + ekzm.begin + " Предмет : " + ekzm.predm + " Конец: " + ekzm.end);
            Ekzamen ekzam1 = new Ekzamen("History");
            Ekzamen ekzam2 = new Ekzamen("Russian");
            Sessia kek = new Sessia(ekzam, ekzam1, ekzam2);
            Console.WriteLine(kek.FindKol());
            kek.FindTes(1);
            Console.WriteLine("Поиск по предмету");
            kek.ToConsoleList(kek.FindEkz("Russian"));
            Console.WriteLine("--00--00---- 7-aя лаба ----00--00--");
            try
            {
                Sessia buk = new Sessia(ekzam, ekzam1, ekzam2, test);
            }
            catch (EkzamenException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Уберем сессию");
                Sessia sesia = new Sessia(ekzam, ekzam1);
            }
            try
            {
                Ekzamen ekzamen3 = new Ekzamen("Turkmen");
                ekzamen3.Name = "Turkmen";
            }
            catch (PredmException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End.");

            }
            try
            {
                Vopros v1 = new Vopros("KR", "Normal", 11);
            }
            catch (MaxException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("That's all!");
            }
            Ekzamen ekzam4 = new Ekzamen("PE");
        }
    }
}
