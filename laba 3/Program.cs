using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{

    class Airline//обьект, а дальше поля обьекта
    {
        //get set
        private readonly int id;//для определения данных мы можем через переменных,константных и поля для чтения,
                                //readonly - поля для чтения,
                                //мы можем задать значения при определении либо при конструкторе,
                                //в остальных местах мы не можем изменить его значения,например с методе не можем изменить.
        public string PunktNaznaceniya { get; set; }   //свойства - для управления доступа к переменной//
                                                       //названия переменной обычно начинается  большой буквой с свойствах 
                                                       //блок get and set- для чтение и для записи//
                                                       //--get-возвращение значения переменной,например //get {return "blabla}"
                                                       //set-устанавливай значения переменной //например set{peremennaya == value}
        public static int count = 0;
                        // модификатор доступа static не нужно создавать обьект а можно обращаться через точку,через названия класса
                      //static-- не является принадлежностью собственного обьекта,то что статичное является принадлежностью не посрественно класса
                        //можно обращаться к методом без создания обьекта, если они обьявлены статический
                         //общим для всех экземплров класса

        public int NomerReysa { get; set; }
        public string TipSamoleta { get; set; }
        public string WremyaWyleta { get; set; }
        public string WeekDays { get; set; }




        /* а в чем отличия конструктора от метода я так и не понял
         зачем исползуются конструкторы я не знаю*/

        /*конструктор - это специальный метод класса который 
         1)создает экземпляр класса
         2)называется как класс
         3)не имеет типа возвращаемого значения

         они бывают 2 вида 
         1)по умолчанию
         2)с параметрами
         у класса всегда есть конструктор по умолчаниюбесли вы не обьявите никакой другой конструктор

         Перегрузка(overloading) - это использования методов 
         в одном классе
         с одинаковым названием
         но разными параметрами
         и разным типом возвращаемого значения

        ~деструктор(метод завершения)
        при завершения программы
        он нужен для уничтожения экземпляров класса
         */

        public Airline()// обычный конструктор
        {
            count++;//ЧТО ДЕЛАЕТ КОНСТРУКТОРЫЫ??
            id = count;
           
        }
        
        public Airline(string _PunktNaznaceniya, int _NomerReysa) : this() //конструктор с 2 параметрами

        {
            PunktNaznaceniya = _PunktNaznaceniya;//ЧТО ДЕЛАЕТ КОНСТРУКТОРЫЫ
            NomerReysa = _NomerReysa;
            //  id = PunktNaznaceniya.GetHashCode() + NomerReysa.GetHashCode();
        }

        //this() --что переменная является именно переменной класса
        //можно и this.Firstname
        //если _FirstNames то есть не одинаковые названия-то можно и без this()
        public Airline(string _PunktNaznaceniya, int _NomerReysa, string _WeekDays) : this()     //конструктор с 3 параметрами
        {
            PunktNaznaceniya = _PunktNaznaceniya;//ЧТО ДЕЛАЕТ КОНСТРУКТОРЫЫ
            NomerReysa = _NomerReysa;
            WeekDays = _WeekDays;
            //  id = PunktNaznaceniya.GetHashCode() + NomerReysa.GetHashCode();//.gethashcode-- что это??
        }
        ~Airline()//деструктор
        {
            count--;//ОЧИЩАЕТ
        }

        public static int getCount()//МЕТОД
        {
            return count;
        }
        public void Print()
        {
            Console.WriteLine("Пункт назначения : " + PunktNaznaceniya);
            Console.WriteLine("Номер рейса : " + NomerReysa);
            Console.WriteLine("День недели : " + WeekDays + "\n");
           
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("Добро пожаловать в TurkishAirlines :)\n\n ");

            Airline[] TurkishAirlines = new Airline[3];//создаем 3 обьекта класса Abirurient
            TurkishAirlines[0] = new Airline();//на первый обьект присваиваем первый конст
            TurkishAirlines[1] = new Airline("Ashgabat", 5);//на второй обьект присваиваем второй который с 2 параметрами
            TurkishAirlines[2] = new Airline("Berlin", 7 , "monday");//на третий обьект присваиваем  и третий с 3 параметрами

            TurkishAirlines[0].PunktNaznaceniya = "Ashgabat";
            TurkishAirlines[0].NomerReysa = 18;
            TurkishAirlines[0].WeekDays = "thuesday";
            TurkishAirlines[1].WeekDays = "friday";

            for (int i = 0; i < 3; i++)
            {
                TurkishAirlines[i].Print();
            }



            string znac1,znac2;
            Console.WriteLine("Введите пункт назначения : ");
            znac1 = Console.ReadLine();
           
            Console.WriteLine($"список рейсов для заданного пункта назначения({znac1}):");
                foreach (Airline x in TurkishAirlines)//??
                {
                     if (x.PunktNaznaceniya == znac1)
                    {
                    Console.WriteLine(x.NomerReysa);
                    }
                
                }
                Console.WriteLine();

            Console.WriteLine("Введите день недели : ");
            znac2 = Console.ReadLine();

            Console.WriteLine($"список рейсов для заданного дня недели({znac2}):");
            foreach (Airline x in TurkishAirlines)
                {
                    if (x.WeekDays == znac2)
                    {
                    Console.WriteLine(x.NomerReysa);
                     }
                    
                }
        }

    }
    }

//partial class Airline  //partial- частичный класс //спроси как пользоваться!!!!
//{}

//public override string ToString()//переопределение метода// для чего испол??
//{
//    return ();
//}





/*
  Console.WriteLine("список рейсов для заданного пункта назначения;:");//список рейсов для заданного пункта назначения;
foreach (Airline x in planes) //watch about foreach
  {
   //   Console.WriteLine(x.getAvg());
  }
  Console.WriteLine($"\nNumber of abiturients is {Airline.getCount()}.");


Console.WriteLine("список рейсов для заданного дня недели;.:");//список рейсов для заданного пункта назначения;
foreach (Airline x in planes) //watch about foreach
{
  //Console.WriteLine(x.getAvg());
}*/
