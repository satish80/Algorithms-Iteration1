using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    public class XMLParser
    {
        public XMLParser()
        {
            Console.WriteLine(Validate("<A>"+
                "<B>"+
                "</c>"+
                "</A>"));
        }

        public bool Validate(string inputXML)
        {
            string[] nodes = inputXML.Split(new char[]{'>'});
            Queue<string> queue = new Queue<string>();
            Stack<string> stck = new Stack<string>();
            bool Valid = true;

            foreach(string str in nodes)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    queue.Enqueue(str);
                    stck.Push(str);
                }
            }
            int count =0;
            while (count++ <= stck.Count /2)
            {
                string stkString = stck.Pop();
                string queueString = queue.Dequeue();

                if (stkString.Substring(stkString.IndexOf('/') + 1, stkString.Length-stkString.IndexOf('/')-1) !=
                    queueString.Substring(queueString.IndexOf('<') + 1, queueString.Length - queueString.IndexOf('<')-1))
                {
                    Valid = false;
                }                    
            }
            return Valid;
        }
    }
}
