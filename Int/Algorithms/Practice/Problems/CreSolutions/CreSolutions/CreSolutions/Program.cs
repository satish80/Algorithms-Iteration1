using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreSolutions
{
    public class Program
    {
        static int result = 0;
        static void Main(string[] args)
        {
            Tree obj = new Tree();
            obj.Value = 10;

            obj.Left = new Tree()
            {
                Value = 8
            };
            obj.Right = new Tree()
            {
                Value = 14
            };

            obj.Left.Left = new Tree()
            {
                Value = 6,
                Left = null,
                Right = null
            };

            obj.Right.Right = new Tree()
            {
                Value = 16,
                Left = null,
                Right = null

            };

            obj.Right.Right.Right = new Tree()
            {
                Value = 21,
                Left = null,
                Right = null

            };

            obj.Left.Right = new Tree()
            {
                Value = 9,
                Left = null,
                Right = null
            };

            obj.Right.Left = new Tree()
            {
                Value = 12,
                Left = null,
                Right = null
            };

            Console.WriteLine("Height of tree is {0}", HeightOfTree(obj));
            bool balanced = IsBalanced(obj) ;
            Console.WriteLine("The tree {0}", balanced ==true ? "is Balanced" : "not balanced");
            Console.Read();
        }

        private static bool IsBalanced(Tree tree)
        {
            int lc =0, rc = 0;

            if (tree == null)
                return true;
            else
            {
                lc = HeightOfTree(tree.Left);
                rc = HeightOfTree(tree.Right);

                if (Math.Abs(lc - rc) <= 1)
                    return true;
                else
                    return false;
            }
        }

        private static int HeightOfTree(Tree tree)
        {
            int result = 0;
            if (tree == null)
                return 0;
            else
                return result = max(HeightOfTree(tree.Left),HeightOfTree(tree.Right)) +1;
        }

        private static int max(int a, int b)
        {            
            int returnValue = a  > b ? a : b;

            return returnValue;
        }
    }

    public class Tree
    {
        public int Value;
        public Tree Left;
        public Tree Right;
    }
}
