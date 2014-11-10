using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppATM
{
    public class Cedula : IComparable<Cedula>
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

        public int CompareTo(Cedula other)
        {
            if (this.Amount > other.Amount)
            {
                return -1;
            }
            else
            {
                if (this.Amount == other.Amount && this.Value > other.Value)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
