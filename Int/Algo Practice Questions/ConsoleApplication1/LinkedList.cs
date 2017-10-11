using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LinkedListProblems
    {
        //In Linked list, Node has two pointers, one points to next node, other points to arbitrary node in the linked list. Write a function to return a new list which is clone of the given linked list (http://www.geeksforgeeks.org/a-linked-list-with-next-and-arbit-pointer/)
        //IsPalidrome singly linked list
        //Segregate odd elements and then even elements

        public LinkList linkList { get; set; }
        public void Process()
        {
        }

        private void SortLinkList()
        {
        }

        private LinkList AddLinkListNodes(LinkList lst1, LinkList lst2)
        {
            int carry = 0;
            int sum = 0;
            LinkList output = null;
            LinkList head = null;
            if (lst1 == null) return lst2;
            if (lst2 == null) return lst1;


            while (lst1 != null || lst2 != null)
            {
                sum = (lst1 == null ? 0 : lst1.Value) + (lst2 == null ? 0 : lst2.Value) + carry;
                carry = sum / 10;
                sum = sum % 10;

                if (head == null)
                {
                    head = new LinkList(sum);
                    output = head;
                }
                else
                {
                    head.Next = new LinkList(sum);
                    head = head.Next;
                }

                if (lst1 != null) lst1 = lst1.Next;
                if (lst2 != null) lst2 = lst2.Next;
            }
            return output;
        }

        private void MergeAlternate(LinkList lst1, LinkList lst2)
        {
            LinkList lst = lst1;
            LinkList output = lst1;
            bool flag = true;
            lst1 = lst1.Next;

            while (lst1 != null && lst2 != null)
            {
                if (flag)
                {
                    lst.Next = new LinkList(lst2.Value);
                    flag = false;
                    lst2 = lst2.Next;
                }
                else
                {
                    lst.Next = new LinkList(lst1.Value);
                    flag = true;
                    lst1 = lst1.Next;
                }
                lst = lst.Next;
            }

            while (lst1 != null)
            {
                lst.Next = new LinkList(lst1.Value);
                lst = lst.Next;
                lst1 = lst1.Next;
            }

            while (lst2 != null)
            {
                lst.Next = new LinkList(lst2.Value);
                lst = lst.Next;
                lst2 = lst2.Next;
            }

        }

        private void MergeSortLinkList(LinkList lst1, LinkList lst2)
        {
            LinkList lst = null;
            LinkList output = null;

            while (lst1.Next != null && lst2.Next != null)
            {
                if (lst1.Value < lst2.Value)
                {
                    if (lst == null)
                    {
                        lst = new LinkList(lst1.Value);
                        output = lst;
                    }
                    else
                    {
                        lst.Next = new LinkList(lst1.Value);
                        lst = lst.Next;
                    }
                    lst1 = lst1.Next;
                }
                else
                {
                    if (lst == null)
                    {
                        lst = new LinkList(lst2.Value);
                        output = lst;
                    }
                    else
                    {
                        lst.Next = new LinkList(lst2.Value);
                        lst = lst.Next;
                    }
                    lst2 = lst2.Next;
                }
            }

            while (lst1 != null)
            {
                if (lst == null) lst = new LinkList(lst1.Value);
                else lst.Next = new LinkList(lst1.Value);
                lst = lst.Next;
                lst1 = lst1.Next;
            }

            while (lst2 != null)
            {
                if (lst == null) lst = new LinkList(lst2.Value);
                else lst.Next = new LinkList(lst2.Value);
                lst = lst.Next;
                lst2 = lst2.Next;
            }

        }

        private LinkList MergeSortedLinkListInPlace(LinkList list1, LinkList list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;
            
            LinkList head;
            if (list1.Value < list2.Value)
            {
                head = list1;
            }
            else
            {
                head = list2;
                list2 = list1;
                list1 = head;
            }
            while (list1.Next != null && list2 != null)
            {
                if (list1.Next.Value <= list2.Value)
                {
                    list1 = list1.Next;
                }
                else
                {
                    LinkList tmp = list1.Next;
                    list1.Next = list2;
                    list2 = tmp;
                }
            }
            if (list1.Next == null)
            {
                list1.Next = list2;
            }
            return head;
        }

        public void HasDLLPairWithASum(int sum)
        {
            //assume, its is sorted
            var pt1 = linkList;
            var pt2 = linkList;

            //move the p2 to the last element
            while (pt2.Next != null) 
                pt2 = pt2.Next;

            while (pt1.Value < pt2.Value)
            {
                if (pt1.Value + pt2.Value == sum)
                {
                    Console.WriteLine("Good, got it");
                    pt1 = pt1.Next;
                    pt2 = pt2.Previous;
                }
                else if (pt1.Value + pt2.Value < sum)
                {
                    pt1 = pt1.Next;
                }
                else if (pt1.Value + pt2.Value > sum)
                {
                    pt2 = pt2.Previous;
                }
            }
        }

        public LinkList IntersectionPtTwoLinkedList(LinkList l1, LinkList l2)
        {
            //O (n+m)
            //consider l1 to be bigger
            var d = CountLinkList(l1) - CountLinkList(l2);
            for (int i = 0; i < d; i++)
            {
                l1 = l1.Next;
            }
            while (l1 != null && l2 != null)
            {
                if (l1 == l2) 
                    return l1; //this is the intersecting pt
                l1 = l1.Next; 
                l2 = l2.Next;
            }
            return null;
        }

        public int CountLinkList(LinkList lst)
        {
            int count = 1;
            while (lst.Next != null)
            {
                lst = lst.Next;
                count++;
            }
            return count;
        }

        //turtle, hare approach
        public LinkList MedianOfaLinkList(LinkList lst)
        {
            var slow = lst;
            var fast = lst;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        //Floyds cycle detection alogoritgm
        public void IfLinkListCircular()
        {
            var slow = linkList;
	        var fast = linkList;
            while (slow.Next != null)
            {
                if (fast.Next == slow || fast.Next.Next == slow)
                {
                    //"Yes, its circular"
                    break;
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            //Get the point where the loop is started
            var ptr1 = slow;
            var ptr2 = slow;
            int k = 0; //no of nodes in a loop
            while (ptr1.Next != ptr2)
            {
                k++;
                ptr1 = ptr1.Next;
            }

            ptr1 = linkList; //reset it to head
            for (int i = 0; i < k; i++) ptr2 = ptr2.Next; //move it to kth position

            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;

            }

            //when they meet, its the starting of the loop
        }

        public void SwapElements(LinkList lst)
        {
            //1-2-3-4-5-6
            //2-1-4-3-6-5
            if (lst == null || lst.Next == null) { }
            else
            {
                var p = lst;
                var q = lst.Next;

                while (q != null)
                {
                    var tmp = p.Value;
                    p.Value = q.Value;
                    q.Value = tmp;
                    p.Next = q.Next;
                    q = p != null ? p.Next : null;
                }
            }
        }

        public LinkList ReverseDLL(LinkList lst)
        {
            //1 <--> 2 <--> 3 <--> 4 <--> 5 <-->6
            //6 <--> 5 <--> 4 <--> 3 <--> 2 <--> 1
            LinkList tmp = null;
            var current = lst; //swap previos and next pointers
            while (current != null)
            {
                tmp = current.Previous;
                current.Previous = current.Next;
                current.Next = tmp;
                current = current.Previous;
            }
            if (tmp != null) 
                lst = tmp.Previous;

            return lst;
        }

        public LinkList ReverseLinkedList(LinkList lst)
        {
            LinkList newList = null;
            while (lst != null)
            {
                var t = lst;
                lst = lst.Next;
                t.Next = newList;
                newList = t;
            }
            return newList;
        }

        public LinkList ReverseLinkedListByKNodes(LinkList lst, int k)
        {
            //1 -> 2 -> 3 -> 4 -> 5 -> 6
            //3 -> 2 -> 1 -> 6 -> 5 -> 4
            LinkList current = lst;
            LinkList next = null;
            LinkList prev = null;
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

        public LinkList RotateLinkListByK(LinkList lst, int k)
        {
            //123456
            //345612
            LinkList head = lst;
            LinkList kthNode = null; //the new head
            LinkList lastNode = null; //next of this is the current head
            int c = 1;

            while (lst != null)
            {
                if (lst.Next == null) lastNode = lst;
                if (c == k) kthNode = lst;

                c++;
                lst = lst.Next;
            }

            lastNode.Next = head;
            head = kthNode.Next;
            kthNode.Next = null;

            return head;
        }

        private void Extra()
        {
            var lst2 = new LinkList(0);
            lst2.Next = new LinkList(51);
            lst2.Next.Next = new LinkList(52);
            lst2.Next.Next.Next = new LinkList(53);
            lst2.Next.Next.Next.Next = new LinkList(55);
        }
    }
}
