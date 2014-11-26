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
                        i++;
                    }
                    else if (change < value[0] && change != 0)
                    {

                        throw new Exception("Não é possivel retirar o valor solicitado");

                    }
                }
            }
            return x;
        }

        public static Dictionary<int, Cedula> Withdraw(List<Cedula> storedMoney, int requiredAmount)
        {
            var resultDictionary = new Dictionary<int, Cedula>();
            var sortedAmount = storedMoney;
            int currentAmount = 0;


            while (currentAmount < requiredAmount)
            {
                bool billNotFound = true;
                sortedAmount.Sort();
               
                foreach (var bill in sortedAmount)
                {
                    //verifica se o valor somado autal + o valor da cédula é maior que o total requerido
                    if (bill.Value + currentAmount <= requiredAmount && bill.Amount > 0)
                    {
                        billNotFound = false;

                        bill.Amount--;
                        currentAmount += bill.Value;

                        //adiciona cédula no dicionário de retorno
                        if (!resultDictionary.ContainsKey(bill.Value))
                        {
                            //se o dicionário ainda não possui a cédula, cria uma cédula e adiciona no 
                            resultDictionary.Add(bill.Value, new Cedula()
                            {
                                Value = bill.Value,
                                Amount = 1,
                            });
                        }
                        else
                        {
                            //se o dicionário já possui a cédula, apenas aumenta a quantidade
                            resultDictionary[bill.Value].Amount++;
                        }

                        break;
                    }
                }

                if (billNotFound)
                {
                    var ex = new Exception("Não é possível sacar esse valor");
                    ex.Data.Add("result", resultDictionary);
                    throw ex;
                }
            }


            return resultDictionary;
        }

    }
}
