using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class RecursionConcepts
    {
        public void FindExponent(int num, int pow)
        {
            Console.WriteLine(RecurseExponent(num, pow));
        }

        private int RecurseExponent(int num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                return num * RecurseExponent(num, pow - 1);
            }
        }

        public void ReverseStack(Stack<int> stack)
        {
            RecurseStack(stack);
            Console.Read();
        }

        private void RecurseStack(Stack<int> stack)
        {
            int value = 0;

            if(stack.Count != 0)
            {
                Console.WriteLine(stack.Peek());
                value = stack.Pop();
                RecurseStack(stack);
                stack.Push(value);             
            }            
        }

        public Stack<int> RecurseSortStack(Stack<int> stack)
        {
            sortStack(stack);
            return stack;
        }

        void sortStack(Stack<int> s)
        {
            // If stack is not empty
            if (s.Count > 0)
            {
                // Remove the top item
                int x = s.Pop();

                // Sort remaining stack
                sortStack(s);

                // Push the top item back in sorted stack
                sortedInsert(s, x);
            }
        }

        void sortedInsert(Stack<int> s, int x)
        {
            // Base case: Either stack is empty or newly inserted
            // item is greater than top (more than all existing)
            if (s.Count == 0 || x > s.Peek())
            {
                s.Push(x);
                return;
            }

            // If top is greater, remove the top item and recur
            int temp = s.Pop();
            sortedInsert(s, x);

            // Put back the top item removed earlier
            s.Push(temp);
        }

        public void Permutation()
        {
            char[] arr = { 'a', 'b', 'c' };
            Permute(arr, 0, 3);
        }

        private void Permute(char[] arr, int k, int n)
        {
            if (k == n)
            {
                for (int idx = 0; idx < n; idx++)
                {
                    Console.WriteLine(arr[idx]);
                }
            }
            else
            {
                for(int i= k; i< n; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Permute(arr, k + 1, n);
                    Swap(ref arr[i], ref arr[k]);
                }
            }
        }

        private void Swap(ref char a, ref char b)
        {
            char temp = b;
            b = a;
            a = temp;
        }

        public void Combination()
        {            
            int[] rep = new int[3];
            RecurseCombination(rep, 0, 3);
        }

        private void RecurseCombination(int[] rep, int k, int n)
        {
            if(k == n)
            {
                PrintCombination(rep);
                return;
            }
            rep[k] = 0;
            RecurseCombination(rep, k + 1, n);
            rep[k] = 1;
            RecurseCombination(rep, k + 1, n);
        }

        void PrintCombination(int[] rep)
        {
            char[] arr = { 'a', 'b', 'c' };

            for(int idx =0; idx < rep.Length; idx ++)
            {
                if(rep[idx] == 1)
                {
                    Console.WriteLine(arr[idx]);
                }
            }
            Console.WriteLine("-----------------------------");
        }


        public void Knapsack(int[] Val, int[] W, int desiredWeight)
        {
            Console.WriteLine(SolveKnapSack(Val, W, 0, 0, desiredWeight, 0));
        }

        private int SolveKnapSack(int[] Val, int[] W, int wIdx, int SumOfWeight, int desiredWeight, int Profit)
        {            
            if(SumOfWeight == desiredWeight)
            {
                return Profit;
            }
            if (SumOfWeight > desiredWeight || wIdx == W.Length)
            {
                return 0;
            }
            else
            {
                return Math.Max(SolveKnapSack(Val, W, wIdx, SumOfWeight + W[wIdx], desiredWeight, Profit + Val[wIdx]), 
                    SolveKnapSack(Val, W, wIdx +1, SumOfWeight + W[wIdx +1], desiredWeight, Profit + Val[wIdx +1]));
            }
        }
    }
}
