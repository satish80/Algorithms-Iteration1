using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class SortedRotatedArray
    {
        public void Search()
        {
            int[] arr = new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            Console.WriteLine(RecurseSearch(arr, 9, 0, 8));
        }

        private int RecurseSearch(int[] arr, int num, int start, int end)
        {
            int res = -1;
            int mid = (start + end) /2;
            bool leftSorted = false;
            bool rightSorted = false;
            bool isHandled = false;

            if (Math.Abs(end - start) == 1 && res == -1)
            {
                if(arr[end] == num)
                    res = end ;
                else if(arr[start]==num)
                    res = start;

                return res;
            }

            if (arr[mid] <= arr[end] && arr[mid] <= arr[mid + 1])
            {
                rightSorted = true;
                if (num >= arr[start] && num <= arr[mid])
                {
                    isHandled = true;
                    end = mid;
                    res = RecurseSearch(arr, num, start, end);
                }
                else if (num >= arr[mid] && num <= arr[end])
                {
                    isHandled = true;
                    start = mid;
                    res = RecurseSearch(arr, num, start, end);
                }
            } 
            else if(arr[mid] >= arr[start] && arr[mid] > arr[mid-1])
            {
                leftSorted = true;
                if (num >= arr[start] && num <= arr[mid])
                {
                    isHandled = true;
                    end = mid;
                    res = RecurseSearch(arr, num, start, end);
                }
                else if (num >= arr[mid] && num <= arr[end])
                {
                    isHandled = true;
                    start = mid;
                    res = RecurseSearch(arr, num, start, end);
                }                            
            }

            if (!isHandled )
            {
                if(leftSorted)
                {
                    int prevMid = mid;
                    mid = (mid + end) / 2;
                    if (arr[mid] <= arr[end] && arr[mid] <= arr[mid + 1] && num >= arr[mid] && num <= arr[end])
                    {
                        start = mid;
                        res = RecurseSearch(arr, num, start, end);
                    }
                    else
                    {
                        start = prevMid;
                        end = mid;
                        res = RecurseSearch(arr, num, start, end);
                    }
                }
                else if(rightSorted)
                {
                    int prevMid = mid;
                    mid = (mid + start) / 2;

                    if (arr[mid] >= arr[start] && arr[mid] >= arr[mid - 1] && num >= arr[mid] && num <= arr[prevMid])
                    {
                        end = mid;
                        res = RecurseSearch(arr, num, start, end);
                    }
                    else
                    {
                        start = mid;
                        end = prevMid;
                        res = RecurseSearch(arr, num, start, end);
                    }
                }
            }
            return res;
        }
    }
}
