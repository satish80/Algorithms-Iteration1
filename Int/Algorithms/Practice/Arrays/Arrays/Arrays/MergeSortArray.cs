using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MergeSortArray
    {
        public void Sort()
        {
            int[] arr = new int[] { 5,4,1,7,2};
            int[] sortedArr =MergeSort(arr,0,4);

            for (int idx = 0; idx < sortedArr.Length;idx++ )
                Console.WriteLine(sortedArr[idx].ToString());
            Console.Read();
        }

        private int[] MergeSort(int[] arr, int start, int end)
        {
            if (start == end)
            {
                int[] sortedArr = new int[1];

                #region Commented
                //if (arr[start] > arr[end])
                //{
                //    sortedArr[0] = arr[end];
                //    sortedArr[1] = arr[start];
                //}
                //else
                //{
                //    sortedArr[0] = arr[start];
                //    sortedArr[1] = arr[end];
                //}
                #endregion

                sortedArr[0] = arr[start];
                return sortedArr;
            }
            else
            {
                int mid = (start + end) / 2;
                int[] first = MergeSort(arr, start, mid);
                int[] second = MergeSort(arr, mid + 1, end);
                return Merge(first, second);
            }
        }

        private int[] Merge(int[] first, int[] second)
        {
            int fIdx=0, sIdx=0;
            fIdx = first.Length;
            sIdx = second.Length;
            int[] mergedArr = new int[first.Length + second.Length];

            int idx = 0;
            int sCount = 0,fCount=0;

            while (true)
            {
                if (first[fCount] > second[sCount])
                {
                    mergedArr[idx++] = second[sCount++];
                }
                else
                    mergedArr[idx++] = first[fCount++];


                if(sCount >= sIdx && fCount <= fIdx)
                {
                    if(fIdx==1)
                        mergedArr[idx++] = first[0];
                    else
                    {
                        while (fCount < fIdx)
                            mergedArr[idx++] = first[fCount++];
                    }
                    break;
                }

                else if (fCount >= fIdx && sCount <= sIdx)
                {
                    if (sIdx==1)
                        mergedArr[idx++] = second[0];
                    else
                    {
                        while (sCount < sIdx)
                            mergedArr[idx++] = second[sCount++];
                    }
                    break;
                }
            }
            return mergedArr;
        }
    }
}
