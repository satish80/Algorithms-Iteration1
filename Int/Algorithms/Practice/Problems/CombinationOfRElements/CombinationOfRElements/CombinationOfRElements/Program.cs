using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationOfRElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=5, r=3;

            int[] arr = new int[] {1,2,3,4,5};
            for (int idx = 0; idx <= n - r; idx++)
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("{0}", arr[idx]);

                for (int Cidx = 1; Cidx <= r; Cidx++)
                {
                    PrintCombinations(arr, idx + 1, n - 1, r);
                }
                
            }
            Console.Read();
        }

        private static void PrintCombinations(int[] arr,int start, int end, int r)
        {
            if (r < 1 || start == end)
            {
                //Console.WriteLine("______________________________");
                //Console.WriteLine("\n");
                return;
            }

            Console.WriteLine("{0}", arr[start]);
            PrintCombinations(arr, start + 1, end, r-1);               
        }
    }
}
