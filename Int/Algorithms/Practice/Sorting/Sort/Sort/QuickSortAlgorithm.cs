using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class QuickSortAlgorithm
    {
        int q;
        public void Sort()
        {
            int[] arr = new int[] { 5,2,9,7,1,3,4};
            quicksort(arr,0,6);

            for (int idx = 0; idx < arr.Length; idx++)
                Console.WriteLine(arr[idx].ToString());
        }

        private void quicksort(int[] arr, int p, int r)
        {
            if(p < r)
            {
                q = Partition(arr,p,r);
                quicksort(arr,p, q);
                quicksort(arr,q+1,r);
            }
        }

        private int Partition(int[] arr, int p, int r)
        {
            int x = arr[(p+r)/ 2];

            int i = p;
            int j = r;

            while(true)
            {
                while (arr[j] > x)
                    j = j - 1;

                while (arr[i] < x)
                    i = i + 1;

                if (i < j)
                {
                    swap(ref arr[i], ref arr[j]);
                }
                else
                    return j;
            }
        }

        private void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
