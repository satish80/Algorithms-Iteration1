using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Robot
    {
        public void RobotProblem()
        {
            //int[,] matrix = new int[3, 7] {
            //    { 1,2,3,4, 5, 6, 7 },
            //    { 11,12,13,14, 15, 16, 17 },
            //    { 21,22,23,24, 25, 26, 27 },
            //};
            //var m = matrix.GetUpperBound(0);
            //var n = matrix.GetUpperBound(1);
            var x = BackTracking( 0, 0, 1, 1);
            Console.WriteLine("Total unique path =" + x);
            Console.Read();
        }

        private int BackTracking( int row, int col, int m, int n)
        {
            if (row == m && col == n) return 1;
            if (row > m || col > n) return 0;
            return BackTracking(row + 1, col, m, n) + BackTracking(row, col + 1, m, n);
        }
    }
}
