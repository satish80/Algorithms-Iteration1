using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 3, 17, 10, 84, 19, 6, 22, 9 };
            HeapSort obj = new HeapSort();
            int[] res = obj.MinHeap(arr, 0);

            for (int idx = 0; idx < res.Length - 1; idx++)
                Console.WriteLine(res[idx].ToString());

            Console.Read();
        }
    }

    public class HeapSort
    {
        public int[] MinHeap(int[] arr, int count)
        {
            if (count < arr.Length)
                MinHeap(arr, ++count);

            if (2 * count < arr.Length)
            {
                int temp = arr[count];
                if (2 * count + 1 < arr.Length)
                {
                    if (arr[count] > arr[(2 * count) + 1])
                    {
                        arr[count] = arr[2 * count + 1];
                        arr[(2 * count) + 1] = temp;
                    }
                }

                if (arr[count] > arr[(2 * count)])
                {
                    arr[count] = arr[(2 *count)];
                    arr[(2 * count)] = temp;
                }
            }
            return arr;
        }

        private void swap(ref int[] arr, int parent, int child)
        {

        }

        public void Heapify(int[] arr)
        {

        }
    }
}
