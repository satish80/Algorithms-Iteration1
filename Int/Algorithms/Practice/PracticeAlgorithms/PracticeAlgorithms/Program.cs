using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            DFSGraph g = new DFSGraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);


            //g.TraverseGraph(g);

            int[] arr = { 5, 4, 3 };
            int n = arr.Length;

            //subsetSums(arr, 0, n - 1);

            SubsetSum obj = new SubsetSum();
            //obj.subsetSums(arr, 0, n - 1);
            //obj.CheckSubSetSumExists(arr, 0, 2, 4);
            RecursionConcepts recursionObj = new RecursionConcepts();
            //obj.FindExponent(2, 3);

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(7);
            stack.Push(3);
            stack.Push(4);
            stack.Push(6);

            //obj.ReverseStack(stack);

            //SortStack obj = new SortStack();
            //obj.SortAscending(stack);

            //recursionObj.RecurseSortStack(stack);
            //recursionObj.Permutation();

            //recursionObj.Combination();
            int[] Val = { 60, 100, 120};
            int[] W = {10, 20, 30 };
            //recursionObj.Knapsack(Val, W, 50);
            DynamicProgramming dpObj = new DynamicProgramming();
            //dpObj.IsSubSetSum(arr, 17);
            dpObj.KnapSack(Val, W, 50);
            Console.Read();
        }
    }
}
