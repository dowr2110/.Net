using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ekzamen : Ispitanie, Datak
    {
        protected string name; // имя экзамена

        public Ekzamen(string ima)// конструктор s 1 param
        {
            name = ima;
        }
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }//svoysta 
        
        //метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
        public override string ToString()// переопределяем метод 
        {
            return "Type " + base.ToString() + " " + Name;
        }

        public override void ToConsole()// производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }

        public override void TotJe() // работа с ОДНОИМЕННЫМ методом
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }

        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(name);
        }
    }
}
