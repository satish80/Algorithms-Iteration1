using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MedianOfSortedArray
    {
        public void CalcMedian()
        {
            int[] first = new[] { 1,4,7,8, 18, 20};
            int[] second = new[] { 2,3,5,6, 12, 15};

            //Console.WriteLine(Median(first,second));

            Console.WriteLine(MedianLogMPlusN(first, second,0,first.Length -1, 0, second.Length -1));
            Console.Read();
        }

        private int Median(int[] first, int[] second)
        {
            int small = 0;
            int big = 0;
            int[] mergedArr = new int[8];
            int idx = 0, count =0;
            bool smallBounds = false, bigBounds = false;
            while (count < 8)
            {
                if (first[small] > second[big] && !bigBounds)
                {   
                    mergedArr[idx++] = second[big];
                    count++;

                    if (big < second.Length - 1)
                        big++;
                    else
                        bigBounds = true;
                }
                else
                {
                    if (small <= first.Length - 1 && !smallBounds )
                    {
                        mergedArr[idx++] = first[small];
                        count++;

                        if (small < first.Length - 1)
                            small++;
                        else
                            smallBounds=true;

                    }                   
                }
                
            }
            return mergedArr[4];
        }

        private int MedianLogMPlusN(int[] first, int[] second, int start1, int end1, int start2, int end2)
        {
            int mid1 = (start1 + end1) / 2;
            int mid2 = (start2 + end2) / 2;

            if (first[mid1] == second[mid2])
                return first[mid1];

            if(first[mid1] < second[mid2])
            {
                int q1 = (first.Length - mid1 -1);
                start1 += q1 %2 == 0 || q1 %2 == 0.5 ? q1 /2 : (q1 / 2 ) +1;
                end1 = first.Length - 1;

                int q2 = (second.Length - (second.Length - mid2 +1));
                start2 = 0;
                end2 = q2 % 2 == 0 || q2 %2 == 0.5 ? q2 / 2 : (q2 / 2) +1;

                if (first.Length - mid1 == 1 && second.Length - (second.Length - mid2) == 1)
                    return first[mid1] < second[mid2] ? first[mid1] : second[mid2];   
                else
                   return MedianLogMPlusN(first, second, start1, end1, start2, end2);
            }
            else
            {
                int q1 = (first.Length  - (first.Length - mid1 +1));
                end1 = ((q1 %2 == 0 || q1 %2 == 0.5) ? q1 /2 : (q1 / 2) +1);
                start1 = 0;

                int q2 = (second.Length - mid2 +1);
                start2 += q2 %2 == 0 || q1 %2 == 0.5 ? q2 /2 : (q2 /2) +1;
                end2 = second.Length - 1;
                
                if (second.Length - mid2 == 1 && first.Length - (first.Length - mid1) == 1)
                    return first[mid1] < second[mid2] ? first[mid1] : second[mid2];                
                else 
                    return MedianLogMPlusN(first, second, start1, end1, start2, end2);
            }

            return 0;
        }
    }
}