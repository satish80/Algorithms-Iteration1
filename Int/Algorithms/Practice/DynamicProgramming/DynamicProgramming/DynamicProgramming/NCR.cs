using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class NCR
    {
        public void CalcNCR()
        {
            Console.WriteLine(CalculateNCR(4,2));
            Console.Read();
        }

        private int CalculateNCR(int n, int r)
        {
            if (r == 0)
                return 1;

            if (n == r)
                return 1;

            int result1 = CalculateNCR(n - 1, r);

            int result2 = CalculateNCR(n-1,r-1);

            int result = result1 + result2;
            return result;
        }
    }
}
