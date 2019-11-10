using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6_var_7
{
    partial class Vopros : Test, IDatak
    {
        protected string predmet; // Имя предмета
        public static int kolvo;
        public Vopros(string type, string dif, int max) : base(type, dif, max)  // конструктор
        {
            predmet = type;
            difficult = dif;
            maxball = max;
            kolvo++;
        }
        public string Predme // св-ва
        {
            get
            { return predmet; }
            set
            {
                predmet = value;
                kolvo++;
            }
        }
        public void Info() // реализуем метод интерфейса
        {
            Console.WriteLine(predmet);
        }
    }

}
