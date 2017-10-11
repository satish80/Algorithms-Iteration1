﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class HeapSort
    {
        public void ConstructHeap()
        {
            int[] arr = {5,3,17,10,84,19,6,22,9};
            BuildMinHeap(arr);
        }

        private void BuildMinHeap(int[] arr)
        {
            int[] res=Heapify(arr, 1);

            for (int idx = 0; idx < res.Length; idx++)
            {
                Console.WriteLine(res[idx].ToString());
            }
            Console.Read();
        }

        private int[] Heapify(int[] arr, int count)
        {
            if(count<=arr.Length)
                Heapify(arr, ++count);  

            if (2 * count < arr.Length )
            {
                int temp;
               // int min = arr[2 * count] > arr[2 * count + 1] ? arr[2 * count + 1] : arr[2 * count];
                //if (arr[count] > min)
                {
                    temp = arr[count-1];
                    if (2 * count < arr.Length)
                    {
                        if (arr[count-1] > arr[2 * count])
                        {
                            arr[count-1] = arr[2 * count];
                            arr[2 * count] = temp;
                        }
                    }
                    if (arr[count-1] > arr[2 * count-1])
                    {
                        arr[count-1] = arr[2 * count-1];
                        arr[2 * count -1] = temp;
                    }
                }
            }
            return arr;
        }
    }
}