using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNos
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 315;
            primeFactors(n);

            //Console.WriteLine(PrimeNo(8));
            Console.Read();

        }

        static void primeFactors(int n)
        {
            // Print the number of 2s that divide n
            while (n % 2 == 0)
            {
                Console.WriteLine("{0} ", 2);
                n = n / 2;
            }

            // n must be odd at this point.  So we can skip one element (Note i = i +2)
            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                // While i divides n, print i and divide n
                while (n % i == 0)
                {
                    Console.WriteLine("{0} ", i);
                    n = n / i;
                }
            }

            // This condition is to handle the case whien n is a prime number
            // greater than 2
            if (n > 2)
                Console.WriteLine("{0} ", n);
        }

        static bool PrimeNo(int num)
        {
            double sqRt = Math.Sqrt(num);

            for (int idx = 2; idx <= sqRt; idx++)
            {
                if (num % idx == 0)
                    return false;
            }
            return true;
        }
    }
}
