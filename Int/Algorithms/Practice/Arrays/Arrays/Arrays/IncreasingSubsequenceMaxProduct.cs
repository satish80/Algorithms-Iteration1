using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class IncreasingSubsequenceMaxProduct
    {
        public void MaxSubsequenceProduct()
        {
            int[] arr = { 1, 5, 10, 8, 9 };


            int one, two, three;
            int idx = 0;

            if (arr[idx] > arr[idx + 1])
            {
                one = arr[idx + 1];
                two = arr[idx];
            }
            else
            {
                one = arr[idx];
                two = arr[idx + 1];
            }

            if (arr[idx + 2] > two)
            {
                three = arr[idx + 2];
            }
            else
            {
                if (arr[idx + 2] < one)
                {
                    three = two;
                    two = one;
                    one = arr[idx + 2];
                }
                else
                {
                    three = two;
                    two = arr[idx + 2];
                }
            }

            for (int i = 0; i < arr.Length; i ++)
            {
                if (arr[i] > three)
                {
                    one = two;
                    two = three;
                    three = arr[i];
                }
                else if(arr[i]<three && arr[i] > two)
                {
                    one = two;
                    two = arr[i];
                }
                else if(arr[i]>one && arr[i]<two)
                {
                    one = arr[i];
                }
            }

            Console.WriteLine("{0} {1} {2}", one,two,three);

        }
    }
}
