using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class EggDrop
    {
        public static int Drop(int k, int n)
        {
            if (n == 1)
                return k;

            if (k == 1 || k == 0)
                return k;
            int res = 0;
            int min = 20;

            for (int idx = 0; idx <= k; idx++)
            {
                res = Drop(k - idx, n - 1) > Drop(idx, n) ? Drop(k - idx, n - 1) : Drop(k-idx, n);
                if (res <= min)
                    min = res;
            }

            return res;
        }
    }
}
