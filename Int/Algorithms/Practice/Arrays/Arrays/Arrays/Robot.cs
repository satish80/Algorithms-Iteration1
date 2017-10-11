using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Robot
    {
        public void RobotProblem()
        {
            //int[,] matrix = new int[3, 7] 
            //{
            //    { 1,2,3,4, 5, 6, 7 },
            //    { 11,12,13,14, 15, 16, 17 },
            //    { 21,22,23,24, 25, 26, 27 },
            //};

            int[,] matrix = new int[3, 4]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12}
            };
            var m = matrix.GetUpperBound(0);
            var n = matrix.GetUpperBound(1);
            var x = BackTracking(matrix, 0, 0, m, n);
            Console.WriteLine("Total unique path =" + x);
        }

        private int BackTracking(int[,] matrix, int row, int col, int m, int n)
        {
            Console.WriteLine("Passing through {0} {1}", row, col);
            if (row == m && col == n)
            {
                Console.WriteLine("reached");
                return 1;
            }
            if (row > m || col > n) 
                return 0;
            return BackTracking(matrix, row + 1, col, m, n) + BackTracking(matrix, row, col + 1, m, n);
        }
    }
}
