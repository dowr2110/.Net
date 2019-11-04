using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    sealed class VipusknoiEkzamen : Ispitanie
    {
        protected string typeofekz; // тип куста
   

        public VipusknoiEkzamen() // конструктор po umol
        {
            typeofekz = "Vipusknoi";
        }
        public string TypeofEKZ
        {
            get
            { return typeofekz; }
            set
            { typeofekz = value; }
        }//svoysta  



public override void ToConsole() // производный класс обязан переопределить и реализовать все абстрактные методы
        {
            Console.WriteLine(this.ToString());
        }

        public override void TotJe()
        {
            Console.WriteLine("Я одноименный метод(абстрактный)!");
        }
        //метод ToString(), который выводит информацию о типе объекта и его текущих значениях.
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
        //переопределим GetHashCode
        public override int GetHashCode()
        {
            return this.typeofekz.GetHashCode();
        }
    }
}
