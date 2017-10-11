using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class Solution1
    {
        public Solution1()
        {
            ConstructSLL();
        }

        private void ConstructSLL()
        {
            Node node6 = new Node()
            {
                Value = 6,
                Next =null
            };

            Node node5 = new Node()
            {
                Value =5,
                Next = node6
            };

            Node node4 = new Node()
            {
                Value = 4,
                Next = node5
            };

            Node node3 = new Node()
            {
                Value = 3,
                Next = node4
            };

            Node node2 = new Node()
            {
                Value = 2,
                Next = node3
            };

            Node node1 = new Node()
            {
                Value = 1,
                Next = node2
            };

            Node FifthNode = Find5thNode(node3);
            Console.Read();
        }

        /// <summary>
        /// Returns the 5th Node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Find5thNode(Node head)
        {
            if (head == null)
                throw new Exception("The head is null.");

            Node slow = head;
            Node fast = head.Next;
            int count = 0;
            while (count++ < 3)
            {
                if(fast.Next != null)
                    fast = fast.Next;
                else
                    throw new Exception("List contains less than 5 elements.");
            }            

            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
        }
    }
}
