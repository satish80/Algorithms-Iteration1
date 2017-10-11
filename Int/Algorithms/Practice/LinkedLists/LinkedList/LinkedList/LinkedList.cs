using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListFacade
    {
        public void SortLinkedList()
        {
            Node head =null,tail =null;
            Node current;

            ConsoleKeyInfo info = new ConsoleKeyInfo();

            while (info.Key != ConsoleKey.Escape) 
            {
                Console.WriteLine("Enter the value of the node");
                info = Console.ReadKey();

                if (info.Key != ConsoleKey.Escape)
                {
                    current = new Node()
                    {
                        Value = Convert.ToInt32(info.KeyChar.ToString())
                    };
                    if (head == null)
                    {
                        head = current;                       
                        tail = current;
                        tail.Next = null;
                    }
                    else
                    {
                        tail.Next = current;
                        tail = current;
                        tail.Next = null;
                    }
                }
            }

            Node Middle = findMiddle(head,tail);

            Node fhalf = MergeSort(head, Middle);

            Node shalf = MergeSort(Middle.Next, tail);

            Node sorted = Merge(fhalf,shalf);

            PrintList(sorted);
        }

        Node MergeSort(Node fhalf,Node shalf)
        {
            Node tempFhalf = null;
            if (fhalf.Next  == null)
                return fhalf;

            if (shalf.Next == null)
            {
                while (fhalf.Next != shalf.Next)
                {
                    if (fhalf.Value > fhalf.Next.Value)
                    {
                        int temp = fhalf.Value;
                        fhalf.Value = fhalf.Next.Value;
                        fhalf.Next.Value = temp;
                    }
                    fhalf = fhalf.Next;
                }
                return shalf;
            }                     

            if (fhalf.Next == shalf)
            {
                if (fhalf.Value > shalf.Value)
                {
                    int temp = fhalf.Value;
                    fhalf.Value = shalf.Value;
                    shalf.Value = temp;                    
                }
                return shalf;
            }
            else
            {
                tempFhalf = fhalf;

                while (fhalf.Next != shalf.Next)
                {
                    if (fhalf.Value > fhalf.Next.Value)
                    {
                        int temp = fhalf.Value;
                        fhalf.Value = fhalf.Next.Value;
                        fhalf.Next.Value = temp;                        
                    }
                    fhalf = fhalf.Next;                    
                }                
            }

            Node Middle = findMiddle(tempFhalf, shalf);

            return MergeSort(tempFhalf, Middle);
        }

        Node Merge(Node first, Node second)
        {
            Node SortedList = null;
            while (first.Next != null || second.Next != null)
            {
                if (first.Value < second.Value)
                {
                    if (SortedList == null)
                        SortedList = first;
                    else
                        SortedList.Next = first;

                    first = first.Next;
                }
                else
                {
                    if (SortedList == null)
                        SortedList = second;
                    else
                        SortedList.Next = second;

                    second = second.Next;
                }
            }

            if (SortedList != null && (first.Next !=null || second.Next !=null))
                SortedList.Next = (first.Next == null ? second.Next : first.Next);
            else
            {
                SortedList = new Node();
                SortedList = (first.Next == null ? second.Next : first.Next);
            }
            return SortedList;
        }

        Node findMiddle(Node head, Node tail)
        {
            Node slow = head, fast = head;
            do
            {
                if (fast.Next != null)
                {
                    if (fast.Next.Next == tail)
                    {
                        fast = fast.Next.Next;
                        slow = slow.Next;
                        break;
                    }
                    else
                    {
                        fast = fast.Next.Next;
                        slow = slow.Next;
                    }
                }
                else
                    break;

            } while (fast !=null);
            return slow;
        }

        void PrintList(Node node)
        {
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Console.Read();
        }

        public void FindIntersection()
        {
            Node f = new Node()
            {
                Value = 200,
                Next = null
            };

            Node e = new Node()
            {
                Value = 100,
                Next = f
            };

            Node d = new Node()
            {
                Value =10,
                Next = e
            };
            Node c = new Node()
            {
                Value = 20,
                Next = d
            };

            Node b = new Node()
            {
                Value = 30,
                Next = c
            };
            Node a = new Node()
            {
                Value = 40,
                Next = b
            };

            Node c1 = new Node()
            {
                Value =10,
                Next = e
            };

            Node b1 = new Node()
            {
                Value = 20,
                Next = c1
            };

            Node a1 = new Node()
            {
                Value = 30,
                Next = b1
            };

            Console.WriteLine(ReturnIntersection(a, a1).Value);
        }

        private Node ReturnIntersection(Node first, Node second)
        {
            int diff = Length(first) - Length(second);

            for (int idx = 0; idx < diff; idx++)
                first = first.Next;

            Node intersection= null;
            while(true)
            {
                if (first == second)
                {
                    intersection= first;
                    break;
                }
                else
                {
                    if (first.Next != null && second.Next != null)
                    {
                        first = first.Next;
                        second = second.Next;
                    }
                    else
                        break;
                }
            }

            return intersection;
        }

        public void ReverseKNodes()
        {
            Node e = new Node()
            {
                Next = null,
                Value =5
            };

            Node d = new Node()
            {
                Next = e,
                Value =4
            };

            Node c = new Node()
            {
                Next =d,
                Value =3
            };

            Node b = new Node()
            {
                Next = c,
                Value = 2
            };

            Node a = new Node()
            {
                Next = b,
                Value = 1
            };

            Node revNode = ReverseLinkedListByKNodes(a, 3);
        }

        private Node ReverseKNodes(Node head, int k)
        {
            int count = k;
            bool setHead = false;
            Node Current = head;
            while (head.Next != null)
            {
                while (k > 1)
                {
                    Node Prev = Current;
                    Current = Current.Next;
                    Node Next = Current.Next;
                    Current.Next = Prev;
                    Prev.Next = Next;
                    k--;
                    Current = Current.Next;
                }
                k = count;
            }

            return head;
        }

        public Node ReverseLinkedListByKNodes(Node lst, int k)
        {
            //1 -> 2 -> 3 -> 4 -> 5 -> 6
            //3 -> 2 -> 1 -> 6 -> 5 -> 4
            Node current = lst;
            Node next = null;
            Node prev = null;
            int count = 0;
            while (current != null && count < k)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
                count++;
            }


            if (next != null)
                lst.Next = ReverseLinkedListByKNodes(next, k);

            return prev;

        }

        public void ReverseDLL()
        {
            DLLNode node1 = null, node2 = null, node3 = null, node4 = null, node5 = null;

            node5 = new DLLNode()
            {
                Value = 5,
                Next = null,                
            };

            node4 = new DLLNode()
            {
                Value = 4,                
            };

            node3 = new DLLNode()
            {
                Value = 3,               
            };

            node2 = new DLLNode()
            {
                Value = 2,               
            };

            node1 = new DLLNode()
            {
                Value =1,
                Prev = null,
                Next = node2
            };

            node2.Next = node3;
            node2.Prev = node1;

            node3.Next = node4;
            node3.Prev = node2;

            node4.Next = node5;
            node4.Prev = node3;

            node5.Prev = node4;

            DLLNode rHead = ReverseDLL(node1);
        }

        private DLLNode ReverseDLL(DLLNode lst)
        {
            DLLNode tmp = null;
            var current = lst; //swap previos and next pointers
            while (current != null)
            {
                tmp = current.Prev;
                current.Prev = current.Next;
                current.Next = tmp;
                current = current.Prev;
            }
            if (tmp != null)
                lst = tmp.Prev;

            return lst;       
        }
        
        private int Length(Node node)
        {
            int count = 1;

            while (node.Next != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }
        public class Node
        {
            public int Value;
            public Node Next;
        }

        public class DLLNode
        {
            public int Value;
            public DLLNode Prev;
            public DLLNode Next; 
        }
    }

    
    
}
