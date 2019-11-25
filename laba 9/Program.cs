using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс Пользователь с событиями upgrade и work. В main
создать некоторое количество объектов (ПО). Подпишите объекты
на события произвольным образом. Реакция на события может
быть следующая: обновление версии, вывод сообщений и т.п.
Проверить результаты изменения объектов после наступления
событий.-done

 1. Используя делегаты (множественные) и события промоделируйте
ситуации, приведенные в таблице ниже.-done
При реализации методов везде где возможно
использовать лямбда-выражения.-done
2. Создайте пять методов пользовательской обработки строки (например,
удаление знаков препинания, добавление символов, замена на заглавные,
удаление лишних пробелов и т.п.).-done Используя стандартные типы делегатов
(Action, Func) организуйте алгоритм последовательной обработки строки
написанными вами методами.-done*/

namespace OOTP9
{
    public delegate void Doing();
    public delegate bool IsWorkUser(bool workUSER);
    public class User
    {
        public double version;
        public string name;
        public bool iswork = false;
        public User(string nam, double ver)
        {
            name = nam;
            version = ver;
        }
        public event Doing Upgrade;//sobytie
        public event Doing Work;//sobytie

        public void Up()//Реакция на события;обновление версии
        {
            Console.WriteLine("Замечен апгрейд!");
            Console.WriteLine("Производится обновление версии!");
            Upgrade?.Invoke();
          
        }

        public void Working()//Реакция на события;вывод сообщений 
        {
            Console.WriteLine("Начало работы!");
            Work?.Invoke();
        }

        public void Upe()//Проверить результаты изменения объектов после наступления событий.
        {
            version += 0.1;
            Console.WriteLine("Версия обновленна!");
            Console.WriteLine("Актуальная версия:" + version);
        }

        public void Worke()//Проверить результаты изменения объектов после наступления событий.
        {
            Console.WriteLine("Он заработал!");
            iswork = true;
            if (iswork == true)
                Console.WriteLine("Состояние:ON");
            else
                Console.WriteLine("Состояние:OFF");
        }

        /////////////////////////////////////// Создайте пять методов пользовательской обработки строки 
        public void StrUdZnak(string a, Action<string> test1) => test1(a);
        public void StrDobSimv(string a, int pozit, string j, Action<string, int, string> test3) => test3(a, pozit, j);
        public void StrDobProb(string a, int pozition, Action<string, int> test4) => test4(a, pozition);
        public void StrUdSimv(string a, char x, Action<string, char> test5) => test5(a, x);
        public string StrZaglav(string a, Func<string, string> test2)
        {
            return test2(a);
        }
   
        ///////////////////////////////////////////////////////
    }

    class Program
    {
        static void Main(string[] args)
        {
            User PO1 = new User("Salam", 1.0);//В main создать некоторое количество объектов
            User PO2 = new User("Dowran", 0.1);
            User PO3 = new User("TmAshgabat.tm", 0.12);
            PO1.Upgrade += new Doing(PO1.Upe);//Подпишите объекты на события произвольным образом
            PO1.Upgrade += new Doing(PO1.Worke);//Подпишите объекты на события произвольным образом
            
            PO1.Working();
            PO1.Up();
            PO2.Work += new Doing(PO2.Worke);//Подпишите объекты на события произвольным образом
            PO2.Working();
            //Doing d = PO1.Up;
            //d += PO1.Working;
            //d();




            //При реализации методов везде где возможно использовать лямбда-выражения.
      //    public void StrUdZnak(string a, Action<string> test1) => test1(a);
                                                 //-standartnye delegat//Используя стандартные типы делегатов (Action, Func) организуйте алгоритм последовательной обработки строки
            Action<string> test1;               // написанными вами методами
            test1 = (string n) =>//lyambda vyrajen
            {
                int d;
                if (n.Contains('.'))
                {
                    d = n.IndexOf('.');
                    n = n.Remove(d, 1);
                }
                if (n.Contains(','))
                {
                    d = n.IndexOf(',');
                    n = n.Remove(d, 1);
                }
                Console.WriteLine(n);
            };
            test1("ss.");
            PO3.StrUdZnak(PO3.name, test1);



       /* public string StrZaglav(string a, Func<string, string> test2)
        {
            return test2(a);
        }*/
            Func<string, string> test2;
            test2 = (string m) =>
            {
                m = m.ToUpper();
                Console.WriteLine(m);
                return m;
            };
            PO2.StrZaglav(PO2.name, test2);


            //public void StrDobSimv(string a, int pozit, string j, Action<string, int, string> test3) => test3(a, pozit, j);
            Action<string, int, string> test3;
            test3 = (string stroka, int poz, string simv) =>
            {
                stroka = stroka.Insert(poz, simv);
                Console.WriteLine(stroka);
            };
            PO3.StrDobSimv(PO3.name, 3, "MASHINA", test3);


            //public void StrDobProb(string a, int pozition, Action<string, int> test4) => test4(a, pozition);
            Action<string, int> test4;
            test4 = (string stroka, int poz) =>
            {
                stroka = stroka.Insert(poz, " ");
                Console.WriteLine(stroka);
            };
            PO2.StrDobProb(PO2.name, 1, test4);

            // public void StrUdSimv(string a, char x, Action<string, char> test5) => test5(a, x);
            Action<string, char> test5;
            test5 = (string stroka, char simv) =>
            {
                int b;
                if (stroka.Contains(simv))
                {
                    b = stroka.IndexOf(simv);
                    stroka = stroka.Remove(b, 1);
                }
                Console.WriteLine(stroka);
            };
            PO1.StrUdSimv(PO1.name, 'l', test5);
            
        }
    }
}

//public IsWorkUser IsWork = s1 => s1 is true;
//Console.WriteLine(PO1.IsWork(PO1.iswork));