using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    public class TreeManipulations
    {
        Tree obj;
        List<int> list = new List<int>();
        Stack<int> bst = new Stack<int>(3);
        Queue<Tree> queue = new Queue<Tree>();
        bool IsBst = true;
        Stack<Tree> stk = new Stack<Tree>();

        public TreeManipulations()
        {
            obj = new Tree();
            obj.value = 10;

            obj.Left = new Tree()
            {
                value = 9
            };
            obj.Right = new Tree()
            {
                value = 49
            };

            obj.Left.Left = new Tree()
            {
                value = 5,
                Left = null,
                Right = null
            };

            obj.Right.Right = new Tree()
            {
                value = 52,
                Left = null,
                Right = null

            };

            obj.Left.Right = new Tree()
            {
                value = 12,
                Left = null,
                Right = null
            };

            obj.Right.Left = new Tree()
            {
                value = 23,
                Left = null,
                Right = null
            };

            obj.Left.Right.Right = new Tree()
            {
                value = 15,
                Left = null,
                Right = null
            };
            obj.Right.Right.Left = new Tree()
            {
                value = 50,
                Left = null,
                Right = null
            };
            obj.Left.Left.Left = new Tree()
            {
                value = 4,
                Left = null,
                Right = null
            };
            obj.Left.Left.Right= new Tree()
            {
                value = 6,
                Left = null,
                Right = null
            };
            obj.Left.Right.Left = new Tree()
            {
                value = 11,
                Left = null,
                Right = null
            };
            //InsertIntoBST(obj, 15);

            //PreOrderTraversal(obj);
            //for (int idx = 0; idx < list.Count; idx++)
            // {
            //     Console.WriteLine(list[idx]);
            // }

            // Console.Read();

        }

        public void CalcTreeHeight()
        {
            Console.WriteLine("Height of tree is {0}", HeightOfTree(obj));
            Console.Read();
        }

        public void DoLevelOrderTraversal()
        {
            LevelOrderTraversal(obj);
        }

        public void DoReverseLevelOrderTraversal()
        {
            ReverseLevelOrder();
        }

        public void DoPreOrderTraversal()
        {
            PreOrderTraversal(obj);

            for (int idx = 0; idx < list.Count; idx++)
            {
                Console.WriteLine(list[idx]);
            }
            Console.Read();
        }

        public void DoPostOrderTraversal()
        {
            PostOrderTraversal(obj);

            for (int idx = 0; idx < list.Count; idx++)
            {
                Console.WriteLine(list[idx]);
            }
            Console.Read();

        }

        public void DoReverseInorder()
        {
            ReverseInorderTraversal(obj);
            for (int idx = 0; idx < list.Count; idx++)
            {
                Console.WriteLine(list[idx]);
            }
            Console.Read();
        }
        public void DoInorderTraversal()
        {
            InOrderTraversal(obj);

            for (int idx = 0; idx < list.Count; idx++)
            {
                Console.WriteLine(list[idx]);
            }
            Console.Read();
        }

        public void DoinorderSpiral()
        {
            bool ltr = false;
            for (int idx = 0; idx <3; idx++)
            {
                InorderSpiral(obj, idx,ltr);
                ltr = !ltr;
            }
        }

        public void DoSumOfLeftLeafNodes()
        {
            SumOfLeftLeafNodes(obj, false);
            int sum = 0;
            for(int i=0;i< list.Count; i++)
            {
                sum += list[i];
                
            }
            Console.WriteLine("sum " +  sum.ToString());
        }

        private void SumOfLeftLeafNodes(Tree tree, bool right)
        {
            if (tree == null)
                return;

            if (tree.Left == null && !right)
            {
                list.Add(tree.value);
            }
            else
            {
                SumOfLeftLeafNodes(tree.Left, false);
                SumOfLeftLeafNodes(tree.Right, true);
            }
        }

        private void InorderSpiral(Tree tree, int level, bool LTR)
        {
            if (tree == null)
                return;

            if (level == 0)
            {
                Console.WriteLine(tree.value.ToString());
            }
            else if (level > 0)
            {
                if (LTR)
                {
                    InorderSpiral(tree.Left, level - 1, LTR);
                    InorderSpiral(tree.Right, level - 1, LTR);
                }
                else
                {
                    InorderSpiral(tree.Right, level - 1, LTR);
                    InorderSpiral(tree.Left, level - 1, LTR);
                }
            }
        }

        public void InOrderTraversal(Tree tree)
        {
            if (tree.Left != null)
                InOrderTraversal(tree.Left);

            list.Add(tree.value);

            if (tree.Right != null)
                InOrderTraversal(tree.Right);
        }

        public void PreOrderTraversal(Tree tree)
        {
            list.Add(tree.value);

            if (tree.Left != null)
                PreOrderTraversal(tree.Left);

            if (tree.Right != null)
                PreOrderTraversal(tree.Right);
        }

        public void PostOrderTraversal(Tree tree)
        {
            if (tree.Left != null)
                PostOrderTraversal(tree.Left);

            if (tree.Right != null)
                PostOrderTraversal(tree.Right);

            list.Add(tree.value);
        }

        public void ReverseInorderTraversal(Tree tree)
        {
            if (tree == null)
                return;

            if (tree.Right != null)
                ReverseInorderTraversal(tree.Right);

            list.Add(tree.value);

            if (tree.Left != null)
                ReverseInorderTraversal(tree.Left);

        }

        public void DoClosestLeafNodeTraversal()
        {
            int shortestDistance = -1;
            int latestLeafDistance = -1;
            int currentDistance = 0;
            ClosestLeafNodeTraversal(obj, ref shortestDistance, ref latestLeafDistance,  currentDistance, 49);
            Console.WriteLine("shortestDistance is " + (shortestDistance).ToString());
        }

        public void ClosestLeafNodeTraversal(Tree tree, ref int shortestDistance, ref int latestLeafDistance,  int currentDistance, int desiredNode)
        {
            if(tree.Left == null && tree.Right == null)
            {
                if (currentDistance < latestLeafDistance)
                {
                    latestLeafDistance = currentDistance;
                }

                if (latestLeafDistance < shortestDistance || shortestDistance == -1)
                {
                    latestLeafDistance = currentDistance;
                    shortestDistance = latestLeafDistance;
                }
                return;
            }

            currentDistance++;

            if (tree.value == desiredNode)
            {
                currentDistance = 0;
                if (tree.Left == null && tree.Right == null)
                {
                    latestLeafDistance = currentDistance + latestLeafDistance;
                }
                else
                {
                    currentDistance++;
                }
            }

            if (tree.Left != null)
            {   
                ClosestLeafNodeTraversal(tree.Left, ref shortestDistance, ref latestLeafDistance,  currentDistance, desiredNode);                
            }

            if (tree.Right != null)
            {
                ClosestLeafNodeTraversal(tree.Right, ref shortestDistance, ref latestLeafDistance,  currentDistance, desiredNode);                
            }
        }

        public void InsertIntoBST(Tree tree, int value)
        {
            if (tree.value > value && tree.Left != null)
                InsertIntoBST(tree.Left, value);

            else if (tree.value < value && tree.Right != null)
                InsertIntoBST(tree.Right, value);
            else
            {
                Tree tempNode = new Tree();
                if (tempNode.value > value)
                {
                    tempNode.Right = tree.Right;
                    tempNode.Left = tree.Left;
                    tempNode.value = tree.value;
                    tree.value = value;
                    tree.Left = tempNode;
                }
                else
                {
                    tempNode.Right = tree.Right;
                    tempNode.Left = tree.Left;
                    tempNode.value = tree.value;
                    tree.value = value;
                    tree.Right = tempNode;
                }
            }
        }

        private int HeightOfTree(Tree obj)
        {
            if (obj == null)
                return 0;
            else
            {
                int ret = Math.Max(HeightOfTree(obj.Left), HeightOfTree(obj.Right)) + 1;
                return ret;
            }
        }

        private void LevelOrderTraversal(Tree tree)
        {
            Queue<Tree> queue = new Queue<Tree>();

            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree node = queue.Dequeue();
                Console.WriteLine(node.value);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        private void ReverseLevelOrder()
        {
            Tree root = obj;
            int htTree = MaxTreeHeight(root);
            for (int i = htTree; i > 0; i--)
            {
                PrintGivenLevel(root, i);
            }
        }

        public int MaxTreeHeight(Tree tree)
        {
            if (tree == null) return 0;
            return 1 + Math.Max(MaxTreeHeight(tree.Left), MaxTreeHeight(tree.Right));
        }

        private void PrintGivenLevel(Tree root, int level)
        {
            if (root != null)
            {
                if (level == 1)
                {
                    Console.WriteLine(root.value);
                }
                else if (level > 1)
                {
                    PrintGivenLevel(root.Left, level - 1);
                    PrintGivenLevel(root.Right, level - 1);
                }
            }
        }

        private void ReverseLevelOrderTraversal(Tree tree)
        {
            if (tree == null)
            {
                return;
            }

            ReverseLevelOrderTraversal(tree.Left);
            ReverseLevelOrderTraversal(tree.Right);
        }

        public Tree ArrayToBST(int[] arr, int start, int end)
        {
            if (start > end) return null;

            var mid = (start + end) / 2;
            Tree root = new Tree()
                {
                    value = arr[mid]
                };

            root.Left = ArrayToBST(arr, start, mid - 1);

            root.Right = ArrayToBST(arr, mid + 1, end);

            return root;
        }

        public void IsTreeBST()
        {
            //bool IsBst = true;
            //CheckTreeBST(obj, ref IsBst);
            CheckBSTRecursively(obj);
            Console.WriteLine("BST prop of Tree is {0}", IsBst);
            Console.Read();
        }

        private int CheckBSTRecursively(Tree tree)
        {
            if (tree == null)
                return 0;

            if(CheckBSTRecursively(tree.Left) > CheckBSTRecursively(tree.Right) && IsBst)
                IsBst = false;

            return tree.value;
        }

        private Tree CheckTreeBST(Tree tree, ref bool IsBst)
        {
            int Left = 0, Right = 0, Parent = 0;

            if (bst.Count != 3)
            {
                if (tree == null)
                    return null;

                CheckTreeBST(tree.Left, ref IsBst);

                bst.Push(tree.value);

                CheckTreeBST(tree.Right, ref IsBst);
            }
            else
            {
                Right = bst.Pop();
                Parent = bst.Pop();
                Left = bst.Pop();

                if (!(Right > Parent) || !(Parent > Left))
                    IsBst = false;
            }
            return tree;
        }

        public void DoMirrorTree()
        {
            Tree t = MirrorBinaryTree(obj);
            InOrderTraversal(t);
        }

        private Tree MirrorBinaryTree(Tree t)
        {
            if (t == null) return null;

            var tree = new Tree()
            {
                value = t.value
            };
            tree.Right = MirrorBinaryTree(t.Left);
            tree.Left = MirrorBinaryTree(t.Right);

            return tree;
        }

        public void ReverseTree()
        {
            List<Tree> list = new List<Tree>();
            Tree trees= RecurseTree(obj, list);

            foreach(Tree tree in list)
            {
                Console.WriteLine(tree.value);
            }
        }

        private Tree RecurseTree(Tree tree, List<Tree> list)
        {
            if (tree == null)
                return null;

            Tree left = RecurseTree(tree.Left, list);
            Tree right = RecurseTree(tree.Right, list);

            if (left != null)
                left.Right = tree;

            if (right != null)
                right.Left = tree;

            if (left == null && right == null)
                list.Add(tree);

            return tree;
        }

        public void FindAncestors()
        {
            //Stack<Tree> stack = ReturnAncestors(obj,16);
            ReturnAncestorsRecursively(obj, 16);

            while(stk.Count >0)
            {
                Tree tree = stk.Pop();
                Console.WriteLine(tree.value);
            }
            Console.Read();
        }

        private Stack<Tree> ReturnAncestorsRecursively(Tree tree, int desiredValue)
        {
            if (tree.value == desiredValue)
                return null;

            else if (desiredValue < tree.value)
            {
                ReturnAncestorsRecursively(tree.Left, desiredValue);
                stk.Push(tree);
            }
            else
            {
                ReturnAncestorsRecursively(tree.Right, desiredValue);
                stk.Push(tree);
            }
            return stk;
        }

        private Stack<Tree> ReturnAncestors(Tree tree, int value)
        {
            Stack<Tree> ancestors = new Stack<Tree>();

            while(tree != null)
            {
                ancestors.Push(tree);

                if (value < tree.value)
                {                    
                    tree = tree.Left;
                }
                else
                {
                    tree = tree.Right;
                }

            }
            return ancestors;
        }
    }
}
