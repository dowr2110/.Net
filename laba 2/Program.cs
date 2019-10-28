using System;
using System.Text;

namespace laba_2
{
    class Program
    {

        static void Main(string[] args)//osnovnoy metod main
        {
            // 1 

            // a 

            int a = 5;//значимое 4 байта,
            double c = 2.50;//с двойной пл т 8, значим
            float h = 2.5f;//с одной пл т 4, значим
            char d = '1';//1 значим
            bool e = true;//1 значим
            string f = "C#";//ссылочные

            //еще значимые типы: enum, struct, long...
            //еще ссылочные типы: object, string, classes, interface,
            // b 

            float big_a = a;
            int big_d =d;
            double big2_a = a;
            double big_c = c;
            float big2_d = d;

            int c2 = (int)c;
            int d2 = (int)d;
            char a2 = (char)a;
            char c3 = (char)c;
            char d3 = (char)d;

            // c 

            int price = 39; // упаковка 
            Object obj = price;

            int price2 = (int)obj; // распоковка 

            // d 
            

            var i = 2;//???
            i += i;
            Console.WriteLine(i);

            // e 

            int? n= null;//??
            n = 9;
            // 2 

            // a 

            string str1 = "first string ";
            string str2 = "second string ";
            int result = String.Compare(str1, str2); // сравнение сток 
            Console.WriteLine(result);

            // b 

            string str3 = "third string ";
            string big_str = str1 + str2 + str3;//сцепление
            Console.WriteLine(big_str);
            string copy_str = big_str; // копирование строки 
            string search = "second";//13
            int str2_2 = copy_str.IndexOf(search); // поиск подстроки second в строке 
            Console.WriteLine(str2_2);



   



            Console.WriteLine();
            copy_str = copy_str.Insert(40, str1); // вставляем подстроку str1 на позицию 40 строки copy_str 
            Console.WriteLine(copy_str);
            copy_str = copy_str.Remove(40, 12); // удаляем подстроку str1 из строки copy_str 
            Console.WriteLine(copy_str);

            // c 

            string str4 = "jjj";
            string str5 = null;
            result = String.Compare(str4, str5); // создали пустую и null строку и сравнили их 
            Console.WriteLine(result);

            // d 

            StringBuilder str6 = new StringBuilder("Hello world!!!");//??
            Console.WriteLine(str6);
            str6.Insert(0, "begin "); // добавляем btgin в начало строки 
            str6.Insert(20, " end"); // добавляем end в конец строки 
            str6.Remove(17, 3); // удаляем "!!!" со строки 
            Console.WriteLine(str6);

            // 3 

            // a 

            Console.WriteLine();
            int x = 5;
            int y = 5;
            /*??*/int[,] mas = new int[x, y]; // создаем двухмерный массив 5х5 
            Random rn = new Random();
            for (i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    mas[i, j] = rn.Next(10); // присваиваем значения от 0 до 9 элеметнам массива 
            for (i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }

            // b 

            Console.WriteLine();
            string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" }; // создаем массив строк дни недели 
            Console.WriteLine(weekDays.Length);
            Console.WriteLine("Какой элемент изменить?");
            i = Convert.ToInt32(Console.ReadLine()); // преобразуем string в int и узнаем номер элемента, который нужно изменить 
            Console.WriteLine("Введите новое значение:");
            weekDays[i] = Console.ReadLine();
            for (i = 0; i < weekDays.Length; i++)
                Console.Write(weekDays[i] + " ");

            // c 

            Console.WriteLine();
            i = 0;
            int[][] myArr = new int[3][]; // Объявляем ступенчатый массив 
            myArr[0] = new int[2];
            myArr[1] = new int[3];
            myArr[2] = new int[4];
            for (; i < 2; i++) // Инициализируем ступенчатый массив 
            {
                myArr[0][i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < 3; i++)
            {
                myArr[1][i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < 4; i++)
            {
                myArr[2][i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            for (i = 0; i < 2; i++) // выводим ступенчатый массив 
            {
                Console.Write(myArr[0][i] + " ");
            }
            Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                Console.Write(myArr[1][i] + " ");
            }
            Console.WriteLine();
            for (i = 0; i < 4; i++)
            {
                Console.Write(myArr[2][i] + " ");
            }

            // d 

            var mass_box = weekDays; // для хранения массива 
            var str_box = str6; // для хранения строки 

            // 4 

            // a 

            Console.WriteLine();
            (int, string, char, string, ulong) krt = (5, "c#", 'a', "world", 57); // объявление и инициализация кортежа 
            (int, string, char, string, ulong) krt2 = (5, "c#", 'a', "world", 58);

            // b

            Console.WriteLine();
            Console.WriteLine(krt); // вывод кортежа 
            Console.WriteLine(krt.Item1 + " " + krt.Item3 + " " + krt.Item4); // вывов 1, 3 и 4 элементов кортежа 

            // c 

            int item1 = krt.Item1; // распаковка кортежа в переменные    
            string item2 = krt.Item2;//??
            char item3 = krt.Item3;
            string item4 = krt.Item4;
            ulong item5 = krt.Item5;

            // d 

           bool compare = (krt.Equals(krt2));/// сравнение кортежей 
            Console.WriteLine(compare);
            // 5 

            /*??*/int[] arr = new int[] { 1, 2, 3, 4, 5 }; // массив для функции 
            void func(int[] arr2, string str7) // создаем локлаьную функцию 
            {
                int min = arr2[0];
                int max = arr2[0];
                int sum = 0;
                (int, int, int, char) krt3; // кортеж для записи результата 
                for (i = 0; i < arr2.Length; i++) // поиск максимального и минимального элементов и суммы всех элементов 
                {
                    if (arr2[i] < min)
                        min = arr2[i];
                    if (arr2[i] > max)
                        max = arr2[i];
                    sum += arr2[i];
                }
                char ch1 = str7[0]; // поиск первого символа строки 
                krt3.Item1 = min; // инициализация элементов кортежа 
                krt3.Item2 = max;
                krt3.Item3 = sum;
                krt3.Item4 = ch1;
                Console.WriteLine(krt3); // вывод кортежа 
            }
            func(arr, "hola"); // вызов локлаьной функции 
        }
    }
}
