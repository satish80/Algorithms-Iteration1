using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    public class LCSDP
    {
        public void FindLCSViaDP()
        {
            char[] arr1 = { 'g', 'a', 'c', 'b', 'd' };
            char[] arr2 = { 'e','b','a','r'};

            Console.WriteLine(LCS(arr1,arr2,arr1.Length-1, arr2.Length-1));
            Console.Read();
        }

        private int LCS(char[] arr1, char[] arr2,int idx1, int idx2)
        {
            if (idx1 < 0)
                return 0;

            if (idx2 < 0)
                return 0;

            if (arr1[idx1] == arr2[idx2])
                return LCS(arr1, arr2, idx1 - 1, idx2 - 1) + 1;

            else
                return max(LCS(arr1,arr2,idx1-1,idx2), LCS(arr1,arr2,idx1,idx2-1));
        }

        private int max(int first, int second)
        {
            if (first > second)
                return first;
            else
                return second;
        }
    }
}
