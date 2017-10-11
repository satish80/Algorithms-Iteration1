using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class Solution2
    {
        public Solution2()
        {
            ConstructSLL();
        }

        public void ConstructSLL()
        {
            Node node3 = new Node()
            {
                Next = null,
                Value = 3
            };

            Node node2 = new Node()
            {
                Next =node3,
                Value = 2
            };

            Node node1 = new Node()
            {
                Next =node2,
                Value = 1                
            };

            Node reversedNode = ReverseSLL(node1);
            Console.Read();
        }

        public Node ReverseSLL(Node head)
        {
            if (head == null)
                throw new Exception("The list is null and cannot be reversed.");

            if (head.Next == null)
                return head;

            Node Prev = null;
            Node current = head;
            Node Next = null;
            
            
            while(current != null)
            {
                Next = current.Next;
                current.Next = Prev;                
                Prev = current;
                current = Next;
            }
            return Prev;
        }
    }   
}
