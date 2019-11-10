using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    class Test : Ispitanie, IDatak, ITakoije
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
        public override string ToString()
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
