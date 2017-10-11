using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ShuffleCards
    {
        public void ShuffleArrangement()
        {
            int[] arr = new int[] {1,2,3,4,5,6,7,8};
            Shuffle(ref arr, 8);
            print(arr);
            Console.Read();
        }

        private void print(int[] arr)
        {
            for (int idx = 0; idx <= arr.Length-1; idx++)
            {
                Console.WriteLine(arr[idx].ToString());
            }
        }

        private void Shuffle(ref int[] arr, int size)
        {
            for (int idx = size - 1; idx > 0; idx--)
            {
                Random random = new Random(idx);
                int j = (random.Next()) % idx + 1;

                int temp;
                temp = arr[j];
                arr[j] = arr[idx];
                arr[idx] = temp;
            }
        }               
    }
}
