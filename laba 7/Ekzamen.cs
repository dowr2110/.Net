using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace laba_7
{
    class Ekzamen : Ispitanie, IDatak, ITakoije
    {
        protected string name; // имя экзамена
        public int koll = 0;
        public int kolvopr = Vopros.kolvo;
        Predm glav;
        public Ekzamen(string ima)// конструктор
        {
            name = ima;
            Debug.Assert(ima.CompareTo("PE") != 0, "ошибочка тут у нас нашли не тот предмет");//esli u  nas imya ravra "PE"-to vyvodim soobshen
            koll++;
        }
        public string Name // св-ва
        {
            get
            { return name; }
            set
            {
                if (name != "English" || name != "Math" || name != "Russian" || name != "History")
                {
                    throw new PredmException("Ошибка! Неверно указан предмет!");
                }
                else
                {
                    name = value;
                    koll++;
                }
            }
        }
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Name;
        }
        public override void ToConsole()
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(name);
        }
        public int Kol //св-ва
        {
            get
            {
                return kol;
            }
            set
            {
                kol = value;
                koll++;
            }
        }
    }
}
