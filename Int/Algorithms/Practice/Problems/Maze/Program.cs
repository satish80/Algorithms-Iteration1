using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeTraversal();
        }

        private static void MazeTraversal()
        {
            #region Comments
            //0,0
            //Dest = row, col
            //blockers is arr contains 1

            //for (int ridx = 0; ridx < row; ridx++)
            //{
            //    for (int cidx = 0; cidx < col; cidx++)
            //    {
            //        //
            //        if (arr[ridx, cidx] == 1)
            //        {
            //            if (ridx < row)
            //                ridx++;
            //            else
            //            {
            //                if (cidx < col)
            //                    cidx++;
            //            }
            //        }
            //    }
            //}
            #endregion comments

            int[,] arr = new int[3,3] 
            {
                {0,0,0},
                {0,0,1},
                {1,0,0}
            };

            Console.WriteLine(RecurseTraversal(arr,0,0,2,2));
            Console.Read();
        }

        private static bool RecurseTraversal(int[,] arr, int row, int col, int rowBound, int colBound)
        {
            if (row == rowBound && col == colBound)
            {
                return true;
            }
            else
            {
                if (arr[row, col] != 1)
                {
                    if (row < rowBound)
                        row++;
                    else
                        return false;

                    if (RecurseTraversal(arr, row, col, rowBound, colBound))
                        return true;

                    if (col < colBound)
                        col++;
                    else
                        return false;

                    if (RecurseTraversal(arr, row, col, rowBound, colBound))
                        return true;

                    return false;
                }
                else
                    return false;
            }
        }
    }
}
