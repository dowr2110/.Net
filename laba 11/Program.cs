using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOTP11
{
    public class Student
    {
        public string ID;
        public string FIO;
        public int DR;
        public string Adress;
        public string Nomertelefona;
        public string Fakyltet;
        public int Kyrs;
        public int Gruppa;

        public Student(string I, string Fi, int dr, string Ad, string Num, string Fak, int K, int Gr)//конструктор
        {
            ID = I;
            FIO = Fi;
            DR = dr;
            Adress = Ad;
            Nomertelefona = Num;
            Fakyltet = Fak;
            Kyrs = K;
            Gruppa = Gr;
            //kol++;
        }

        public int Raschet(int dr, int k)//метод
        {
            int c = 18;
            dr = 0;
            c = c + (k - 1);
            return c;
        }

        public string Id//свойста
        {
            get { return ID; }
            set
            {
                 ID = value;   
            }
        }
        public string Nomert//свойста
        {
            get { return Nomertelefona; }
            set
            {
                Nomertelefona = value;
            }
        }
        public string Fio//свойста
        {
            get { return FIO; }
            set
            {
                FIO = value;
            }
        }
        public static void INFO(Student cla)
        {
            Console.WriteLine("ИНФО О КЛАССЕ:");
            //Console.WriteLine("Количество объектов:" + kol);
            Console.WriteLine("ID:" + cla.ID);
            Console.WriteLine("ФИО:" + cla.FIO);
            Console.WriteLine("День Рождения:" + cla.DR);
            Console.WriteLine("Адрес:" + cla.Adress);
            Console.WriteLine("Номер телефона:" + cla.Nomertelefona);
            Console.WriteLine("Факультет:" + cla.Fakyltet);
            Console.WriteLine("Курс:" + cla.Kyrs);
            Console.WriteLine("Группа:" + cla.Gruppa);
        }
   
    }
    class Program
    {
        static void Main(string[] args)
        {
            //запрос выбирающий последовательность месяцев с длиной строки равной n
            //massiw strok
            string[] mas = new string[] { "January", "February", "Mart", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int k = 4;
            Console.WriteLine("Равно n-4 ---------------------------------\n");
            // Использование точечной нотации
            IEnumerable<string> rezult1 = mas
                 .Where(n => (n.Length == k))
                 .Select(n => n);
            foreach (string month in rezult1)
            {
                Console.WriteLine(month);
            }




            Console.WriteLine();
            //запрос возвращающий только летние и зимние месяцы,
            Console.WriteLine("летние и зимние месяцы---------------------------------\n");
            // Использование точечной нотации
            IEnumerable<string> rezult2 = mas
                .Where(n => (n.Equals("December") || n.Equals("January") || n.Equals("February") || n.Equals("June") || n.Equals("July") || n.Equals("August")))
                .Select(n => n);
            foreach (string month in rezult2)
            {
                Console.WriteLine(month);
            }



            Console.WriteLine();
            //запрос вывода месяцев в алфавитном порядке,
            Console.WriteLine("SORT месяцев---------------------------------\n");
            // Использование синтаксиса выражения запроса
            //sort
            var ordered = from i in mas
                          orderby i
                          select i;
            foreach (string month in ordered)
            {
                Console.WriteLine(month);
            }



            Console.WriteLine();
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..
            Console.WriteLine("содержащие букву «u» и длиной имени не менее 4-х---------------------------------\n");
            // Использование точечной нотации
            IEnumerable<string> rezult3 = mas
                .Where(n => (n.Contains('u') && n.Length >= 4))
                .Select(n => n);
            foreach (string month in rezult3)
            {
                Console.WriteLine(month);
            }





            Console.WriteLine();
            /*Создайте коллекцию List<T> и параметризируйте ее типом (классом) из лабораторной №3*/
            Console.WriteLine("список студентов заданной специальности -TOV---------------------------------\n");
            List<Student> spisok = new List<Student>();//obobsh spisok t tipom student
            Student first = new Student("1", "Dowr", 30, "Central", "375", "FIT", 2, 4);
            Student second = new Student("2", "DOD", 01, "Central", "829", "IEF", 1, 7);
            Student third = new Student("3", "Bro", 10, "Central", "332", "TOV", 2, 4);
            spisok.Add(first);//dobavl v spisok
            spisok.Add(second);//dobavl v spisok
            spisok.Add(third);//dobavl v spisok
            // Использование точечной нотации
            IEnumerable<Student> rezult4 = spisok
               .Where(n => (n.Fakyltet == "TOV"))
               .Select(n => n);
            foreach (Student month in rezult4)
            {
                Console.WriteLine(month.FIO);
            }




            Console.WriteLine();
            Console.WriteLine("список заданной учебной группы-Gruppa 4,kurs 2---------------------------------\n");
            // Использование точечной нотации
            IEnumerable<Student> rezult5 = spisok
              .Where(n => (n.Gruppa == 4 && n.Kyrs == 2))
              .Select(n => n);
            foreach (Student month in rezult5)
            {
                Console.WriteLine(month.FIO);
            }




            Console.WriteLine();
            Console.WriteLine("самого молодого студента---------------------------------\n");
            // Использование синтаксиса выражения запроса
            var result6 = from i in spisok
                          where (i.Kyrs == 1)
                          select i;
            foreach (Student month in result6)
            {
                Console.WriteLine(month.FIO);
            }



            Console.WriteLine();
            Console.WriteLine("количество студентов заданной группы упорядоченных по ФИО-Gruppa 4,kurs 2----------------------------------\n");
            // Использование синтаксиса выражения запроса
           var result7 = from i in spisok
                          where (i.Gruppa == 4 && i.Kyrs == 2)
                          orderby i.FIO
                          select i;
            foreach (Student month in result7)
            {
                Console.WriteLine(month.FIO);
            }
            Console.WriteLine("Количество : " + result7.LongCount());


            Console.WriteLine();
            Console.WriteLine("первого студента с заданным именем -'DOD'---------------------------------\n");
            // Использование точечной нотации
            var result8 = spisok
                .First(p => (p.FIO == "DOD"));//возвращает первый элемент последовательности,удавлетворяющий указанному условию
            Console.WriteLine(result8.ID);





            /*Придумайте и напишите свой собственный запрос, в котором было
бы не менее 5 операторов из разных категорий: условия, проекций,
упорядочивания, группировки, агрегирования, кванторов и разиения.*/
            Console.WriteLine("Свой запрос---------------------------------\n");
            // Использование точечной нотации
            var result9 = spisok
            .Where(p => (p.Raschet(p.DR, p.Kyrs) <= 18))
            .OrderBy(p=>p)
            .Select(p=>p);
            foreach (Student month in result9)
            {
                Console.WriteLine(month.FIO);
            }




            //с лекции
            Console.WriteLine("\nзапрос Join---------------------------------\n");
            string[] names = { " Анна", " Станислав", " Ольга", "Сева" };
            int[] key = { 1, 4, 5, 7 };
            var sometype = names
            .Join(
            key,// внутренняя
            w => w.Length, // внешний ключ выбора
            q => q,// внутренний ключ выбора
            (w, q) => new // результат
            {
                id = w,
                name = string.Format("{0} ", q),
            });
            foreach (var item in sometype)
                Console.WriteLine(item);
    }
    }
}
//отличие между точечной нотации и синтаксиса выражения запроса
//отличие между var и ienumerable<>
//rabota tocecnoy natacii(n=>n)

//Проекция-- позволяет спроектировать из текущего типа выборки какой-то другой тип