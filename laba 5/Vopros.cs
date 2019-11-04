using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Vopros : Test, Datak
    {
        protected string predmet; // Имя предмета
        public Vopros(string type, string dif, int max) : base(type, dif, max)  // конструктор
        {
            predmet = type;
            difficult = dif;
            maxball = max;
        }
        public string Predme
        {
            get
            { return predmet; }
            set
            { predmet = value; }
        }//svoysta 
        
        //метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Predme;
        }

        public override void ToConsole()// производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(predmet);
        }
    }
}
