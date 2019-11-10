using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    class Sessia : Zachet
    {
        private List<Ispitanie> ekz;
        public Sessia(params Ispitanie[] values)
        {
            ekz = new List<Ispitanie>(values);
            Test kak = new Test("obicni", "Easy", 2);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].GetType() == kak.GetType())
                {
                    throw new EkzamenException("Обнаружена ошибка!Обычный Тест на экзамене?Не смешно..");
                }
                else
                {
                    ekz.Add(values[i]);
                }
            }
        }
        public void AddEkz(Ispitanie a)
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
    }

}
