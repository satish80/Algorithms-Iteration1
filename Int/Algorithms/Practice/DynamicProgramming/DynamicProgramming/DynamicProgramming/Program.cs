using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Knapsack();
            //Console.WriteLine("The eggs can be dropped safely from {0}", EggDrop.Drop(20,5));

            #region CoinChange
            CoinChange coinObj = new CoinChange();
            coinObj.CountDenomination();
            #endregion

            //MinJumpsToReachEndOfArray obj = new MinJumpsToReachEndOfArray();
            //int[] arr = { 1, 2, 1, 3, 1, 3, 1, 0, 1, 0 };

            //Console.WriteLine("Max no of hops is {0} ",obj.minJumps(arr,6));

            #region Subset Sum
            //SubsetSum obj = new SubsetSum();
            //obj.InvokeSubSet();
            #endregion

            #region NCR
            //NCR obj = new NCR();
            //obj.CalcNCR();
            #endregion
            Console.Read();
        }

        static void Knapsack()
        {
            int[] val = { 60, 100, 120, 300, 400 };
            int[] wt = { 10, 20, 30, 30, 20 };
            int W = 50;
            int n = 3;
            Console.WriteLine("{0}", knapSack(W, wt, val, n));
        }

        static int knapSack(int Weight, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, Weight + 1];

            // Build table K[][] in bottom up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= Weight; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = (val[i - 1] + K[i - 1, w - wt[i - 1]] > K[i - 1, w] ? val[i - 1] + K[i - 1, w - wt[i - 1]] : K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, Weight];
        }

    }
}
