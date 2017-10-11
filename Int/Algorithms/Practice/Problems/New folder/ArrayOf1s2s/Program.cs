using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOf1s2s
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,3,3,2,1};
            DisplayArray(arr);
            Console.Read();
        }

        private static void DisplayArray(int[] arr)
        {
            int twoCount = 0, threeCount=0;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                if (arr[idx] == 1)
                    Console.WriteLine("1");
                else if (arr[idx] == 2)
                    twoCount++;
                else if (arr[idx] == 3)
                    threeCount++;
            }

            for (int idx = 0; idx < twoCount; idx++)
            {
                Console.WriteLine("2");
            }

            for (int idx = 0; idx < threeCount; idx++)
            {
                Console.WriteLine("3");
            }
        }
    }
}
