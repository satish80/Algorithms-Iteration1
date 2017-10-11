using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Palindrome
    {
        int[] arr = null;
        bool palindrome = true;
        int count;
        public void IsPalindrome()
        {            
            arr = new int[6] {1,2,3,3,2,1};
            count = -1;
           
            Recursion(0);
            Console.WriteLine("The string {0} ", palindrome == true ? "is a palindrome" : "is not a palindrome" );
            Console.Read();
        }

        private int Recursion(int idx)
        {
            if (idx < (arr.Length - 1))
            {
                if (count <= (arr.Length - 1))
                {
                    idx++;
                    Recursion(idx);
                    if (arr[idx] != arr[count])
                        palindrome = false;
                }                
            }
            count++;
            return idx;

        }
    }
}
