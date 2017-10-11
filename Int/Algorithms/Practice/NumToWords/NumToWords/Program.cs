using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintWords(6717);
            PrintWordsToNum();
        }

        private static void PrintWordsToNum()
        {
            WordsToNum obj = new WordsToNum();
            obj.Print();
        }

        public static void  PrintWords(int num)
        {
            Stack<int> stk = new Stack<int>();

            while (num > 1)
            {
                stk.Push(num % 10);
                num = num / 10;
            }
            Console.WriteLine(ReturnWords(stk));
            Console.Read();
        }

        private static string ReturnWords(Stack<int> stk)
        {
            string digit = string.Empty;
            StringBuilder suffix = new StringBuilder();
            Dictionary<int,string> dict = new Dictionary<int,string>();
            dict.Add(1,"One");
            dict.Add(2,"Two");
            dict.Add(3,"Three");
            dict.Add(4,"Four");
            dict.Add(5,"Five");
            dict.Add(6,"Six");
            dict.Add(7,"Seven");
            dict.Add(8,"Eight");
            dict.Add(9,"Nine");
            dict.Add(10,"Ten");
            dict.Add(11,"Eleven");
            dict.Add(12,"Twelve");
            dict.Add(13,"Thirteen");
            dict.Add(14,"Fourteen");
            dict.Add(15,"Fifteen");
            dict.Add(16,"Sixteen");
            dict.Add(17,"Seventeen");
            dict.Add(18,"Eighteen");
            dict.Add(19,"Nineteen");
            dict.Add(20,"Twenty");
            dict.Add(30,"Thirty");
            dict.Add(40,"Forty");
            dict.Add(50,"Fifty");
            dict.Add(60,"Sixty");
            dict.Add(70,"Seventy");
            dict.Add(80,"Eighty");
            dict.Add(90,"Ninety");

            StringBuilder  str = new StringBuilder();
            Dictionary<int,string> position = new Dictionary<int,string>();
            position.Add(3,"Hundred");
            position.Add(4,"Thousand");

            while (stk.Count!=0)
            {
                if(stk.Count>=3)
                {
                    digit = position[stk.Count];
                    int pos = stk.Pop();
                    str.Append(dict[pos] + " " + digit);
                }
                else
                {
                    if(stk.Count == 2)
                    {
                        int secondPlace =stk.Pop();
                        if(secondPlace != 1)
                        {
                            
                            suffix.Append(dict[secondPlace *10]);
                            suffix.Append( dict[stk.Pop()]);
                        }
                        else
                        {
                            suffix.Append(dict[secondPlace * 10 + stk.Pop()]);

                        }
                    }
                }
            }

            return str + " and " + suffix;
        }
    }
}
