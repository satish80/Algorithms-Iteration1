using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    class Program
    {
        static bool[,] placement = new bool[3, 3];
        static int placementCount = 0;
        static List<Tuple<int, int>> placeList = new List<Tuple<int, int>>();

        static void Main(string[] args)
        {
            //Console.WriteLine( Math.Sign(-23.34).ToString());
            #region Permutation
            Permutation obj = new Permutation();
            obj.DisplayPermutations();
            #endregion

            #region Maze
            //Console.WriteLine("Enter the Order");
            //int order = Convert.ToInt32(Console.ReadLine());

            //int row = 0, column = 0;
            //int[,] path = new int[order, order];
            //path[3, 3] = 3;
            //path[2, 0] = 1;
            //path[0, 1] = 1;
            //path[0, 2] = 1;
            //path[0, 3] = 1;
            //path[1, 2] = 1;
            //path[2, 2] = 1;
            //path[2, 3] = 1;

            //Maze maze = new Maze();
            //maze.Traverse(row, column, order, path);
            //for (int ridx = 0; ridx < order; ridx++)
            //{
            //    for (int cidx = 0; cidx < order; cidx++)
            //    {
            //        if (path[ridx, cidx] == 2)
            //            Console.WriteLine("{0} {1}", ridx.ToString(), cidx.ToString());
            //    }
            //}
            #endregion

            #region nQueen
           
            //PlaceQueen(2,2,3,0,0);

            //for (int idx = 0; idx < placeList.Count; idx++)
            //{
            //    Console.WriteLine("Placements {0} {1}", placeList[idx].Item1.ToString(), placeList[idx].Item2.ToString());
            //}
            #endregion

            SpiralTraversal traversal = new SpiralTraversal();
            int[,] arr = new int[3,3];
            arr[0, 0] = 1;
            arr[0, 1] = 2;
            arr[0, 2] = 3;
            arr[1, 0] = 8;
            arr[1, 1] = 9;
            arr[1, 2] = 4; 
            arr[2, 0] = 7; 
            arr[2, 1] = 6; 
            arr[2, 2] = 5;


            //traversal.Traverse(0,0, arr, true, false);
            string[,] txt = new string[3,3];
            txt[0, 0] = "A";
            txt[0, 1] = "B";
            txt[0, 2] = "C";
            txt[1, 0] = "D";
            txt[1, 1] = "E";
            txt[1, 2] = "F";
            txt[2, 0] = "G";
            txt[2, 1] = "H";
            txt[2, 2] = "I";

            //PhoneDialpad dialPad = new PhoneDialpad();
            //int index = 0;
            //int row =0;
            //dialPad.Recurse(0, 0, txt, ref index);
            Console.Read();
        }

        #region Adjacency List
        private static void ConstructAdjList(int row, int column,int Order)
        {           
            int cRow = 0, cColumn = 0;

            List<string> list = new List<string>();
            while (cColumn <= Order)
            {
                if (cRow <= Order)
                {
                    cRow++;
                    list.Add(cRow.ToString()+column.ToString());
                }
                else if (cColumn <= Order)
                {
                    cColumn++;
                    list.Add(row.ToString() + cColumn.ToString());
                }
            }

            for (int count = 0; count < Order; count++)
            {

            }
        }
        #endregion 

        private static void PlaceQueen(int row, int column, int order, int startRow, int startCol)
        {
            placeList.Add(new Tuple<int, int>(startRow, startCol));

            for (int ridx = 0; ridx < order; ridx++)
            {
                for (int cidx = 0; cidx < order; cidx++)
                {
                    if (!placeList.Contains(new Tuple<int,int>(ridx,cidx)))
                    {
                        if (PassRules(ridx, cidx, order))
                        {
                            placeList.Add(new Tuple<int, int>(ridx, cidx));
                            placementCount++;
                        }
                    }
                }
            }

            if (placementCount < order)
            {
                if (startCol < order)
                {
                    placementCount = 0;
                    placeList.Clear();
                    startCol++;

                    PlaceQueen(row, column, order, startRow, startCol);
                }
                else if (startRow < order)
                {
                    placementCount = 0;
                    placeList.Clear();
                    startRow++;

                    PlaceQueen(row, column, order, startRow, startCol);
                }
               
            }
        }

        private static bool PassRules(int row, int column, int order)
        {            
            foreach (Tuple<int,int> keyPair in placeList)
            {
                if((Math.Abs(row - keyPair.Item1) == Math.Abs(column - keyPair.Item2)))
                    return false;

                if(row == keyPair.Item1 || column == keyPair.Item2)
                    return false;
            }
            return true;
        }
    }
}
