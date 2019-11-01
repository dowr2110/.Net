using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    public class Set//otkrytyy klass//Создать заданный в варианте класс.
    {//mnojestva 
        //polya klassa
        public int Size;
        public Owner owner;//pole klass s tipom Owner (otdelnyy class)
        public int[] set;
        public int count = 0;
        public DateTime date;//datetime???//Добавьте в свой класс вложенный класс Date (дата создания).
        

        public Set()//конструкторы,
        {
            Size = 100;
            set = new int[Size];
            owner = new Owner();
            date = DateTime.Now;
        }
        public Set(int _size)//конструкторы, с 1 param
        {
            Size = _size;
            set = new int[_size];
            owner = new Owner();
            date = DateTime.Now;//Проинициализируйте
        }
        public Set(int _size, int _id, string _Name, string _Organization)//конструкторы, с 4 param
        {
            Size = _size;
            set = new int[_size];
            owner = new Owner(_id, _Name, _Organization);
            date = DateTime.Now;//Проинициализируйте
        }

  
        public static Set operator >>(Set _set, int num)//////////////////////cto takoe peregruzka i pocemu oni static//заданные перегруженные операции
                                                        //->> удалить элемент из множества
        {
            for (int i = 0; i < _set.count; i++)
            {
                if (_set.set[i] == num)
                {
                    for (int j = i; j < _set.count - 1; j++)
                    {
                        _set.set[j] = _set.set[j + 1];
                    }
                    _set.count--;
                    return _set;
                }
            }
            return _set;
        }

        public static Set operator <<(Set _set, int num)/////////////////заданные перегруженные операции//<< добавить элемент в множество (типа set+item);
        {
            _set.add(num);//dob elem ne povt mnojestva
            return _set;
        }

        public static Set operator %(Set set1, Set set2)//////////////////заданные перегруженные операции//%пересечение множеств.
        {
            int newSize = 100;
            if (set1.Size >= set2.Size)
                newSize = set1.Size;
            else
                newSize = set2.Size;
            Set newSet = new Set(newSize);
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set2.set[j] == set1.set[i])
                    {
                        newSet.add(set2.set[j]);
                        break;
                    }
                }
            }
            return newSet;
        }

        public static bool operator <(Set set1, Set set2)///////////////////заданные перегруженные операции
        {
            int c = 0;
            for (int i = 0; i < set2.count; i++)
            {
                for (int j = 0; j < set1.count; j++)
                {
                    if (set1.set[j] == set2.set[i])
                    {
                        c++;
                        break;
                        //idti po bolsh
                    }
                }
            }
            return (c == set2.count);
        }

        public static bool operator >(Set set1, Set set2)/////////////////заданные перегруженные операции//// > проверка на подмножество
        {
            int c = 0;
            for (int i = 0; i < set2.count; i++)
            {
                for (int j = 0; j < set1.count; j++)
                {
                    if (set1.set[j] == set2.set[i])
                    {
                        c++;
                        break;
                    }
                }
            }
            return (c != set2.count);
        }

        public static bool operator ==(Set set1, Set set2)/////////////////заданные перегруженные операции
        {
            int c = 0;
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set1.set[i] == set2.set[j])
                    {
                        c++;
                        break;
                    }
                }
            }
            return ((c == set1.count) && (c == set2.count));
        }

        public static bool operator !=(Set set1, Set set2)////////////!=  проверка множеств на неравенство//Форма перегрузки бинарной операции
        {
            int c = 0;
            for (int i = 0; i < set1.count; i++)
            {
                for (int j = 0; j < set2.count; j++)
                {
                    if (set1.set[i] == set2.set[j])
                    {
                        c++;
                        break;
                    }
                }
            }
            return ((c != set1.count) && (c != set2.count));
        }
        public bool isFull()//metod bolevym vozvrash//Определить в классе необходимые методы
        {
            return (count == Size);
        }

        public void add(int elem)//metods 1 param//Определить в классе необходимые методы
        {
            if (isFull() == true)//??
            {
                Console.WriteLine("Full");
            }
            for (int i = 0; i < count; i++)
            {
                if (set[i] == elem)
                {
                    return;
                }
            }
            set[count++] = elem;//??
        }

        public void show()//metod//Определить в классе необходимые методы
        {
            Console.WriteLine("Elements:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(set[i]);
            }
        }
    }
}
