using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeManipulations obj = new TreeManipulations();
            //obj.CalcTreeHeight();
            //obj.IsTreeBST();
            //obj.DoLevelOrderTraversal();
            //obj.DoPreOrderTraversal();
            //obj.DoReverseLevelOrderTraversal();
            //obj.DoInorderTraversal();
            //obj.DoPostOrderTraversal();
            //obj.DoReverseInorder();
            //obj.DoClosestLeafNodeTraversal();
            //obj.DoMirrorTree();
            //obj.DoSumOfLeftLeafNodes();
            //obj.DoinorderSpiral();
            //obj.ReverseTree();

            // obj.FindAncestors();
            // SearchTree obj = new SearchTree();
            //Console.WriteLine(obj.Find(obj.Root,14).value);


            //obj.DoPostOrderTraversal();
            Console.Read();

            #region ArrayToBST
            int[] arr = new int[] { 1,2,3,4,5};
            Tree tree = obj.ArrayToBST(arr,0,4);
            #endregion

            #region IsTreeBST
            //obj.IsTreeBST();
            #endregion
        }
    }

    public class Tree
    {
        public Tree Left;
        public Tree Right;
        public int value;
    }
}
