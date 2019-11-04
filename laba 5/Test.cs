using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Test : Ispitanie, ITakoije
    {
        protected string typeoftest; // поле тип теста
        protected string difficult;
        protected int maxball;
        public Test(string type, string dif, int max)//konstruktor s 3 param
        {
            typeoftest = type;
            difficult = dif;
            maxball = max;
        }


        public string Tst
        {  get
            { return typeoftest; }
            set
            { typeoftest = value; }}//svoysta 
        public string Diffic
        {
            get
            { return difficult; }
            set
            { difficult = value; }
        }//svoysta
        public int Maxb
        {
            get
            { return maxball; }
            set
            { maxball = value; }
        }//svoysta


        //метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        public override string ToString()// переопределяем метод 
        {
            return "Type " + base.ToString() + " " + Tst;
        }


        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }

        public override void TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }

        void ITakoije.TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я тоже одноименный метод(я из интерфейса)!");
        }

        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(typeoftest);
        }
    }
}
