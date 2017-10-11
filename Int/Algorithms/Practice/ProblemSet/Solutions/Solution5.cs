using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class Solution5
    {
        TreeNode Prev;

        public Solution5()
        {
            ConstructTree();
        }

        private void ConstructTree()
        {
            TreeNode root = new TreeNode()
            {
                Value = 9
            };

            TreeNode node1 = new TreeNode()
            {
                Value = 7
            };

            TreeNode node2 = new TreeNode()
            {
                Value = 14
            };

            TreeNode node3 = new TreeNode()
            {
                Value = 4
            };

            TreeNode node4 = new TreeNode()
            {
                Value = 16
            };

            TreeNode node5 = new TreeNode()
            {
                Value = 21
            };

            root.Left = node1;
            root.Right = node2;


            node1.Left = node3;
            node2.Right =node4;

            node4.Right = node5;

            TreeNode node = FindNode(root, 21);
            Console.WriteLine(node.Value.ToString());
            Console.Read();
        }

        public TreeNode FindNode(TreeNode root, int x)
        {
            TreeNode temp = null;

            if (root == null)
                return null;

            if (root.Value == x)
                return root;
            else if (x < root.Value)
            {
                temp = FindNode(root.Left, x);
                if (temp != null)
                {
                    if (temp.Value <= x)
                        if (Prev != null)
                        {
                            if (Prev.Value < temp.Value)
                                Prev = temp;
                        }
                        else
                            Prev = temp;
                }
            }
            else if (x > root.Value)
            {
                temp = FindNode(root.Right, x);
                if (temp != null)
                {
                    if (temp.Value <= x)
                        if (Prev != null)
                        {
                            if (Prev.Value < temp.Value)
                                Prev = temp;
                        }
                        else
                            Prev = temp;
                }
            }
            return root;
        }
    }   
}
