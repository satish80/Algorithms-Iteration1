using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    public class SearchTree
    {

        Tree Successor = null;
        Tree BaseRoot = null;
        Tree obj = null;
        bool baseValueMatch = false;

        public Tree Root
        {
            get
            {
                return obj;
            }
        }
        public SearchTree()
        {
            obj = new Tree();
            obj.value = 10;

            obj.Left = new Tree()
            {
                value = 8
            };
            obj.Right = new Tree()
            {
                value = 14
            };

            obj.Left.Left = new Tree()
            {
                value = 6,
                Left = null,
                Right = null
            };

            obj.Right.Right = new Tree()
            {
                value = 16,
                Left = null,
                Right = null

            };

            obj.Left.Right = new Tree()
            {
                value = 9,
                Left = null,
                Right = null
            };

            obj.Right.Left = new Tree()
            {
                value = 12,
                Left = null,
                Right = null
            };
        }

        public Tree Find(Tree root, int target)
        {
            Tree Right = null;
            Tree Left = null;
            Tree baseNode = null;

            if (BaseRoot == null)
                BaseRoot = root;

            if (target == BaseRoot.value)
            {
                baseValueMatch = true;                
                baseNode = Find(root.Right, root.Right.value - 1);
            }
            else
            {
                if (baseValueMatch)
                    target = root.value - 1;

                if (target > root.value)
                {
                    if (root.Right != null)
                        Right = Find(root.Right, target);
                    else
                        return Successor = Right;
                }
                else if (target < root.value)
                {
                    if (root.Left != null)
                        Left = Find(root.Left, target);
                    else
                        return Successor = root;
                }
                else if (root.value == target)
                    return root;

                if (Successor != null)
                    return Successor;
                else
                {
                    if (Right != null)
                    {
                        if (Right.Left.value == target)
                        {
                            Successor = Right;
                        }
                        else if (Right.value == target)
                        {
                            Successor = Right.Right;
                        }
                        else if (Right == BaseRoot)
                        {
                            Successor = BaseRoot;
                        }

                        return Successor;
                    }
                    else if (Left != null)
                    {
                        if (Successor == null && Left.value == target)
                        {
                            if (Left.Right != null)
                                Successor = Left.Right;
                            else
                                return Successor = root;
                        }
                        return Successor;
                    }
                    else
                        return root;
                }
            }
            return Successor;
        }
    }
}
