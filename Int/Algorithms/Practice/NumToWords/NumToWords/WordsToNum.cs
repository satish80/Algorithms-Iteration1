using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToWords
{
    public class WordsToNum
    {
        public void Print()
        {
            string word = "1234";
            char[] wordArr = word.ToCharArray();
            int count = wordArr.Length-1;
            int value = 0;
            int res = 0;
            int digit = 1;

            while (count >= 0 )
            {
                res = (int)wordArr[count] - 48;
                if (count != wordArr.Length - 1)
                    res = res * digit;

                value += res;
                count--;
                digit = digit * 10;
            }
            Console.WriteLine(value.ToString());
            Console.Read();
        }
    }
}
