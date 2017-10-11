using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    public class SpiralTraversal
    {
        int colBounds = 3;
        int rowBounds = 3;

        public void Traverse(int row, int col, int[,] arr, bool ltoR, bool TTB)
        {
            if (arr[row, col] != 0)
            {

                if (ltoR)
                {
                    print(row, col, arr);

                    if (++col < colBounds)
                    {
                        Traverse(row, col, arr, true, false);
                    }
                    else
                    {
                        col--;
                        row++;
                        Traverse(row, col, arr, false, true);
                    }
                }
                else if (TTB)
                {
                    print(row, col, arr);

                    if (++row < rowBounds)
                    {
                        Traverse(row, col, arr, false, true);
                    }
                    else
                    {
                        row--;
                        col--;
                        Traverse(row, col, arr, false, false);
                    }
                }
                else if (!ltoR && !TTB)
                {
                    print(row, col, arr);

                    if (--col >= 0)
                    {
                        Traverse(row, col, arr, false, false);
                    }
                    else
                    {
                        col++;
                        row--;
                        Traverse(row, col, arr, true, false);
                    }
                }
            }
        }

        private void print(int row, int col, int[,] arr)
        {
            Console.WriteLine(arr[row, col]);
            arr[row, col] = 0;
        }
    }

    
}
