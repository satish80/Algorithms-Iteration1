using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class SortStack
    {
        public Stack<int> SortAscending(Stack<int> source)
        {
            int sourceLength = source.Count;
            Stack<int> dest = new Stack<int>(sourceLength);

            while(dest.Count < sourceLength)
            {
                int cur = source.Pop();

                if(dest.Count == 0 || dest.Peek() < cur)
                {
                    dest.Push(cur);
                }
                else
                {
                    Transfer(dest, source, cur);
                }
            }

            return dest;
        }

        private void Transfer(Stack<int> dest, Stack<int> source, int insertVal)
        {
            int count = 0;

            while(dest.Count > 0 && dest.Peek() > insertVal)
            {
                source.Push(dest.Pop());
                count++;
            }
            dest.Push(insertVal);

            while(count >0)
            {
                dest.Push(source.Pop());
                count--;
            }
        }
    }
}
