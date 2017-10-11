using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CreCoin
    {
        public void Count(int[] S, int m, int n)
        {
            int Count = 0;
            for (int idx = 0; idx < m; idx++)
            {
                if (S[idx] % n == 0)
                    Count++;
                else
                {
                    for (int subIdx = 0; subIdx < m; subIdx++)
                    {
                        if (S[idx] + S[subIdx] < n)
                        {

                        }
                    }
                }
            }
        }
    }
}
