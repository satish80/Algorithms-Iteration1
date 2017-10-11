using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList1
{
    public class SwapItems
    {
        public void SwapItemsInLinkedList()
        {
            Console.WriteLine("Enter items");
            Node current = null;
            Node head = null;
            Node temp = null;

            string input;
            int intValue;

            while(true)
            {
                
                input = Console.ReadLine();
                if(!int.TryParse(input, out intValue))
                    break;

                temp = new Node();
                temp.info = (intValue);

                if (current == null)
                    current = temp;
                else
                {
                    current.next = temp;
                    current = current.next;
                }

                if (head == null)
                    head = current;                

            } 

            current.next = null;

            Node node = SwapListItems(head);
            DisplaySwappedItems(node);
        }

        private void DisplaySwappedItems(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.info);
                current = current.next;
            }
            Console.Read();
        }

        private Node SwapListItems(Node head)
        {
            Node crawl = head;
            int temp;

            while (crawl.next != null)
            {
                temp = crawl.next.info;
                crawl.next.info = crawl.info;
                crawl.info = temp;
                crawl = crawl.next.next;

                if (crawl == null)
                    break;
            } ;

            return head;
        }
    }
}
