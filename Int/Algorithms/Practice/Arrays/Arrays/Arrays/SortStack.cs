using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class SortStack
    {
        public void Sort(Stack<int> input)
        {
            for (int idx = 0; idx < input.Count; idx++)
            {
                int first = input.Pop();
                int Second = input.Pop();

                if (first > Second)
                {
                    int temp = Second;
                    Second = first;
                    first = temp;
                    input.Push(first);
                }
            }
        }
    }
}
