using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static Tree mainTree = null;
        static LinkList linkList = null;
        
        static void Main(string[] args)
        {
            MakeData();
            var arr = new int[] { 1, 2, 3, 4, 5, 6 };
            //RotateArrayByKPosition(arr, 2);

            var s1 = new Stack<int>();
            s1.Push(1);
            s1.Push(3);
            s1.Push(5);
            s1.Push(8);
            var s2 = new Stack<int>();
            s2.Push(-6);
            s2.Push(7);
            s2.Push(10);
            s2.Push(15);
            var s3 = new Stack<int>();
            s3.Push(-2);
            s3.Push(9);
            s3.Push(12);
            s3.Push(13);

            LinkedListProblems linkLstProbs = new LinkedListProblems();
            linkLstProbs.linkList = linkList;
            TreeFunctions treeProbs = new TreeFunctions();
            treeProbs.linkList = linkList;
            treeProbs.mainTree = mainTree;
            ArrayManipulation arrProbs = new ArrayManipulation();
            StackProblems stackProbs = new StackProblems();
            stackProbs.mainStack = s1;

            linkLstProbs.Process();
            treeProbs.Process();
            arrProbs.Process();
            stackProbs.Process();

            
            Console.Read();
        }


        
        


        private static void MakeData()
        {
            //                      6
            //          3                   9
            //      1       4           8       10
            //                  5
            mainTree = new Tree(6)
            {
                Left = new Tree(3)
                {
                    Left = new Tree(1),
                    Right = new Tree(4)
                    {
                        Right = new Tree(5)
                    }
                },
                Right = new Tree(9)
                {
                    Left = new Tree(8),
                    Right = new Tree(10)
                }
            };

            linkList = new LinkList(1);
            linkList.Next = new LinkList(2);
            linkList.Next.Next = new LinkList(3);
            linkList.Next.Next.Next = new LinkList(4);
            linkList.Next.Next.Next.Next = new LinkList(5);
            linkList.Next.Next.Next.Next.Next = new LinkList(6);
            linkList.Next.Next.Next.Next.Next.Next = linkList.Next.Next.Next;
        }

        
    }

    

    
    
}
