using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class SumOfDice
    {
        public void CalculateSumOfDice()
        {            
            
            Console.WriteLine("sum of dice is " +SumDice(6, 3, 6));
            Console.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">Faces of the dice</param>
        /// <param name="n">no of dice</param>
        /// <param name="x">the desired sum</param>
        /// <returns></returns>
        private int SumDice(int m,int n, int x)
        {
            int count = 0;

            if (x < 1)
                return 0;

            if (n == 1) 
                return (x <= m ? 1 : 0);

            for (int idx = 1; idx <= m; ++idx)
            {
                count += SumDice(m, n - 1, x - idx);
            }

            return count;
        }

        //private int SumDiceRecursion(int m, int n, int x)
        //
        //    int sum = 0, count=0;

        //    if (sum == x)
        //        count++;

        //    sum += SumDiceRecursion(m,n-1,x) + SumDiceRecursion(m,n,x-1);
        //}
    }
}
