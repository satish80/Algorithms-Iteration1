using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StackProblems
    {
        public Stack<int> mainStack = null;

        public void Process()
        {
            var x =ReverseInPlace(mainStack);
        }

        private void MinInConstantTime()
        {
        }

        private void MiddleElementOfStack()
        {
        }

        #region Reverse Stack In Place
        public Stack<int> ReverseInPlace(Stack<int> input)
        {
            if (input.Count > 0)
            {
                var top = input.Pop();
                ReverseInPlace(input);
                InsertAtBottom(ref input, top);
                return input;
            }
            else return null;
        }

        private void InsertAtBottom(ref Stack<int> input, int data)
        {
            if (input.Count <= 0)
            {
                input.Push(data);
            }
            else
            {
                var tmp = input.Pop();
                InsertAtBottom(ref input, data);
                input.Push(tmp);
            }
        }
        #endregion

        private static Stack<int> MergeStacks(Stack<int> s1, Stack<int> s2)
        {
            //Using Merge Sort, merge the two arrays
            Stack<int> s1s2Merged = new Stack<int>(s1.Count + s2.Count); //create a stack which has can hold all the elements of three stacks

            while (s1.Count > 0 && s2.Count > 0)
            {
                if (s1.Peek() > s2.Peek())
                {
                    s1s2Merged.Push(s1.Pop());
                }
                else
                {
                    s1s2Merged.Push(s2.Pop());
                }
            }

            if (s1.Count > 0)
                while (s1.Count > 0) s1s2Merged.Push(s1.Pop());

            if (s2.Count > 0)
                while (s2.Count > 0) s1s2Merged.Push(s2.Pop());


            //reverse the stack
            var x = new Stack<int>();
            while (s1s2Merged.Count > 0)
            {
                x.Push(s1s2Merged.Pop());
            }

            return x;
        }

        private static Stack<int> SortStack(Stack<int> input)
        {
            var aux = new Stack<int>();
            for (int i = 0; i <= input.Count - 1; i++)
            {
                var tmp = input.Pop();
                if (aux.Count > 0 && aux.Peek() > tmp)
                {
                    input.Push(aux.Pop());
                }
                input.Push(tmp);
            }
            return input;
        }
    }
}
