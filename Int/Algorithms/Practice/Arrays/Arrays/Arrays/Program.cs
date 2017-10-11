using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Median of Sorted Array
            MedianOfSortedArray median = new MedianOfSortedArray();
            median.CalcMedian();
            #endregion

            #region MergeSort of Arrays
            //MergeSortArray obj = new MergeSortArray();
            //obj.Sort();
            #endregion

            #region CardShuffle
            //ShuffleCards obj = new ShuffleCards();
            //obj.ShuffleArrangement();
            #endregion

            //Crossword obj = new Crossword();
            //obj.SolveCrossword();

            //SortStack obj = new SortStack();
            //obj.Sort();

            //Robot obj = new Robot();
            //obj.RobotProblem();
            //PrimeNo obj = new PrimeNo();
            //obj.NoOfPrimes(10);

            RemoveDuplicates obj = new RemoveDuplicates();
            int[] ch = new int[] {1,2,3,8,7,4,3,3,3};
            //obj.RemoveDuplicatesInPlace(ch);

            //IncreasingSubsequenceMaxProduct obj = new IncreasingSubsequenceMaxProduct();
            //obj.MaxSubsequenceProduct();

           // MinOfSortedRotatedArray obj = new MinOfSortedRotatedArray();
            //obj.FindMin();

            //SortedRotatedArray obj = new SortedRotatedArray();
            //obj.Search();

            //ReverseStack rev = new ReverseStack();
            //Stack<int> stk = new Stack<int>();
            //stk.Push(3);
            //stk.Push(6);
            //stk.Push(8);
            //stk.Push(2);

            //rev.Reverse(stk);
            Console.Read();
        }
    }
}
