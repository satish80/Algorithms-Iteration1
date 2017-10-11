using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] res= RotateMatrixBy90();

            for (int idx = 0; idx <= res.GetUpperBound(0); idx++)
            {
                for (int innerIdx = 0; innerIdx <= res.GetUpperBound(1); innerIdx++)
                {
                    Console.Write(res[idx,innerIdx]);
                }
                Console.WriteLine("\n");
            }

            Console.Read();
        }

        public static int[,] RotateMatrixBy90()
        {
            //O(n2)
            int[,] matrix = new int[4, 4] {
                { 1,2,3,4 },
                { 5,6,7,8 },
                { 9,0,1,2 },
                { 3,4,5,6 }
            };

            int n = 4;
            int[,] ret = new int[n, n];
            for (int i = 0; i < n; ++i)
           {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n -j-1, i];
                }
            }
            return ret;
        }
    }
}
