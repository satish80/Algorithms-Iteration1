using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStackUsingRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(5);
            stack.Push(7);
            stack.Push(1);
            ReverseStack(stack);
            Console.Read();
        }

        private static Stack<int> ReverseStack(Stack<int> stk)
        {
            if (stk.Count > 0)
            {
                var temp = stk.Pop();
                ReverseStack(stk);
                InsertAtBottom(ref stk,temp);
                return stk;
            }
            else
                return null;
        }

        private static void InsertAtBottom(ref Stack<int> stk, int data)
        {
            stk.Push(data);
        }
    }
}
