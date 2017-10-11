using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ReverseStack
    {
        Stack<int> _input = null;

        public void Reverse(Stack<int> input)
        {
            _input = input;
            while(_input.Count > 0)
            {
                Console.WriteLine(_input.Pop());
            }
            Console.Read();
        }

        public void RecurseStack()
        {
            int value = _input.Pop();
            RecurseStack();
            _input.Push(value);
        }
    }
}
