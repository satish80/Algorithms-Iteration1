using System;

public class LongestPalindromicSubstring
{
    string _theGivenString;

    public LongestPalindromicSubstring(string theGivenString)
    {
        _theGivenString = theGivenString;
    }

    public string ReturnLongestPalindromicSubString()
    {
        int Start = 0;
        int end = 0;
        string longestPalindrome;
        char[] theGivenArray = _theGivenString.ToCharArray();
        bool[,] table = new bool[_theGivenString.Length, _theGivenString.Length];
        int count=0;
        int[] pos = new int[_theGivenString.Length - 1];
        //for (int i = 0; i < _theGivenString.Length; ++i)
        //    table[i,i] = true;


        //for (int i = 0; i < _theGivenString.Length - 1; ++i)
        //{
        //    if (theGivenArray[i] == theGivenArray[i + 1])
        //    {
        //        table[i,i + 1] = true;
               
        //    }
        //}
        
        for (int substrDigit = _theGivenString.Length-1; substrDigit >= 0; substrDigit--)
        {
            for (int traversePointer = 0; traversePointer < substrDigit; traversePointer++)
            {
                if (theGivenArray[traversePointer] == theGivenArray[substrDigit] && 
                    theGivenArray[traversePointer + 1] == theGivenArray[substrDigit - 1])
                {
                    if (Start == 0 && end ==0)
                    {
                        Start = traversePointer;
                        end = substrDigit;
                    }

                    if (substrDigit - traversePointer == 1)
                        break;

                        substrDigit--;                        
                }                
            }           
        }

        for (int i = Start; i <= end; i++)
        {
            Console.Write(theGivenArray[i]);
           
        }

        return  " ";
    }
}