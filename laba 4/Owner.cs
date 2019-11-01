using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    public class Owner//Добавьте в свой класс вложенный объект Owner
    {
        public int id { get; set; }//который содержит Id,
        public string Name { get; set; }//имя
        public string Organization { get; set; }//организацию создателя.
        //Проинициализируйте его
        public Owner()//konstruktor
        {
            id = 0;
        }

        public Owner(int _id, string _Name, string _Organization)//konstruktor s 3 parametrami
        {
            id = _id;
            Name = _Name;
            Organization = _Organization;
        }
    }
}
