using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapSort heapSort = new HeapSort();
            heapSort.ConstructHeap();

            #region QuickSort
            //QuickSortAlgorithm obj = new QuickSortAlgorithm();
           // obj.Sort();
            #endregion

            Console.Read();
        }
    }
}
