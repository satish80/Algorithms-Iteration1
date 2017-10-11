using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    public class LongestCommonSubstring
    {
        public void CountOfLongestCommonSubstring()
        {
            char[] first = {'g','e','e','k','s','f','o','r','g','e','e','k','s'};
            char[] second = {'g','e','e','k','s','q','u','i','z'};
            int LCSCount = 0;
            if (first.Length < second.Length)
                LCSCount = ReturnLongestCommonSubstring(first, second);
            else
                LCSCount = ReturnLongestCommonSubstring(second, first);

            Console.WriteLine("LCS count " + LCSCount);
            Console.Read();

        }

        private int ReturnLongestCommonSubstring(char[] first, char[] second)
        {
            int LCSCount = 0;
            int prevLCSCount = 0;

            for (int smallIdx = 0; smallIdx < first.Length; smallIdx++)
            {
                for (int bigIdx = 0; bigIdx < second.Length; bigIdx++)
                {
                    if(first[smallIdx] == second[bigIdx])
                    {
                        LCSCount = 0;
                        int sCurrent = smallIdx;
                        int bCurrent = bigIdx;
                        
                        while(first[sCurrent] == second[bCurrent])
                        {
                            LCSCount++;
                            if (sCurrent < first.Length-1 && bCurrent < second.Length-1)
                            {
                                sCurrent++;
                                bCurrent++;
                            }
                            else
                                break;
                        }

                        if(LCSCount > prevLCSCount)
                            prevLCSCount = LCSCount;                        
                    }
                }
            }

            return prevLCSCount;
        }
    }
}
