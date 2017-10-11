using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LinkList
    {
        public LinkList Next { get; set; }
        public LinkList Previous { get; set; }
        public int Value { get; set; }
        public LinkList(int value)
        {
            this.Value = value;
        }
    }

    public class Tree
    {
        public Tree Right { get; set; }
        public Tree Left { get; set; }
        public int Value { get; set; }
        public Tree(int value)
        {
            this.Value = value;
        }
    }

    public class Rectange
    {
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
