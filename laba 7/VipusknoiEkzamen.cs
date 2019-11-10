using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    sealed class VipusknoiEkzamen : Ispitanie
    {
        protected string typeofekz; // тип куста
        int d = 32;
        public VipusknoiEkzamen() // конструктор
        {
            typeofekz = "Vipusknoi";
        }
        public string TypeofEKZ // св-ва
        {
            get
            { return typeofekz; }
            set
            { typeofekz = value; }
        }
        public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }
        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        //переопределим ToString (cтроковое представление объекта)
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + TypeofEKZ;
        }
        //переопределим Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            VipusknoiEkzamen odin = (VipusknoiEkzamen)obj;
            return (this.typeofekz == odin.typeofekz);
        }
        public override int GetHashCode()
        {
            int hash = 47;
            string wie = Convert.ToString(typeofekz);
            hash = string.IsNullOrEmpty(wie) ? 0 : typeofekz.GetHashCode();
            hash = (hash * 47) + d.GetHashCode();
            return hash;
        }
    }
}
