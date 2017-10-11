using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPatternMatch
{
    public class Tries
    {

        private TrieNode root = new TrieNode();

        public TrieNode Insert(string s)
        {

            char[] charArray = s.ToLower().ToCharArray();

            TrieNode node = root;

            foreach (char c in charArray)
            {
                node = Insert(c, node);
            }

            node.isEnd = true;

            return root;
        }

        private TrieNode Insert(char c, TrieNode node)
        {
            if (node.Contains(c)) 
                return node.GetChild(c);
            else
            {
                int n = Convert.ToByte(c) - TrieNode.ASCIIA;

                TrieNode t = new TrieNode();

                node.nodes[n] = t;

                return t;
            }
        }

        public bool Contains(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;

            bool contains = true;

            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    contains = false;
                    break;
                }
            }

            if ((node == null) || (!node.isEnd))

                contains = false;

            return contains;
        }



        private TrieNode Contains(char c, TrieNode node)
        {
            if (node.Contains(c))
            {
                return node.GetChild(c);
            }
            else
            {
                return null;
            }
        }
    }

    public class TrieNode
    {
        public TrieNode[] nodes;

        public bool isEnd = false;

        public const int ASCIIA = 97;

        public TrieNode()
        {
            nodes = new TrieNode[26];
        }

        public bool Contains(char c)
        {
            int n = Convert.ToByte(c) - ASCIIA;

            if (n < 26)
                return (nodes[n] != null);
            else
                return false;
        }

        public TrieNode GetChild(char c)
        {
            int n = Convert.ToByte(c) - ASCIIA;
            return nodes[n];
        }
    }
}
