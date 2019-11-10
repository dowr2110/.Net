using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    class Zachet
    {
        protected string predm;
        public Zachet()
        {
            predm = "Предмет зачёта";
        }
        public string Predm
        {
            get { return predm; }
            set { predm = value; }
        }
    }
}
