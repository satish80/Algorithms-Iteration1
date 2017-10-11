using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    public class PhoneDialpad
    {
        public void Recurse(int row, int col, string[,] arr, ref int index)
        {
            if (row > 2)
                return;

            Console.WriteLine(arr[row,col]);

            for(int i= 0; i < 3; i++)
            {
                if (row < 2)
                {
                    Recurse(++row, i, arr, ref index);
                }
                else
                {
                    if (i < 2)
                        i++;
                    Console.WriteLine(arr[row, i]);
                }
            }
        }
    }
}