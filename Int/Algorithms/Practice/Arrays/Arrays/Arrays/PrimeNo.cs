using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class PrimeNo
    {
        void markMultiples(bool[] arr, int a, int n)
        {
            int i = 2, num;
            while ((num = i * a) <= n)
            {
                arr[num - 1] = true; // minus 1 because index starts from 0.
                ++i;
            }
        }

        // A function to print all prime numbers smaller than n
        public void NoOfPrimes(int n)
        {
            // There are no prime numbers smaller than 2
            if (n >= 2)
            {
                // Create an array of size n and initialize all elements as 0
                bool[] arr = new bool[n];


                /* Following property is maintained in the below for loop
                   arr[i] == 0 means i + 1 is prime
                   arr[i] == 1 means i + 1 is not prime */
                for (int i = 1; i < n; ++i)
                {
                    if (arr[i] == true)
                    {
                        //(i+1) is prime, print it and mark its multiples
                        Console.WriteLine("%d ", i + 1);
                        markMultiples(arr, i + 1, n);
                    }
                }
            }
        }
    }
}
