using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList1;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            RevisedMergeSort facade = new RevisedMergeSort();
            facade.SortLinkedList();

            //SwapItems items = new SwapItems();
            //items.SwapItemsInLinkedList();

            //LinkedListFacade obj = new LinkedListFacade();
           // obj.FindIntersection();
            //obj.ReverseKNodes();
            //obj.ReverseDLL();

            Console.Read();
        }
    }
}
