using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class Solution3
    {
        public void ConstructTree()
        {
            DLLNode node1 = new DLLNode()
                {
                    Value =1
                };
            DLLNode node2 = new DLLNode()
            {
                Value = 2
            };

            DLLNode node3 = new DLLNode()
            {
                Value = 3
            };

            DLLNode node4 = new DLLNode()
            {
                Value = 4
            };

            DLLNode node5 = new DLLNode()
            {
                Value = 5
            };

            DLLNode node6 = new DLLNode()
            {
                Value = 6
            };

            DLLNode node7 = new DLLNode()
            {
                Value = 7
            };


            node7.Parent = node6.Parent= node3;
            node3.Left = node6;
            node3.Right = node7;

            node5.Parent = node4.Parent = node2;
            node2.Left = node4;
            node2.Right = node5;

            node2.Parent = node3.Parent = node1;
            node1.Left = node2;
            node1.Right = node3;

            node1.Parent = null;

            Console.WriteLine(FindAncestor(node4,node5).Value.ToString());
            Console.Read();
        }

        public DLLNode FindAncestor(DLLNode first, DLLNode second)
        {
            if (first == null || second == null)
                return null;

            DLLNode firstPtr = first;
            DLLNode secondPtr = second;
            DLLNode Ancestor = null;

            while(firstPtr.Parent != null && secondPtr.Parent != null)
            {
                if (firstPtr.Parent == secondPtr.Parent)
                {
                    Ancestor = firstPtr.Parent;
                    break;
                }

                firstPtr = firstPtr.Parent;
                secondPtr = secondPtr.Parent;
            }

            if (Ancestor == null && firstPtr.Parent != null && secondPtr.Parent==null)
            {
                while (firstPtr.Parent!=null)
                {
                    firstPtr = firstPtr.Parent;
                    if (firstPtr == secondPtr)
                        Ancestor = firstPtr;
                }
            }
            else if (Ancestor == null && firstPtr.Parent  == null && secondPtr.Parent != null)
            {
                while (secondPtr.Parent != null)
                {
                    secondPtr = secondPtr.Parent;
                    if (firstPtr == secondPtr)
                        Ancestor = firstPtr;
                }
            }


            return Ancestor;
        }
    }

    public class DLLNode
    {
        public DLLNode Left;
        public DLLNode Right;
        public DLLNode Parent;
        public int Value;
    }
}
