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
        List<int> list2 = new List<int>();
        Stack<int> bst = new Stack<int>(3);
        Queue<Tree> queue = new Queue<Tree>();
        public TreeManipulations()
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

            //InsertIntoBST(obj, 15);

            //PreOrderTraversal(obj);
            //for (int idx = 0; idx < list.Count; idx++)
            // {
            //     Console.WriteLine(list[idx]);
            // }

            // Console.Read();

        }

        public void CheckSumInBST()
        {
            InOrderTraversal(obj);
            ReverseInorder(obj);

            int idx1 = 0, idx2 = 0;
            int Sum = 22;
            while (idx1 < list.Count && idx2 < list2.Count)
            {
                if (list[idx1] + list2[idx2] < Sum)
                {
                    idx1++;
                }
                else if(list[idx1] + list2[idx2] > Sum)
                {
                    idx2--;
                }
                else
                {
                    Console.WriteLine("{0} + {1} = {2}", list[idx1],list2[idx2],Sum);
                    break;
                }
            }
        }

        public void DoInorderViaStack()
        {
            InorderViaStack(obj);
        }

        private void InorderViaStack(Tree tree)
        {
           // bool InorderFlg = true;
            Tree node = tree;
            Stack<Tree> stk = new Stack<Tree>();

            while (true)
            {
                if (node != null)
                {
                    stk.Push(node);
                    node = node.Left;
                }
                else
                {
                    if (stk.Count > 0)
                    {
                        node = stk.Pop();
                        Console.WriteLine(node.value.ToString());
                        //if (node.Right != null)
                        //{
                            node = node.Right;
                           
                       // }
                    }
                    else
                        break;
                }
            }
        }

        public void DoReverseInorderTraversal()
        {
            ReverseInorder(obj);

            for (int idx = 0; idx < list2.Count; idx++)
            {
                Console.WriteLine(list2[idx]);
            }
        }

        private void ReverseInorder(Tree tree)
        {
            if (tree == null)
                return;

            else
            {
                ReverseInorder(tree.Right);
                list2.Add(tree.value);
                ReverseInorder(tree.Left);
            }
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
                return Math.Max(HeightOfTree(obj.Left), HeightOfTree(obj.Right)) + 1;
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
            bool IsBst = true;
            CheckTreeBST(obj, ref IsBst);
            Console.WriteLine("BST prop of Tree is {0}", IsBst);
            Console.Read();
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
        

         
    }

   
}
