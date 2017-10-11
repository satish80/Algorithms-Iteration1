using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunLengthCompression("This is a good day to begin");
            Blend obj = new Blend();
            //obj.DoBlend();
            //WildcardSearch search = new WildcardSearch();
            //Console.WriteLine(search.Process());
            //XMLParser obj = new XMLParser();
            Console.Read();
        }

        public static void RunLengthCompression(string input)
        {
            int count = 1;
            string output = string.Empty;
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (i < input.Length - 1 && input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    output += input[i].ToString() + count;
                    count = 1;
                }
            }
            Console.WriteLine(output);
        }
    }
}
