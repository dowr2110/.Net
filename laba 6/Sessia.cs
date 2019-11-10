using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_6_var_7
{
    class Sessia : Zachet
    {
        private List<Ekzamen> ekz;//privatnyy massiv tipa klassa ekzamen
        private List<Ispitanie> isp;
        public Sessia(params Ekzamen[] values)
        {
            ekz = new List<Ekzamen>(values);
        }
        public void AddEkz(Ekzamen a)
        {
            ekz.Add(a);
        }
        public List<Ekzamen> FindEkz(string predm)
        {
            List<Ekzamen> lst = new List<Ekzamen>();
            foreach (Ekzamen ek in ekz)
            {
                if (ek.Name == predm)
                {
                    lst.Add(ek);
                }
            }
            return lst;
        }
        public void ToConsoleList(List<Ekzamen> ekz)
        {
            for (int i = 0; i < ekz.Count; i++)
            {
                Console.WriteLine("Ekzamen[{0}] = {1}", i, ekz[i].Name);
            }

        }
        public int FindKol()
        {
            int summ = 0;
            foreach (Ekzamen eek in ekz)
            {
                summ += eek.koll;
            }
            return summ;
        }
        public int FindTes(int chislovoprov)
        {
            int sum = 0;
            foreach (Ekzamen ek in ekz)
            {
                if (chislovoprov == ek.kolvopr)
                    sum++;
            }
            return sum;
        }

       
    }    /////////////////////////////////////////////////////////////////
}
