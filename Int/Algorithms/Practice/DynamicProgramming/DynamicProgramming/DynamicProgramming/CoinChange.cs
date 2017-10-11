using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class CoinChange
    {
        private int count(int[] S, int n, int sum)
        {
            Console.WriteLine("n is {0} sum is {1}", n, sum);

            // If n is 0 then there is 1 solution (do not include any coin)
            if (sum == 0)
                return 1;

            // If n is less than 0 then no solution exists
            if (sum < 0)
                return 0;

            // If there are no coins and n is greater than 0, then no solution exist
            if (n <= 0 && sum >= 1)
                return 0;
            // count is sum of solutions (i) including S[m-1] (ii) excluding S[m-1]
            return count(S, n - 1, sum) + count(S, n, sum - S[n - 1]);

        }

        public void CountDenomination()
        {
            int[] S = { 2, 3 ,5,7};
            int n = 4;
            int sum = 12;
            Console.WriteLine(count(S, n, sum));
        }
    }
}
