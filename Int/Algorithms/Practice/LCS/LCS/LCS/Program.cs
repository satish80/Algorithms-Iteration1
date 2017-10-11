using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestCommonSubstring obj = new LongestCommonSubstring();
            //obj.CountOfLongestCommonSubstring();

            #region LCSDP
            LCSDP obj = new LCSDP();
            obj.FindLCSViaDP();
            #endregion 
            #region LCS

            //char[] arr1 = new char[] { 'A', 'G', 'G', 'T', 'A', 'B' };
            //char[] arr2 = new char[] { 'G', 'X', 'T', 'X', 'A', 'Y', 'B' };
            //LCS(arr1, arr2, 6, 7);
            //Console.Read();
            #endregion LCS

            #region PalindromicSubstring

           // LongestPalindromicSubstring palindromicSubstring = new LongestPalindromicSubstring("Malayalamoreeksskeefo");
           //// Console.WriteLine("the longest palindromic substring is {0} ",palindromicSubstring.ReturnLongestPalindromicSubString());
           // palindromicSubstring.ReturnLongestPalindromicSubString();
            Console.Read();

            #endregion PalindromicSubstring
        }

        private static void LCS(char[] arr1, char[] arr2, int arr1Len, int arr2Len)
        {

            int[,] lcsCount = new int[arr1Len+1,arr2Len+1];

            for (int arr1Idx = 0; arr1Idx <= arr1Len ; arr1Idx++)
            {
                for (int arr2Idx = 0; arr2Idx <= arr2Len; arr2Idx++)
                {
                    if(arr1Idx == 0 || arr2Idx ==0)
                        lcsCount[arr1Idx,arr2Idx]=0;

                    else if(arr1[arr1Idx-1] == arr2[arr2Idx-1])
                        lcsCount[arr1Idx,arr2Idx] = lcsCount[arr1Idx-1,arr2Idx-1] +1;
                    else 
                    {
                        lcsCount[arr1Idx,arr2Idx] = (lcsCount[arr1Idx-1,arr2Idx] > lcsCount[arr1Idx,arr2Idx-1] ) ? lcsCount[arr1Idx-1,arr2Idx] : lcsCount[arr1Idx,arr2Idx-1];
                    }
                }
            }

            Console.WriteLine("LCS count is {0}", lcsCount[arr1Len,arr2Len].ToString());
        }
    }
}
