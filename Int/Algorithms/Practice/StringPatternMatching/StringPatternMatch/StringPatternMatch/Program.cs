using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StringPatternMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Bayer Moore pattern match
            //Console.WriteLine("Enter Text ");
            //char[] inputText = Console.ReadLine().ToCharArray();

            //Console.WriteLine("Enter pattern ");
            //string pattern = Console.ReadLine();

            //foreach (KeyValuePair<char, int> patternPos in FillDisposition(pattern))
            //{
            //    Console.WriteLine("Disposition List {0} {1}", patternPos.Key, patternPos.Value);
            //}

           // Console.WriteLine("Pattern matched at position {0} ", PatternMatch(FillDisposition(pattern), inputText, pattern.ToCharArray()));

            //#endregion

            // #region Tries
            Tries obj = new Tries();
            obj.Insert("cat");
            obj.Insert("mat");
           // Console.WriteLine(obj.Contains("mat"));

            // #endregion
            // AtoI obj = new AtoI();
            //obj.DisplayAtoI();
            Console.Read();
        }

        private static int PatternMatch(IDictionary<char,int> dpList,char[] inputText, char[] pattern)
        {
            bool? patternFound = null;

            int inputPtr = pattern.Length-1;
            for (int idx = pattern.Length-1; idx >= 0; idx--)
            {
                if (!(pattern[idx] == inputText[inputPtr]))
                {
                    patternFound = false;
                    if (dpList.ContainsKey(inputText[inputPtr]))
                    {
                        inputPtr += dpList[inputText[inputPtr]];
                        idx = pattern.Length;
                    }
                    else
                    {
                        inputPtr += dpList['?'];
                        idx = pattern.Length;
                    }
                }
                else
                {
                    inputPtr --;                       
                    patternFound = null;
                }               

                if (idx == 0 && patternFound == null)
                    patternFound = true;
            }

            return inputPtr +1;
        }

        private static IDictionary<char, int> FillDisposition(string pattern)
        {
            IDictionary<char, int> dpList = new Dictionary<char, int>();
            dpList.Add('?', pattern.Length);

            char[] patternArray = pattern.ToCharArray();

            for (int patternIdx = 0; patternIdx < pattern.Length ; patternIdx++)
            {
                if (!patternArray.Contains(patternArray[patternIdx]))
                    dpList.Add(patternArray[patternIdx], pattern.Length - patternIdx - 1);
                else
                    dpList[patternArray[patternIdx]] = pattern.Length - patternIdx - 1;
            }

            return dpList;
        }
    }
}
