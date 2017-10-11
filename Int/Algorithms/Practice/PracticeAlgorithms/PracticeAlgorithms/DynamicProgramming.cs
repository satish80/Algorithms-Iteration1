using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class DynamicProgramming
    {
        public bool IsSubSetSum(int[] arr, int desiredSum)
        {
            bool[,] dpArr = new bool[desiredSum + 1, arr.Length +1 ];

            for(int i=0; i<= arr.Length -1 ; i++)
            {
                dpArr[0, i] = true;
            }

            for (int i = 1; i <= desiredSum; i++)
                dpArr[i, 0] = false;

            for (int i = 1; i <= desiredSum; i++)
            {
                for (int j = 1; j <= arr.Length; j++)
                {
                   dpArr[i,j] = dpArr[i, j - 1];
                    if (i >= arr[j - 1])
                        dpArr[i, j] = dpArr[i, j] ||
                                              dpArr[i - arr[j - 1], j - 1];
                }
            }

            return dpArr[desiredSum, arr.Length];
        }

        public void KnapSack(int[] Val, int[] W, int desiredWeight)
        {
            Console.WriteLine(SolveKnapSackInDP(Val, W, desiredWeight));
        }

        private int SolveKnapSackInDP(int[] Val, int[] W, int desiredWeight)
        {
            int[,] knapsack = new int[Val.Length, desiredWeight + 1];

            for(int i = 0; i <= Val.Length; i++)
            {
                for(int j=0; j<= desiredWeight; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        knapsack[i, j] = 0;
                    }
                    else if(W[i-1] <= desiredWeight)
                    {
                        knapsack[i, j] = Math.Max(Val[i-1] + knapsack[i-1, j- W[i-1]], knapsack[i-1,j]);
                    }
                    else
                    {
                        knapsack[i, j] = knapsack[i - 1, j];
                    }
                }
            }
            return knapsack[Val.Length, desiredWeight];
        }
    }
}
