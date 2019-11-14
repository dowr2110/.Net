using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace laba_8
{
   
        public interface IDol<T>
        {
            void Add(T d);
            void Delete(T d);
            void Show();

        }
        public class Test//Для пользовательского типа взять класс из лабораторной
//№5 «Наследование».
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
        }


    //Определить пользовательский класс, который будет использоваться в качестве
    //параметра обобщения.
    public class Polza<U> where U : class//ograniceniya-- universalnyy nash tip doljno doljen byt ssylocnym 
        {
        }


    //Эти интерфейсы реализуются следующими классами коллекций в пространстве имен System.Collections.Generic
    public class CollectionType<T> : IDol<T> where T : struct
        {
        //обобщённая коллекцию
        public List<T> lol = new List<T>();//List<T>: класс, представляющий последовательный список. Реализует интерфейсы IList<T>, ICollection<T>, IEnumerable<T>

        public int ID;
        public string Name { get; set; }//имя
        public string Organization { get; set; }//организацию создателя.

            public void Add(T d) { lol.Add(d); }
            public void Delete(T d) { lol.Remove(d); }
            public void Show() { Console.WriteLine(lol); }
            public int Len() { int ss = lol.Count; return ss; }
        }



        class Program
        {
            static void Main(string[] args)
            {
                string line;
                CollectionType<int> lol = new CollectionType<int>();
                Polza<Test> kek = new Polza<Test>();
                try
                {
                    lol.Show();
                    lol.Add(2);
                }
                catch { Console.WriteLine("Popalsia!"); }
                finally { Console.WriteLine("This is the end!"); }

            /*Дополнительно:
            Добавьте методы сохранения объекта (объектов) обобщённого типа
            CollectionType<T> в файл и чтения из него.*/

            StreamWriter write = new StreamWriter(@"D:\text.txt", true, System.Text.Encoding.Default);
                for (int i = 0; i < lol.Len(); i++)
                    write.WriteLine(lol.lol[i]);
                write.Close();
                StreamReader read = new StreamReader(@"D:\text.txt", System.Text.Encoding.Default);
                for (int i = 0; i < lol.Len(); i++)
                {
                    line = read.ReadLine();
                    Console.WriteLine(line);
                }
                read.Close();


            }
        }

    }

/* public string Name { get; set; }//имя
        public string Organization { get; set; }//организацию создателя.*/


//public static string[] chisla = new string[10];
//public string Value { get; set; }
//public char Simvol { get; set; }
//public class Date
//{
//    public Date() { }
//}