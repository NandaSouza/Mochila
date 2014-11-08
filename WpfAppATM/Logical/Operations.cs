using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppATM
{
   public static class Operations
    {
        public static int[] Withdraw(int[] quantity, int[] value, int numberOfValues, int change)
        {
            int j = numberOfValues - 1;
            int[] x = new int[numberOfValues];


            while (change > 0)
            {
                for (int i = j; i >= 0; i--)
                {
                    if (value[i] <= change)
                    {
                        x[i] = x[i] + 1;
                        change = change - value[i];
                    }
                    else if (change < value[0] && change != 0)
                    {
                        
                        throw new Exception("Não é possivel retirar o valor solicitado");

                    }
                }
            }
            return x;
        }    
    }
}
