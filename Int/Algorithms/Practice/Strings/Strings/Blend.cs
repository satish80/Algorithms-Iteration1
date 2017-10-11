using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Blend
    {
        public Blend()
        {
            string[] str = new string[]{"abcd","def", "hjk"};

            Console.WriteLine(DoBlend(str));
        }

        public string DoBlend(string[] input)
        {
            List<char[]> chrArray = new  List<char[]>();
            int LongLength = 0;

            foreach (string str in input)
            {
                if (str.Length > LongLength)
                    LongLength = str.Length;
                chrArray.Add(str.ToCharArray());
            }

            StringBuilder sb = new StringBuilder(); 

            for (int idx = 0; idx < LongLength; idx++)
            {
                foreach (char[] arr in chrArray)
                {
                    if((idx < arr.Length))
                        sb.Append(arr[idx]);
                }
            }

            return sb.ToString();
        }
    }
}
