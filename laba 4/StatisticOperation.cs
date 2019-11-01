using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba_4
{
    public static class StaticOperation//pochemu tut statis?//Создайте статический класс StatisticOperation, содержащий 3 метода для работы с вашим классом
    {
        //metody rasshirenia
        public static int fingAvg(this Set set)//metod сумма,
        {
            int sum = 0;
            for (int i = 0; i < set.count; i++)
            {
                sum += set.set[i];
            }
            return sum;
        }

        public static int count(this Set set)//подсчет количества элементов
        {
            return set.count;
        }

        public static int MinMax(this Set set)//разница между максимальным и минимальным,
        {
            int min = set.set[0];
            int max = set.set[0];

            for (int i = 0; i < set.count; i++)
            {
                if (set.set[i] <= min)
                    min = set.set[i];
            }

            for (int i = 0; i < set.count; i++)
            {
                if (set.set[i] >= max)
                    max = set.set[i];
            }

            return max - min;
        }
        public static int Min(this Set set)//metod po variku
        {
            int min = set.set[0];
            for (int i = 0; i < set.count; i++)
            {
                if (set.set[i] <= min)
                {
                    min = set.set[i];
                }
            }
            return min;
        }
    }
}
