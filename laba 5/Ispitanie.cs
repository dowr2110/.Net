using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Ispitanie
    {
        /*protected: такой член класса доступен из любого места в текущем классе или в производных классах.
         * При этом производные классы могут располагаться в других сборках.*/
        protected string type;//polya
        protected string test;//polya
        protected string ekzamen;//polya

        public Ispitanie()//konstruktor po umol
        {
            test = "Обычный тест";//zadayem znacenie
            ekzamen = "Лучше не шутить";//zadayem znacenie
        }
        public string Type { get; set ; }//svoistva
        //метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        public override string ToString() // переопределяем метод 
        {
            return " " + base.ToString() + " " + Type;
        }
        public abstract void ToConsole(); // метод абстрактного класса
        public abstract void TotJe(); // метод ОДНОИМЕННЫЙ ( в интерфейсе такой же)

    }
}
