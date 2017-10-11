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
            //obj.DoLevelOrderTraversal();
            //obj.DoPreOrderTraversal();
            //obj.DoReverseLevelOrderTraversal();
            //obj.DoInorderTraversal();
            //obj.DoMirrorTree();
            //obj.DoinorderSpiral();
            //obj.DoPostOrderTraversal();
           //obj.DoReverseInorderTraversal();

            #region ArrayToBST
            //int[] arr = new int[] { 1,2,3,4,5};
            //Tree tree = obj.ArrayToBST(arr,0,4);
            #endregion

            #region IsTreeBST
            //obj.IsTreeBST();
            #endregion
            //obj.DoInorderViaStack();
            //obj.CheckSumInBST();
            Console.Read();
        }
    }

    public class Tree
    {
        public Tree Left;
        public Tree Right;
        public int value;
    }
}
