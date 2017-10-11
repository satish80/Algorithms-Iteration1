using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Exponentiation
    {
        public void CalcExponents()
        {
            Console.WriteLine("Enter number ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the power ");
            int pow = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Exponent(num,pow));
            Console.Read();
        }

        private int Exponent(int num, int pow)
        {
            if (pow == 0)
                return 1;
            else
                return num * Exponent(num, pow - 1);
        }
    }
}
