using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Crossword
    {
        public void SolveCrossword()
        {
            string find = "cm";
            char[,] grid = new char[4, 4] {
                { 'a','d','q','b' },
                { 'e','z','e','s' },
                { 'g','p','x','y' },
                { 'v','k','c','m' }
            };

            var vertical = 0;
            var horizontal = 0;
            string temp = string.Empty;

            while (vertical <= grid.GetUpperBound(0))
            {
                while (horizontal + find.Length <= grid.GetUpperBound(0) + 1)
                {
                    var x = horizontal;
                    while (x <= find.Length + 1)
                    {
                        temp += grid[vertical, x];
                        Console.WriteLine("{0}:{1}={2}", vertical, x, temp);
                        if (temp == find) 
                            Console.WriteLine("Found it");
                        x++;
                    }
                    temp = "";
                    horizontal++;
                }
                horizontal = 0;
                vertical++;
            }

            Console.WriteLine(new string('8', 34));
            vertical = 0;
            horizontal = 0;
            temp = string.Empty;
            while (horizontal <= grid.GetUpperBound(0))
            {
                while (vertical + find.Length <= grid.GetUpperBound(0) + 1)
                {
                    var x = vertical;
                    while (x <= find.Length + 1)
                    {
                        temp += grid[x, horizontal];
                        Console.WriteLine("{0}:{1}={2}", x, horizontal, temp);
                        if (temp == find) Console.WriteLine("Found it");
                        x++;
                    }
                    temp = "";
                    vertical++;
                }
                vertical = 0;
                horizontal++;
            }
        }
    }
}
