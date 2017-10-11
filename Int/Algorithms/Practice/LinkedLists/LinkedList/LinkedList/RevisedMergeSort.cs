using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList1
{
    public class RevisedMergeSort
    {
        public void SortLinkedList()
        {
            Node head = null, tail = null;
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
                        info = Convert.ToInt32(info.KeyChar.ToString())
                    };

                    if (head == null)
                    {
                        head = current;
                        tail = current;
                        tail.next= null;
                    }
                    else
                    {
                        tail.next = current;
                        tail = current;
                        tail.next = null;
                    }
                }
            }
            Node sorted = merge_sort(head);

            PrintList(sorted);
        }

        public Node merge_sort(Node head)
        {
            if (head == null || head.next == null) 
            {
                return head; 
            }
            Node middle = getMiddle(head);      //get the middle of the list
            Node sHalf = middle.next; 
            middle.next = null;   //split the list into two halfs

            return merge(merge_sort(head), merge_sort(sHalf));  //recurse on that
        }

        //Merge subroutine to merge two sorted lists
        public Node merge(Node a, Node b)
        {
            Node dummyHead, curr; 
            dummyHead = new Node(); 
            curr = dummyHead;
            while (a != null && b != null)
            {
                if (a.info <= b.info) 
                {
                    curr.next = a; 
                    a = a.next; 
                }
                else
                {
                    curr.next = b;
                    b = b.next;
                }
                curr = curr.next;
            }
            curr.next = (a == null) ? b : a;
            return dummyHead.next;
        }

        //Finding the middle element of the list for splitting
        public Node getMiddle(Node head)
        {
            if (head == null) { return head; }
            Node slow, fast; slow = fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next; fast = fast.next.next;
            }
            return slow;
        }

        void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.info);
                node = node.next;
            }
            Console.Read();
        }
    }

    public class Node
    {
        public int info;
        public Node next;
    }
}
