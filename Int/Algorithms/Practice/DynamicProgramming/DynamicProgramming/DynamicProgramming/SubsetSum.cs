using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class SubsetSum
    {
        static int count = 0;
        private bool isSubsetSum(int[] set, int n, int sum)
        {
            #region DP Method
            //// The value of subset[i][j] will be true if there is a subset of set[0..j-1]
            ////  with sum equal to i
            //bool[,] subset = new bool[sum + 1, n + 1];

            //// If sum is 0, then answer is true
            //for (int i = 0; i <= n; i++)
            //    subset[0, i] = true;

            //// If sum is not 0 and set is empty, then answer is false
            //for (int i = 1; i <= sum; i++)
            //    subset[i, 0] = false;

            //// Fill the subset table in botton up manner
            //for (int i = 1; i <= sum; i++)
            //{
            //    for (int j = 1; j <= n; j++)
            //    {
            //        subset[i, j] = subset[i, j - 1];
            //        if (i >= set[j - 1])
            //            subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
            //    }
            //}

            ///* // uncomment this code to print table
            // for (int i = 0; i <= sum; i++)
            // {
            //   for (int j = 0; j <= n; j++)
            //      printf ("%4d", subset[i][j]);
            //   printf("\n");
            // } */

            //return subset[sum, n];
            #endregion

            if (sum == 0)
            {
                count++;
                return true;
            }

            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum, then ignore it
            //if (set[n - 1] > sum)
            //    return isSubsetSum(set, n - 1, sum);

            /* else, check if sum can be obtained by any of the following
               (a) including the last element
               (b) excluding the last element   */
            return isSubsetSum(set, n - 1, sum) || isSubsetSum(set, n - 1, sum - set[n - 1]);
        }

        public void InvokeSubSet()
        {
            int[] set = { 3, 34, 7, 5, 32 };
            int sum = 12;
            int n = 5;
            if (isSubsetSum(set, n, sum) == true)
                Console.WriteLine("Found a subset with given sum");
            else
                Console.WriteLine("No subset with given sum");
        }
    }
}
