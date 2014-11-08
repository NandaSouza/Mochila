using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppATM
{
    class Cedula
    {
        public int Value { get; set; }
        public int Amount { get; set; }

        public Cedula()
        {

        }

        public Cedula(int value, int amount)
        {
            this.Value = value;
            this.Amount = amount;
        }


    }
}
