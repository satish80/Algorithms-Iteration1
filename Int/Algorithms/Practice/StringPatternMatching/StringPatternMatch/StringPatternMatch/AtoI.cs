using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPatternMatch
{
    public class AtoI
    {
        public void DisplayAtoI()
        {
            int result = ConvertAtoI("45644");
            Console.WriteLine(result.ToString());
        }

        private int ConvertAtoI(string str)
        {
            int result =0;

            char[] charArr = str.ToCharArray();

            for (int i = 0; i< charArr.Length ; ++i)
                result = result * 10 + charArr[i] - '0';

            return result;
        }
    }
}
