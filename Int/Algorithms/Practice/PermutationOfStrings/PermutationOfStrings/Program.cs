using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            printAllKLengthRec(new char[] {'a','b'},"",2,3);
        }

        static void printAllKLengthRec(char[] set, String prefix, int n, int k)
        {
         
        // Base case: k is 0, print prefix
        if (k == 0) 
        {
            Console.WriteLine(prefix);
            return;
        }
 
        // One by one add all characters from set and recursively 
        // call for k equals to k-1
            for (int i = 0; i < n; ++i) 
            {
             
                // Next character of input added
                String newPrefix = prefix + set[i]; 
             
                // k is decreased, because we have added a new character
                printAllKLengthRec(set, newPrefix, n, k - 1); 
            }
        }
    }
}
