using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MinOfSortedRotatedArray
    {
        public void FindMin()
        {
            int[] arr = { 4, 5, 6, 7,8 ,9,10, 11, 1, 2, 3 };
            Console.WriteLine(RecurseArray(arr,0,10));
        }

        private int RecurseArray(int[] arr, int start, int end)
        {
            
            int median;
            if (start == 0)
                median = (start + end) / 2;
            else
                median = start + ((end - start) / 2);

            int res =0;

            if (Math.Abs(start - end) == 1)
            {
                res = arr[start] < arr[end] ? arr[start] : arr[end];
                return res;
            }

            if (arr[median] < arr[median+1] && arr[median] < arr[median -1])
                res = RecurseArray(arr, start, median);

            else if (arr[median] > arr[median+1] && arr[median] > arr[median-1])
                res = RecurseArray(arr, median, end);

            else if(arr[median] < arr[median+1] && arr[median] > arr[median-1])
            {
                res = RecurseArray(arr, median +1, end);
            }
            else
            {
                res = RecurseArray(arr, start, median);
            }

            return res;
        }
    }
}
