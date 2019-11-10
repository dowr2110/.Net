using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    public abstract class Ispitanie
    {
        protected string type;
        protected string test;
        protected string ekzamen;
        public int kol;
        public Ispitanie()
        {
            test += "Обычный тест";
            ekzamen += "Лучше не шутить";
            kol++;
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public override string ToString() // переопределяем метод 
        {
            return "" + base.ToString() + " " + Type;
        }
        public abstract void ToConsole(); // метод абстрактного класса
        public abstract void TotJe(); // метод ОДНОИМЕННЫЙ ( в интерфейсе такой же)
    }
}
