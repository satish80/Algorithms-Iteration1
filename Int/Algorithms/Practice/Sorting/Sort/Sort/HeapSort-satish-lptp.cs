using System;
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
           // int[] arr = { 5,3,17,10,84,19,6,22,9};
            int[] arr = {16,14,10,8,7,9,3,2,4,1};
            BuildMinHeap(arr);
        }

        private void BuildMinHeap(int[] arr)
        {
            int[] res = Heapify(arr, 0);

            for (int idx = 0; idx < res.Length; idx++)
            {
                Console.WriteLine(res[idx].ToString());
            }
            Console.Read();
        }

        private int[] Heapify(int[] arr, int count)
        {
            if(count < arr.Length)
                arr = Heapify(arr, ++count);  

            if (2 * count  < arr.Length )
            {
                int temp;
               // int min = arr[2 * count] > arr[2 * count + 1] ? arr[2 * count + 1] : arr[2 * count];
                //if (arr[count] > min)
                {
                    temp = arr[count];
                    if (2 * count +1 < arr.Length)
                    {
                        if (arr[count] > arr[2 * count + 1])
                        {
                            arr[count] = arr[2 * count + 1];
                            arr[2 * count + 1] = temp;
                        }
                    }
                    temp = arr[count];
                    if (arr[count] > arr[2 * count])
                    {
                        arr[count] = arr[2 * count];
                        arr[2 * count] = temp;
                    }
                }
            }
            return arr;
                     
        }

        private int[] CreHeapify(int[] arr, int count)
        {
            //if (count < arr.Length)
              //  Heapify(arr, ++count);

            while (2 * count < arr.Length)
            {
                int temp;
                // int min = arr[2 * count] > arr[2 * count + 1] ? arr[2 * count + 1] : arr[2 * count];
                //if (arr[count] > min)
                {
                    temp = arr[count];
                    if (2 * count + 1 < arr.Length)
                    {
                        if (arr[count] > arr[2 * count + 1])
                        {
                            arr[count] = arr[2 * count + 1];
                            arr[2 * count + 1] = temp;
                        }
                    }
                    if (arr[count] > arr[2 * count])
                    {
                        arr[count] = arr[2 * count];
                        arr[2 * count] = temp;
                    }
                }
                count++;
            }
            return arr;

        }


        private int[] Maxheapify(int[] arr)
        {
            int count = (arr.Length - 1) / 2;
            int leftChild; int rightChild;

            while(count >= 0)
            {
                leftChild = count * 2;
                rightChild = leftChild + 1;

                if(arr[count] < arr[leftChild])
                {
                    Swap(arr, count, leftChild);
                }
                else if (arr[count] < arr[rightChild])
                {
                    Swap(arr, count, rightChild);
                }

                count--;
            }
        }

        private void Swap(int[] arr, int source, int dest)
        {
            int temp;

            temp = arr[source];

            arr[source] = arr[dest];
            arr[dest] = temp;

        }
    }
}
