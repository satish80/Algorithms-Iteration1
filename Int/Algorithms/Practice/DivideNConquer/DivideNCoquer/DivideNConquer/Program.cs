using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideNCoquer
{
    class Program
    {
        static void Main(string[] args)
        {
            Largest findLargest = new Largest();
            findLargest.FindLargestNo();
        }
    }

    #region Largest among array with increasing first and decreasing later
    public class Largest
    {
        public void FindLargestNo()
        {
            int[] inputArray = { 8, 10, 20, 80, 100, 200, 400, 500, 3, 2, 1 };

            Console.WriteLine("Largest no is {0} ", RecurseMedian(0,inputArray.Length-1,inputArray));
            Console.Read();
        }

        private int RecurseMedian(int start, int end, int[] arr)
        {
            int res = 0;
            int index = 0;

            if (end - start == 1)
                 return arr[end] > arr[start] ? arr[end] : arr[start];

            else
            {
                index = (start + end) / 2;

                if (arr[index] > arr[index - 1])
                {
                    start = index;
                    return RecurseMedian(start, end, arr);
                }
                else
                {
                    end = index;
                    return RecurseMedian(start, end, arr);
                }
            }
            return res;
        }
    }
    #endregion
}
