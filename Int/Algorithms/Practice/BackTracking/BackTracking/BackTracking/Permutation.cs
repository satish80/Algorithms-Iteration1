using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    public class Permutation
    {
        char[] arr;

        public void DisplayPermutations()
        {
            arr = new char[] {'a','b','c' };

            //Permute(0, 5);
            Perm(arr,0,3);
            //for(int idx = 0;idx<arr.Length;idx++)
            //{
            //    for (int innerIdx = 0; innerIdx < arr.Length-1; innerIdx++)
            //    {
            //        if(result[idx,innerIdx]!=0)
            //            Console.WriteLine(result[idx,innerIdx]);
            //    }
            //}
            Console.Read();
        }

        //private char Permute(int pos, int length)
        //{
        //    if (pos != length - 1 && pos > 0)
        //    {
        //        //arr[Permute(++pos, 3)] + arr[Permute(--pos, 3)];
        //        string str = (Permute(++pos, 4).ToString() + Permute(pos--, 4).ToString()).ToString();
        //        Console.WriteLine(str);
        //    }

        //    return arr[pos];
        //}

        private char[,] CrePremute(int level, char[] arr)
        {
            char[,] chosen = new char[level+1, level+3];
            int count = 1;
            for (int idx = 0; idx < arr.Length - 1; idx++)
            {
                chosen[idx, 0] = arr[idx];
                for (int levelIdx = 0; levelIdx <= level-1; levelIdx++)
                {
                    if (idx != levelIdx)
                        chosen[idx, count++] = arr[levelIdx];
                }
                chosen[idx, (level )] = arr[level ];
                chosen[idx, (level + 1)] = arr[level + 1];
            }
            return chosen;
        }

        void permutate(char[] str, int index)
        {
            int i = 0;
            if (index == str.Length)
            { // We have a permutation so print it
                Console.WriteLine(str);
                return;
            }
            for (i = index; i < (str.Length); i++)
            {
                swap(ref str[index], ref str[i]); // It doesn't matter how you swap.
                permutate(str, index + 1);
                swap(ref str[index], ref str[i]);
            }
        }

        void swap(ref char a, ref char b)
        {
            char temp = a;
            a = b; b = temp;
        }

        void Perm(char[] arr,int k, int n)
        {
            if (k == n)
            {
                Console.WriteLine("______________________________");
                for (int idx = 0; idx < n; idx++)
                    Console.WriteLine(arr[idx].ToString());
                Console.WriteLine("______________________________");
            }
            else
            {
                for (int i = k; i < n; i++)
                {
                    char temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;

                    Perm(arr,k+1,n);

                    temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
}
