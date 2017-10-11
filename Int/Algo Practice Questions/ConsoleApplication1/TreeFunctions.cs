using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TreeFunctions
    {
        //Morris Travesal can be used to traverser a tree without stack and recursion
        //Vertical sum of a tree
        //Boundary Traversal
        //fing path such that its sum is M
        
        //Find Ceil and Floor values of BST (Ceil = min and Floor = max, which is left most and right most)
        //Distance between two nodes: Find the LCA for the nodes, and then trace hops from LCA to node1 and node2. Sum the hops. This is the distance between node1 and node2.
        public Tree mainTree { get; set; }
        public LinkList linkList { get; set; }

        public void Process()
        {
            printLevelOrder(mainTree);   
        }

        private bool mirrorEquals(Tree left, Tree right)
        {
            if (left == null || right == null) 
                return left == null && right == null;

            return left.Value == right.Value && 
                mirrorEquals(left.Left, right.Right) && 
                mirrorEquals(left.Right, right.Left);
        }

        #region Binary Search Tree
        private int KthSmallestNode(Tree tree, int k)
        {
            if (tree == null || k < 0) return -1;

            var x = KthSmallestNode(tree.Left, k);
            if (x != 0) return x;
            k--;

            if (k == 0)
                return tree.Value;

            var y = KthSmallestNode(tree.Right, k);
            return y;
        }

        public Tree InsertIntoBST(Tree tree, int value)
        {
            if (tree == null)
                return new Tree(value);

            if (tree.Value > value)
            {
                tree.Left = InsertIntoBST(tree.Left, value);
            }
            else
            {
                tree.Right = InsertIntoBST(tree.Right, value);
            }
            return tree;
        }

        public Tree DeleteBST(Tree tree, int value)
        {
            //Case1: Node is a leaf
            //Case2: Node has only one sub tree, i.e. right
            //Case3: Node has only one sub tree, i.e. left
            //Case4: Node has two sub tree, replace the root with the largest value of its left subtree (left subtree cannot have two subtrees)
            //Or use the minimum value of the right subtree

            if (tree == null) return null;

            if (value < tree.Value)
            {
                DeleteBST(tree.Left, value);
            }
            else if (value > tree.Value)
            {
                DeleteBST(tree.Right, value);
            }
            else
            {
                if (tree.Left == null && tree.Right == null) //Case1: No sub trees
                {
                    tree = null;
                }
                else if (tree.Left == null && tree.Right != null) //Case2: has only Right subtree
                {
                    var tmp = tree.Right;
                    tree = tmp;
                }
                else if (tree.Right == null && tree.Left != null) //Case3: Has only left sub tree
                {
                    var tmp = tree.Left;
                    tree = tmp;
                }
                else //Case4: Tree has two sub trees (max value of the left sub tree)
                {
                    var tmp = tree.Right;
                    Tree parent = null;
                    while (tmp.Left != null)
                    {
                        parent = tmp;
                        tmp = tmp.Left;
                    }
                    tree.Value = tmp.Value; //just replace the value, dont delete 
                    if (parent.Left != null)
                    {
                        DeleteBST(parent.Left, parent.Left.Value);
                    }
                    else
                    {
                        DeleteBST(parent.Right, parent.Right.Value);
                    }
                }
            }
            return tree;
        }

        private void MedianOfBST()
        {

        }

        private int MinNode(Tree tree)
        {
            var currentNode = tree;
            while (currentNode.Left != null)
            {
                MinNode(currentNode.Left);
            }
            return currentNode.Value;
        }

        #region Convert Binary Tree to BST
        private void ConvertBinaryTreeToBST()
        {
            //do a inorder traversal of binary tree
            //sort the array
            //again do a inorder traversal and copy the elements into the tree from the sorted array, since the structure is same

            InOrderTransversal(mainTree);
            var inOrder = _strInorder;

            inOrder.OrderBy(x => x); //Merge sort takes O(n log n)            
            ArrayToBST(inOrder.ToArray(), mainTree, 0);

        }

        private void ArrayToBST(int[] arr, Tree main, int index)
        {
            if (main != null)
            {
                //go to the left most node (inorder)
                ArrayToBST(arr, main.Left, index);

                //update the value of the root and increment the index,
                main.Value = arr[index];
                index++;

                //then go to the right
                ArrayToBST(arr, main.Right, index);
            }
        }
        #endregion

        //needs parent pointer
        private Tree LCAWithoutRecursion(Tree t, Tree node1, Tree node2)
        {
            /*
             * var h1 = node1.height;
             * var h2 = node2.height;
             * 
             * var d =  h2 - h1 //assume h2 is is bigger
             * 
             * for(int i = 0; i<=d; i++) node2 = node2.parent;
             * 
             * while(node1 != null && node2 != null){
             * if(node1 == node2) break; //this is the LCA
             *  node1 = node1.parent;
             *  node2 = node2.parent
             * } 
             */
            return null;

        }

        private void TreeFromPrePostTraversal()
        {
        }

        private void TwoPairWithSumM(Tree tree, int M)
        {
            var stack1 = new Stack<Tree>();
            int inValue = 0;
            var inOrderFalg = true;
            var node1 = tree;

            var stack2 = new Stack<Tree>();
            int revValue = 0;
            var reverseInOrderFlag = true;
            var node2 = tree;

            while (true)
            {
                //Inorder traversal
                while (inOrderFalg)
                {
                    if (node1 != null)
                    {
                        stack1.Push(node1);
                        node1 = node1.Left;
                    }
                    else
                    {
                        if (stack1.Count == 0) inOrderFalg = false;
                        else
                        {
                            node1 = stack1.Pop();
                            inValue = node1.Value;
                            node1 = node1.Right;
                            inOrderFalg = false;
                        }
                    }
                }

                //Reverse Inorder Traversal
                while (reverseInOrderFlag)
                {
                    if (node2 != null)
                    {
                        stack2.Push(node2);
                        node2 = node2.Right;
                    }
                    else
                    {
                        if (stack2.Count == 0) reverseInOrderFlag = false;
                        else
                        {
                            node2 = stack2.Pop();
                            revValue = node2.Value;
                            node2 = node2.Left;
                            reverseInOrderFlag = false;
                        }
                    }
                }

                if (inValue + revValue == M)
                {
                    Console.WriteLine("Fiund {0} and {1} = {2}", inValue, revValue, M);
                    break;
                }
                else if (inValue + revValue < M)
                {
                    inOrderFalg = true;
                }
                else if (inValue + revValue > M)
                {
                    reverseInOrderFlag = true;
                }
            }
        }

        #region Reverse Level Order
        private void ReverseLevelOrder()
        {
            Tree root = mainTree;
            int htTree = MaxTreeHeight(root);
            for (int i = htTree; i > 0; i--)
            {
                PrintGivenLevel(root, i);
            }
        }

        private void PrintGivenLevel(Tree root, int level)
        {
            if (root != null)
            {
                if (level == 1)
                {
                    Console.WriteLine(root.Value);
                }
                else if (level > 1)
                {
                    PrintGivenLevel(root.Left, level - 1);
                    PrintGivenLevel(root.Right, level - 1);
                }
            }
        }
        #endregion

        private void printLevelOrder(Tree root)
        {
            if (root == null) return;
            var queue = new Queue<Tree>();
            int currentLevel = 1;
            int nextLevel = 0;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Tree currNode = queue.Dequeue();
                currentLevel--;
                if (currNode != null)
                {
                    Console.Write(currNode.Value + ",");
                    queue.Enqueue(currNode.Left);
                    queue.Enqueue(currNode.Right);
                    nextLevel += 2;
                }
                if (currentLevel == 0)
                {
                    Console.WriteLine("");
                    currentLevel = nextLevel;
                    nextLevel = 0;
                }
            }
        }

        //LevelOrder = BFS, [InOrder, PostOrder, PreOrder = DFS]
        private void LevelOrederTransversal(Tree tree)
        {
            //6 3 9 1 4 8 10 5
            var queue = new Queue<Tree>();
            queue.Enqueue(tree);
            int previousLevel = 0;
            int currentLevel = 0;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if(currentLevel != previousLevel)
                { 
                    Console.WriteLine(node.Value);
                    previousLevel = currentLevel;
                }
                else
                {
                    Console.Write(node.Value);
                }
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
                currentLevel++;
            }
        }

        private Tree MergetTwoBST(Tree t1, Tree t2)
        {
            InOrderTransversal(t1);
            var inOrder1 = _strInorder; //O(log n)

            InOrderTransversal(t2);
            var inOrder2 = _strInorder; //O(log n)

            //Merge sort the array O(n log n)
            inOrder1.AddRange(inOrder2);
            var mergedSortedArray = inOrder1.OrderBy(x => x);

            //Take the mid point as root, all values before that are the left subtree and values after that are the right sub tree
            var tree = ArrayToBST(mergedSortedArray.ToArray(), 0, mergedSortedArray.Count());

            return tree;
        }

        //O(n)
        //IN-order Traversal
        public void BST_DynamicLinkList(Tree root, Tree prev, Tree head)
        {
            if (root != null)
            {
                if (root.Left != null)
                    BST_DynamicLinkList(root.Left, prev, head);

                root.Left = prev; //current node left points to previous node, back

                if (prev != null)
                    prev.Right = root; //previous node right points to current node
                else
                    head = root; //if prev node is not avaialble, that means its the start of the list and root is smallest

                //This points the head to last and the last to head (for the list to be circular)
                //Tree right = root.Right;
                //head.Left = root;
                //root.Right = head;

                prev = root;

                if (root.Right != null)
                    BST_DynamicLinkList(root.Right, prev, head);

            }
        }

        //O(n) - construct bottom to top
        //IN-order Traversal
        public Tree LinkListToBST(LinkList lst, int n)
        {
            if (n <= 0) return null;

            Tree leftChild = LinkListToBST(lst, n / 2);

            Tree parent = new Tree(lst.Value);
            parent.Left = leftChild;

            lst = lst.Next;

            Tree rightChild = LinkListToBST(lst, n - n / 2 - 1);
            parent.Right = rightChild;

            return parent;
        }

        //O(n)
        public Tree ArrayToBST(int[] arr, int start, int end)
        {
            if (start > end) return null;

            var mid = (start + end) / 2;
            Tree root = new Tree(arr[mid]);

            root.Left = ArrayToBST(arr, start, mid - 1);

            root.Right = ArrayToBST(arr, mid + 1, end);

            return root;
        }

        public bool IsBinaryTreeBST(Tree tree, int minValue, int maxValue)
        {
            if (tree == null) return true;

            if (tree.Value > minValue && tree.Value < maxValue)
            {
                var x = IsBinaryTreeBST(tree.Left, minValue, tree.Value);
                var y = IsBinaryTreeBST(tree.Right, tree.Value, maxValue);
                return x & y;
            }
            else return false;
        }

        public Tree _lca = null;
        public void LCA_BST(Tree tree, Tree node1, Tree node2)
        {
            if (tree == null) _lca = null;

            if (tree.Value > node1.Value && tree.Value > node2.Value)
            {
                //on left side
                LCA_BST(tree.Left, node1, node2);
            }
            else if (tree.Value < node1.Value && tree.Value < node2.Value)
            {
                //on right side
                LCA_BST(tree.Right, node1, node2);
            }
            else if (node1.Value < tree.Value && tree.Value < node2.Value)
            {
                _lca = tree;
            }
        }

        public List<int> _strInorder = new List<int>();
        public void InOrderTransversal(Tree node)
        {
            if (node.Left != null) InOrderTransversal(node.Left);
            _strInorder.Add(node.Value);
            if (node.Right != null) InOrderTransversal(node.Right);
        }

        public void InOrderStack(Tree node)
        {
            Stack<Tree> stack = new Stack<Tree>();
            var currentNode = node;
            while (currentNode != null)
            {
                while (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                    currentNode = currentNode.Left;
                }
                Console.WriteLine(currentNode.Value);
                while (currentNode.Right != null && stack.Count > 0)
                {
                    var tmp = stack.Pop();
                    Console.WriteLine(tmp.Value);
                }
                currentNode = currentNode.Right;
            }
        }

        #endregion

        #region Binary Tree
        //Another solution for this is, do a BFS and go to a node who has no child. The path from root to the first found node with no child is the shortest path.
        //The below solution does a full search to the tree, so more expensive.
        //enque(rootNode); while(queue.isNotEmpty) n=deque; if(n.right == null && n.left == null) this is it, else enque(n.left)enque(n.right)
        public int MinTreeHeight(Tree tree)
        {
            if (tree == null) return 0;
            return 1 + Math.Min(MinTreeHeight(tree.Left), MinTreeHeight(tree.Right));
        }

        public int MaxTreeHeight(Tree tree)
        {
            if (tree == null) return 0;
            return 1 + Math.Max(MaxTreeHeight(tree.Left), MaxTreeHeight(tree.Right));
        }

        private void TaverseZigZag(Tree tree)
        {
            //do a level order traversal with a flag, using 2 stacks
            var stack1 = new Stack<Tree>();
            var stack2 = new Stack<Tree>();
            var flag = false;
            stack1.Push(tree);
            while (stack1.Count > 0)
            {
                var node = stack1.Pop();
                if (node != null)
                {
                    Console.WriteLine(node.Value);
                    if (!flag)
                    {
                        stack2.Push(node.Left);
                        stack2.Push(node.Right);
                    }
                    else
                    {
                        stack2.Push(node.Right);
                        stack2.Push(node.Left);
                    }
                }
                if (stack1.Count == 0)
                {
                    flag = !flag;

                }
            }

        }

        private Tree MirrorBinaryTree(Tree t)
        {
            if (t == null) return null;

            var tree = new Tree(t.Value);
            tree.Right = MirrorBinaryTree(t.Left);
            tree.Left = MirrorBinaryTree(t.Right);

            return tree;
        }

        //find LCA of the two nodes, and the sum the distance from LCA to node1 and LCA to node2
        private void ShortestPathBetweenTwoNodes()
        {
        }

        //get the h1, h2 of botn nodes. Then h1-h2, move node1 up so that its in the same level as node2. Then move togetrher until theior parents are same.
        private Tree LCABinaryTree(Tree root, Tree node1, Tree node2)
        {
            if (root == null) return null;
            if (root.Value == node1.Value || root.Value == node2.Value) return root;

            var left = LCABinaryTree(root.Left, node1, node2);
            var right = LCABinaryTree(root.Right, node1, node2);

            if (left != null && right != null) return root;

            if (left != null) return left;
            else return right;
        }

        public void DFS_Graph(Tree t, Tree vertex)
        {
            //var stack = new Stack<Tree>();
            //stack.Push(vertex);
            //while (stack.Count > 0)
            //{
            //    var vertexNext = stack.Pop();
            //    vertexNext.Visisted = true;
            //    foreach (var adjVertex in AdjacentOf(vertexNext))
            //    {
            //        if (adjVertex.Visisted = false) stack.Push(adjVertex);
            //    }
            //}
        }

        //Max - Min <= 1, OK
        public void IsBinaryTreeBalanced()
        {
            if ((MaxTreeHeight(mainTree) - MinTreeHeight(mainTree)) <= 1)
                Console.WriteLine("Good");
            else
                Console.WriteLine("Bad");

        }

        public void Balance(Tree tree)
        {
        }
        #endregion

    }
}