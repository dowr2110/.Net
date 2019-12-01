using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace laba_10_tren
{
    /*Повторите задание п.2 для пользовательского типа данных (в качестве типа
    T возьмите любой свой класс из лабораторной №5 (Наследование…. ). Не
    забывайте о необходимости реализации интерфейсов (IComparable,
    ICompare,….). При выводе коллекции используйте цикл foreach.*/

    interface IDatak //интерфейс - набор абстрактных членов(методов, свойств и тд.), которые должны быть реализованы в производнных классах.
    {// можно создать объект интерфейса
        void Info();
    }
    class Test : IDatak
    {
        protected string typeoftest; // поле тип теста
        protected string difficult;
        protected int maxball;

        public Test(string type, string dif, int max)
        {
            typeoftest = type;
            difficult = dif;
            maxball = max;
        }
        public string Tst
        {
            get { return typeoftest; }
            set { typeoftest = value; }
        }
        public string Diffic
        {
            get { return difficult; }
            set { difficult = value; }
        }
        public int Maxb
        {
            get { return maxball; }
            set { maxball = value; }
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(typeoftest);
            Console.WriteLine(difficult);
            Console.WriteLine(maxball);
        }

    }
    class Polza<T> where T : Test
    {
        public List<T> kek = new List<T>();
        public Stack<T> lol = new Stack<T>();

        public void Addd(T elem)
        {
            kek.Add(elem);

        }

        public void Pushh(T elem)
        {
            lol.Push(elem);
        }
        public void Write()
        {
            foreach (Test a in kek)
                Console.Write("{0}\t", a.Tst);
            Console.WriteLine("\n");
        }
        public void Writestack()
        {
            foreach (Test a in lol)
                Console.Write("{0}\t", a.Tst);
            Console.WriteLine("\n");
        }
        public void SearchEl(T a, ref Stack<T> arr)
        {
            if (arr.Contains(a) == true)
            {
                Console.WriteLine("Такой элемент присутствует!" + a.Tst);
            }
        }
    }

    class Student
    {
        public string name; // имя
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }

    class Program
    {
        public static ArrayList NewCollection(int i)
        {
            Random ran = new Random();
            ArrayList arr = new ArrayList();//Создать необобщенную коллекцию ArrayList.
                                            //заполните ее 5-ю случайными целыми числами
            for (int j = 0; j < i; j++)
                arr.Add(ran.Next(1, 50));//от 1 до 50
            return arr;
        }
        public static void RemoveElement(int i, ref ArrayList arr)
        {
            arr.RemoveAt(i);//Удалите заданный элемент
        }
        public static void SearchElement(string a, ref ArrayList arr)
        {
            if (arr.Contains(a) == true)//Выполните поиск в коллекции значения
            {
                Console.WriteLine("Такой элемент присутствует!Его индекс:" + arr.IndexOf(a));
            }
        }
        public static void AddElementStr(string str, ref ArrayList arr)
        {
            arr.Add(str);//Добавьте к ней строку
        }
        public static void WriteCollect(ArrayList arr)
        {
            foreach (object a in arr)//Выведите количество элементов и коллекцию на консоль.
                Console.Write($"{a}\t");
            Console.WriteLine("\n");
        }




        public class Listt<T> where T : struct
        {//List<T> float Stack<T>
            public List<T> kek = new List<T>();
            public Stack<T> lol = new Stack<T>();

            public void Addd(T elem)//Добавьте другие элементы (используйте все возможные методы добавления для вашего типа коллекции).
            {
                kek.Add(elem);
            }
            public void Pushh(T elem)//Создайте вторую коллекцию (см. таблицу) и заполните ее данными из первой коллекции.
            {
                lol.Push(elem);//добавляет элемент в стек на первое место
            }

            public void Write()//Вывести коллекцию на консоль
            {
                foreach (object a in kek)
                    Console.Write($"{a}\t");
                Console.WriteLine("\n");
            }
            public void Writestack()//Выведите вторую коллекцию на консоль.
            {
                foreach (object a in lol)
                    Console.Write($"{a}\t");
                Console.WriteLine("\n");
            }

            public void SearchEl(T a, ref Stack<T> arr)//Найдите во второй коллекции заданное значение.//пар по ссылке
            {
                if (arr.Contains(a) == true)
                {
                    Console.WriteLine("Такой элемент присутствует! " + a);
                }
                else
                    Console.WriteLine("Такой элемент не присутствует!");
            }
        }


        /*Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
произвольный метод и зарегистрируйте его на событие CollectionChange.
Напишите демонстрацию с добавлением и удалением элементов. В качестве
типа T используйте свой класс из лабораторной №5 Наследование….*/

        public static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        {
            Console.WriteLine("Коллекция изменена!");
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление

                    Console.WriteLine("Добавлен новый объект");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление

                    Console.WriteLine("Удален объект");
                    break;

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////       //////////////////////////////////////////////////////////////////
            Console.WriteLine("ЗАДАНИЕ 1\n");
            int kol = 0;
            ArrayList Coll = NewCollection(5);
            Console.WriteLine("Исходная коллекция чисел: ");
            WriteCollect(Coll);


            Console.WriteLine("Добавили 1 элемент(строка): ");
            AddElementStr("KEK", ref Coll);

            Student Dowr = new Student();
            Dowr.Name = "Dowr";
            Coll.Add(Dowr.Name);
            WriteCollect(Coll);

            for (int i = 0; i < Coll.Count; i++)
            {
                kol++;
            }
            Console.WriteLine("Кол-во элементов листа: " + kol);

            RemoveElement(2, ref Coll);
            Console.WriteLine("Удален 2й элемент");
            WriteCollect(Coll);

            SearchElement("KEK", ref Coll);


            ///////////////////////////////////////////////////////////    ////////////////////////////////////////////////////////////////
            //kek-List
            //lol-stack

            Console.WriteLine("\nЗАДАНИЕ 2\n");
            Listt<float> ux = new Listt<float>();
            ux.Addd(3.5f);
            ux.Addd(4);
            ux.Addd(5);
            ux.Addd(5.5f);
            /*Создайте вторую коллекцию (см. таблицу) и заполните ее данными из первой коллекции.*/
            for (int i = 0; i < ux.kek.Count; i++)
            {
                ux.Pushh(ux.kek[i]);
            }
            Console.WriteLine("Вывести коллекцию на консоль");
            ux.Write();
            Console.WriteLine("Удален из коллекции 1й элемент");
            ux.kek.RemoveRange(0, 1);//RemoveRange-удаляет диапазон элементов из списка
            ux.Write();

            Console.WriteLine("Вывести стек на консоль");
            ux.Writestack();
            Console.WriteLine("Найдите во второй коллекции заданное значение");
            ux.SearchEl(5, ref ux.lol);


            //////////////////////////////////////////////////////////////// ////////////////////////////////////////////////////////////////
            Console.WriteLine("\nЗАДАНИЕ 3\n");
            Test ekzemp = new Test("plus", "normal", 10);
            Test ekeemp = new Test("minus", "hard", 10);
            Polza<Test> p = new Polza<Test>();
            p.Addd(ekzemp);
            p.Addd(ekeemp);
            for (int i = 0; i < p.kek.Count; i++)
            {
                p.Pushh(p.kek[i]);
            }
            Console.WriteLine("Вывести коллекцию на консоль");
            p.Write();
            Console.WriteLine("Удален из коллекции 1й элемент");
            p.kek.RemoveRange(0, 1);//RemoveRange-удаляет диапазон элементов из списка
            p.Write();

            Console.WriteLine("Вывести стек на консоль");
            p.Writestack();
            Console.WriteLine("Найдите во второй коллекции заданное значение");
            p.SearchEl(ekeemp, ref p.lol);
            //////////////////////////////////////////////////////////////// ////////////////////////////////////////////////////////////////

            Console.WriteLine("\nЗАДАНИЕ 4\n");
            var data = new ObservableCollection<Test>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add(ekzemp);
            data.Add(ekeemp);
            data.Remove(ekeemp);
        }


       

    }
}
