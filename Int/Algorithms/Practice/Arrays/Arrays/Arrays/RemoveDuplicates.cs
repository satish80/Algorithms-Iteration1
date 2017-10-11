using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class RemoveDuplicates
    {
        //public int[] Remove(int[] arr)
        //{
        //    for (int idx = 0; idx < arr.Length - 1; idx++)
        //    {
        //        for (int cidx = idx + 1; cidx < arr.Length - 1; cidx++)
        //        {
        //            //if(arr[idx] == arr[cidx])

        //        }
        //    }
        //}

        public void RemoveDuplicatesInPlace(int[] input)
        {
            var sortedInput = input.OrderBy(x => x).ToArray<int>(); //O(n log n)
            int start = 1;
            int end = 1;

            //O(n)
            while (start < sortedInput.Length)
            {
                if (sortedInput[start] != sortedInput[start - 1])
                {
                    sortedInput[end] = sortedInput[start];
                    end++;
                }
                start++;
            }

            for (int i = end; i < sortedInput.Length; i++)
                sortedInput[i] = -1;

        }
    }
}
