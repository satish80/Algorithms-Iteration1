using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    class SubsetSum
    {
        public void subsetSums(int[] arr, int l, int r,
                int sum = 0)
        {
            // Print current subset
            if (l > r)
            {
                Console.WriteLine(sum);
                return;
            }

            // Subset including arr[l]
            subsetSums(arr, l + 1, r, sum + arr[l]);

            // Subset excluding arr[l]
            subsetSums(arr, l + 1, r, sum);
        }


        public bool CheckSubSetSumExists(int[] arr, int l, int r, int desiredSum)
        {
            return IsSubsetSum(arr, l, r, desiredSum, 0);
        }

        private bool IsSubsetSum(int[] arr, int l, int r, int desiredSum, int sum)
        {
            if (sum == desiredSum)
            {
                return true;
            }
            else if(l > r)
            {
                return false;
            }
            else
            {
                return IsSubsetSum(arr, l + 1, r, desiredSum, sum + arr[l]) || IsSubsetSum(arr, l + 1, r, desiredSum, sum);
            }
        }
    }
}
