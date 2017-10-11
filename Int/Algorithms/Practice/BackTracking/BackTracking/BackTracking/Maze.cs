using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    public class Maze
    {
        public void Traverse(int row, int column, int order, int[,] path)
        {
            if (path[row, column] == 3)
            {
                return;
            }
            else
            {
                if (row < order)
                {
                    if (path[row, column] != 1)
                    {
                        path[row, column] = 2;

                        if (row < order && ++row < order)
                            Traverse(row, column, order, path);
                        else
                            row--;

                        if (column < order)
                        {
                            column++;
                            Traverse(row, column, order, path);
                        }
                    }
                }                
            }
        }
    }
}
