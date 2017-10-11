using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPatternMatch
{
    public class Trie
    {
        Node root;
        public void BuildTrie()
        {
            Console.WriteLine("Enter the Input text");
            string inputText = Console.ReadLine();
            string[] inputArr = inputText.Split(' ');

            root = new Node();

            for (int idx = 0; idx < inputArr.Length; idx++)
            {
                foreach (string inputStr in inputArr)
                {
                    char[] arr = inputStr.ToCharArray();
                    ConstructTrie(inputArr, new Node(), arr);
                }
            }
        }

        public void ConstructTrie(string[] inputArr, Node node, char[] arr)
        {
            for (int idx = 0; idx < arr.Length; idx++ )
            {
                Node value = new Node()
                {
                    Value = arr[idx]
                };

                if (idx == 0)
                {
                    if (!root.Child.Contains(value))
                    {
                        root.Child.Add(value);
                    }
                }
                else
                {
                    Node parent = root;
                    AddChildNodes(arr, value, 1);
                }
            }
        }

        private Node AddChildNodes(char[] arr, Node node, int index)
        {
            Node child;
            Node returnValue = null;
            for (int idx = index; idx < arr.Length; idx++)
            {
                child = new Node()
                {
                    Value = arr[idx]
                };
                node.Child.Add(child);
                returnValue = AddChildNodes(arr, child, idx);
            }
            return returnValue;
        }

        //public bool SearchTrie(Node node, char[] pattern)
        //{

        //}
    }

    public class Node
    {
        public char Value;

        public List<Node> Siblings = new List<Node>();

        public List<Node> Child = new List<Node>();
    }
}
