using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ArrayManipulation
    {
        //Design a hash table with 0(1) operations
        //how is phone diretory stored ==> Trie
        //Find shortest path in a matrix with obstacles
        //Given an array [a1b2c3d4] convert to [abcd1234] with 0(1) space and O(n) time
        public void Process()
        {
        }

        private void RemoveAlternateDuplicateCharacters(string str)
        {
        }

        //find kth smallest element in an array; do a quick sort method. [Order Stats] - Selection Algorithm
        private void SelectionAlgorithm()
        {
            //FindKthSmallest(Array, k)
            //pivot = some pivot element of the array. 

            //L = Set of all elements smaller than pivot in Array
            //R = Set of all elements greater than pivot in Array

            //if L > k FindKthSmalles(L, k)
            //else if(L+1 == k) return pivot
            //else return FindKthSmallest(R, k-L+1)
        }

        private void SolveCrossword()
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
                    while (x <= find.Length+1)
                    {
                        temp += grid[vertical, x];
                        Console.WriteLine("{0}:{1}={2}", vertical, x, temp);
                        if (temp == find) Console.WriteLine("Found it");
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
                    while (x <= find.Length +1)
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

        #region Elements in a Rotated Array
        //Total = O(log N)
        private int ElementInRotatedSortedArray(int[] arr, int size, int elementToFind)
        {
            var pivot = FindPivotOfRotatedArray(arr, 0, size);

            //if array is not pivoted, we can do a binary search on the whole input
            if (pivot == -1) 
                return BinarySearch(arr, 0, size, elementToFind);

            if (arr[pivot] == elementToFind)
                return pivot;
            else if (elementToFind < arr[pivot])
                return BinarySearch(arr, 0, pivot-1, elementToFind);
            else
                return BinarySearch(arr, pivot + 1, size, elementToFind);
        }

        //O(log n)
        private int BinarySearch(int[] arr, int start, int end, int elementToFind)
        {
            int mid = (start + end) / 2;
            if (arr[mid] == elementToFind)
                return mid;
            else if (elementToFind > arr[mid])
            {
                return BinarySearch(arr, mid + 1, end, elementToFind);
            }
            else
            {
                return BinarySearch(arr, start, mid - 1, elementToFind);
            }
        }

        //binary search O(log n)
        private int FindPivotOfRotatedArray(int[] arr, int start, int end)
        {
            if (end < start) return -1;

            int mid = (start + end) / 2;
            if (mid < end && arr[mid] > arr[mid + 1])
            {
                return mid;
            }
            if (arr[start] >= arr[mid])
                return FindPivotOfRotatedArray(arr, start, mid - 1);
            else
                return FindPivotOfRotatedArray(arr, mid + 1, end);

        }
        #endregion

        #region Native Data Manipulation
        private void ReverseInteger(int x)
        {
            int output = 0;
            while (x > 0)
            {
                output = (output * 10) + (x % 10);
                x = x / 10;
            }
            Console.WriteLine(output);
        }

        private void ToBinary(int n)
        {
            var stack = new Stack<int>();
            while (n > 0)
            {
                var bit = n % 2;
                stack.Push(bit);
                n = n / 2;
            }
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

        }

        //Sieve of Eratosthenes - O(n log log n)
        private void NoOfPrimes(int n)
        {
            var series = new bool[n];
            int j = 0;
            int k = 0;

            for (int i = 0; i <= n - 1; i++)
                series[i] = true;

            for (var i = 2; i < Math.Sqrt(n); i++)
            {
                if (series[i])
                {
                    while (j <= n)
                    {
                        series[j] = false;
                        if (i == 2) 
                            j = i ^ 2;
                        else
                        {
                            j = i ^ 2 + k * i;
                            k++;
                        }
                    }
                }
            }
            //all the trues are primes
        }

        //What is postfix to infix? => [2*3-4/5=infix (inorder)], [23*45/- = postfix]
        private string PrefixToPostfix()
        {
            //https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2
            return "";
        }

        //Reverse Polish notation, e.g. - 12+4*5+3-
        private int PostfixCalculation(string input)
        {
            int i = 0;
            var stack = new Stack<int>();
            foreach (var c in input)
            {
                if (int.TryParse(c.ToString(), out i))
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count < 2) throw new Exception("Less values");
                    var x = stack.Pop();
                    var y = stack.Pop();
                    switch (c)
                    {
                        case '+':
                            stack.Push((x + y));
                            break;
                        case '-':
                            stack.Push((x - y));
                            break;
                        case '*':
                            stack.Push((x * y));
                            break;
                        case '/':
                            stack.Push((x / y));
                            break;
                    }
                }
            }
            if (stack.Count > 1) throw new Exception("Less no of ops");
            return stack.Pop();
        }
        
        #endregion

        #region Rectangle Problems
        //more than 2 rectanges, rectanges can be rotated at an angle
        public Rectange IntersectionOfRectangle(Rectange r1, Rectange r2)
        {
            if (r1 == null) return r2;
            if(r2 == null) return r1;

            return new Rectange()
            {
                 Top = Math.Max(r1.Top, r2.Top),
                 Bottom = Math.Min(r1.Bottom, r2.Bottom),
                 Left = Math.Max(r1.Left, r2.Left),
                 Right = Math.Min(r1.Right, r2.Right)
            };
        }

        public bool DoRectanglesIntersect(Rectange r1, Rectange r2)
        {
            var condition1 = r2.Left > r1.Right; //R1 is totally left of R2
            var condition2 = r2.Right < r1.Left; //R1 is totall right of R2
            var condition3 = r2.Top < r1.Bottom; //R1 is on top of R2
            var condition4 = r2.Bottom > r1.Top; //R1 is on the bottom of R2

            return !(condition1 || condition2 || condition3 || condition4);
        }
        #endregion

        #region Matrix Problems
        private void PrintMatrix()
        {
            int[,] numbers = new int[4, 4] {
                { 1,2,3,4 },
                { 5,6,7,8 },
                { 9,0,1,2 },
                { 3,4,5,6 }
            };

            for (int i = 0; i <= numbers.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= numbers.GetUpperBound(1); j++)
                {
                    Console.Write(numbers[i,j] +" ");
                }
                Console.WriteLine("");
            }
        }

        private void PrintMatrixInSpiral()
        {
            int[,] numbers = new int[4, 4] {
                { 1,2,3,4 },
                { 5,6,7,8 },
                { 9,0,1,2 },
                { 3,4,5,6 }
            };
            int size = 4;
            int j = 0 ;

            for (int i = size - 1; i >= 0; i--)
            {
                //top row, i.e. 123
                for (int k = j; k < i; k++)
                {
                    Console.Write(numbers[j, k]); //[0,1][0,2][0,3]
                }

                //right lines, i.e. 482
                for (int k = j; k < i; k++)
                {
                    Console.Write(numbers[k, i]); //[0,3][1,3][2,3]
                }

                //bottom line, 654
                for (int k = i; k > j; k--)
                {
                    Console.Write(numbers[i, k]); //[3,3][3,2][3,1]
                }

                //left line, 395
                for (int k = i; k > j; k--)
                {
                    Console.Write(numbers[k, j]); //[3,3][3,2][3,1]
                }
                j++;
            }
        }

        public int[,] RotateMatrixBy90()
        {
            //O(n2)
            int[,] matrix = new int[4, 4] {
                { 1,2,3,4 },
                { 5,6,7,8 },
                { 9,0,1,2 },
                { 3,4,5,6 }
            };

            int n = 4;
            int[,] ret = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }
            return ret;
        }

        #region Robot Problem
        public void RobotProblem()
        {
            int[,] matrix = new int[3, 7] {
                { 1,2,3,4, 5, 6, 7 },
                { 11,12,13,14, 15, 16, 17 },
                { 21,22,23,24, 25, 26, 27 },
            };
            var m = matrix.GetUpperBound(0);
            var n = matrix.GetUpperBound(1);
            var x = BackTracking(matrix, 0, 0, m, n);
            Console.WriteLine("Total unique path ="+ x);
        }

        private int BackTracking(int[,] matrix, int row, int col, int m, int n)
        {
            if (row == m && col == n) return 1;
            if (row > m || col > n) return 0;
            return BackTracking(matrix, row + 1, col, m, n) + BackTracking(matrix, row, col + 1, m, n);
        }
        #endregion

        #endregion

        #region Reverse An Arry by K nodes
        //O(nk)
        //This is entry methid, which does in three steps, we first rever 0 to k-1, then k to end of array, and then the whole array
        public  void RotateArrayByKPosition(int[] input, int k)
        {
            //Input: 1,2,3,4,5,6,7 [k=2]
            //Excpected: 3,4,5,6,7,1,2
            Reverse(input, 0, k - 1);
            //2,1,3,4,5,6,7
            Reverse(input, k, input.Length - 1);
            //2,1,7,6,5,4,3
            Reverse(input, 0, input.Length - 1);
            //3,4,5,6,7,1,2
        }

        //The idea to reverse the reverse from the starting point
        public  void Reverse(int[] arr, int start, int end)
        {
            for (int i = start; i <= (start + end) / 2; i++)
            {
                SwapHelper(arr, i, (start + end) - i);
            }
        }

        //This is the core swap method, which performs in-place swapping, 
        //i.e. it keeps the initial value in a var and then swaps with with the 2nd value
        public  void SwapHelper(int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }
        #endregion

        #region Array Problems
        private string FindUniqueItems(string input1, string input2)
        {
            string output = string.Empty;
            var kv = new Dictionary<char, int>();
            for (int i = 0; i <= input1.Length - 1; i++)
            {
                if(kv.ContainsKey(input1[i])) kv[input1[i]]++;
                else kv.Add(input1[i], 1);
            }

            for (int i = 0; i <= input2.Length - 1; i++)
            {
                if (kv.ContainsKey(input2[i])) kv[input2[i]]--;
            }

            var unique = kv.Where(x => x.Value > 0);
            foreach (var itm in unique) output += itm.Key;
            return output;
        }

        public void MergeSortedArrayInPlace(int[] a, int[] b, int longUseFull)
        {
            var longtail = longUseFull - 1;
            var shorttail = b.Length - 1;
            while (longtail >= 0 && shorttail >= 0)
            {
                if (a[longtail] > b[shorttail])
                {
                    a[longtail + shorttail + 1] = a[longtail];
                    longtail--;
                }
                else
                {
                    a[longtail + shorttail + 1] = b[shorttail];
                    shorttail--;
                }
            }
        }

        //Kandane Algorithm O(n)
        public int SubArryWithMaximumSum(int[] arr)
        {
            var max_so_far = arr[0];
            var max_end_index = arr[0];

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                max_end_index = max_end_index + arr[i];
                if (max_end_index < 0)
                    max_end_index = 0;
                else if (max_so_far < max_end_index)
                    max_so_far = max_end_index;
            }
            return max_so_far;
        }

        public int[] MoveAll1sToEnd(int[] arr)
        {
            int zeroIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    if (i != zeroIndex && arr[i] != arr[zeroIndex])
                    {
                        int temp = arr[i];
                        arr[i] = arr[zeroIndex];
                        arr[zeroIndex] = temp;
                    }
                    zeroIndex++;
                }
            }
            return arr;
        }

        public int MedianOfTwoSortedArray(int[] ar1, int[] ar2, int left, int right, int n)
        {
            int i, j;

            /* We have reached at the end (left or right) of ar1[] */
            if (left > right)
                return MedianOfTwoSortedArray(ar2, ar1, 0, n - 1, n);

            i = (left + right) / 2; //mid of array 1
            j = n - i - 1;  //Index of ar2[]

            if (ar1[i] > ar2[j] && (j == n - 1 || ar1[i] <= ar2[j + 1])) //this is the medium
            {
                if (ar2[j] > ar1[i - 1] || i == 0)
                    return (ar1[i] + ar2[j]) / 2;
                else
                    return (ar1[i] + ar1[i - 1]) / 2;
            }

            //ar1[i] is greater then both ar2[j] and ar2[j+1], Search in left half of ar1[]
            else if (ar1[i] > ar2[j] && j != n - 1 && ar1[i] > ar2[j + 1]) 
                return MedianOfTwoSortedArray(ar1, ar2, left, i - 1, n);

            //ar1[i] is smaller than both ar2[j] and ar2[j+1], Search in right half of ar1[]
            else 
                return MedianOfTwoSortedArray(ar1, ar2, i + 1, right, n);
        }

        private void TwoPairWithSumM(int[] arr, int M)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start != end)
            {
                if (arr[start] + arr[end] == M)
                {
                    Console.WriteLine("Found {0} + {1} = {2}", arr[start], arr[end], M);
                    break;
                }
                else if (arr[start] + arr[end] < M)
                {
                    start++;
                }
                else if (arr[start] + arr[end] > M)
                {
                    end--;
                }
            }
        }

        //Use two for loops and move the chanracters one step - O(n2)
        //sort the input O(n log n) and then do a linear scan and replace O(n) = Total = O(n log n);
        public void RemoveDuplicatesInPlace(int[] input)
        {
            var sortedInput = input.OrderBy(x => x).ToArray<int>(); //O(n log n)
            int start = 1;
            int end = 1;

            //O(n)
            while (start < sortedInput.Length)
            {
                if (sortedInput[start] != sortedInput[start - 1])
                {
                    sortedInput[end] = sortedInput[start];
                    end++;
                }
                start++;
            }

            for (int i = end; i < sortedInput.Length; i++) 
                sortedInput[i] = -1;

        }

        public void InPlaceSwap(int[] input)
        {
            //123456
            //214365
            int i = 0;
            while (i < input.Length && i != input.Length - 1)
            {
                var tmp = input[i];
                input[i] = input[i + 1];
                input[i + 1] = tmp;
                i += 2;
            }
        }

        //O(n) and O(1)
        private int MaximumRepeatingElementinArray(int[] arr, int range)
        {
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                arr[arr[i] % range] += range;
            }

            int max = arr[0];
            int result = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }

            return result;
        }

        //card shuffle
        int[] CardShuffle(int[] cards)
        {
            var random = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int j = random.Next() % (cards.Length - i);
                if (i != j)
                {
                    SwapHelper(cards, i, j);
                }
            }
            return cards;
        }

        #endregion

        #region String problems
        private void LargestPalidrome(string input)
        {
            int rightIndex = 0;
            int leftIndex = 0;
            string currentPalindrome = "";
            string longestPalindrome = "";
            for (int centerIndex = 1; centerIndex < input.Length - 1; centerIndex++)
            {
                leftIndex = centerIndex - 1; 
                rightIndex = centerIndex + 1;
                while (leftIndex >= 0 && rightIndex < input.Length)
                {
                    if (input[leftIndex] != input[rightIndex])
                    {
                        break;
                    }
                    currentPalindrome = input.Substring(leftIndex, rightIndex + 1 - leftIndex);
                    longestPalindrome = currentPalindrome.Length > longestPalindrome.Length ? currentPalindrome : longestPalindrome;
                    leftIndex--;
                    rightIndex++;
                }
            }
            Console.WriteLine(longestPalindrome);
        }

        private void SubstringNonRepeating(string s)
        {
            var map = new Dictionary<char, int>();
            int begining = 0;
            int currentlength = 0;
            int longest = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (map.Keys.Contains(s[i]))
                {
                    currentlength = i - begining;
                    begining = i;
                    if (currentlength > longest) 
                        longest = currentlength;
                }else map.Add(s[i], i);
            }
            Console.WriteLine("Length of Longest non repeating substring : " + longest);
        }

        //O(nm)
        private void LongestCommonSubstring(string input1, string input2)
        {
            var output = string.Empty;
            var tempArry = new int[input1.Length, input2.Length];
            int lengthUptilNow = 0; //length os LCS found uptil now
            int end = 0;
            for (int i = 0; i <= input1.Length - 1; i++)
            {
                for (int j = 0; j <= input2.Length - 1; j++)
                {
                    if (input1[i] == input2[j])
                    {
                        if (i == 0 && j == 0)
                            tempArry[i, j] = 1;
                        else
                            tempArry[i, j] = tempArry[i - 1, j - 1] + 1;

                        if (tempArry[i, j] > lengthUptilNow)
                        {
                            lengthUptilNow = tempArry[i, j];
                            end = i;
                        }
                        else
                        {
                            tempArry[i, j] = 0;
                        }
                    }
                }
            }

            for (int i = end - lengthUptilNow + 1; i <= end; i++)
            {
                output += input1[i];
            }
            Console.WriteLine(output);
        }

        public void Permuate(string beginningString, string endingString)
        {
            if (endingString.Length <= 1)
            {
                Console.WriteLine(beginningString + endingString);
            }
            else
            {
                for (int i = 0; i < endingString.Length; i++)
                {
                    string newString = endingString.Substring(0, i) + endingString.Substring(i + 1);
                    Permuate(beginningString + endingString.ElementAt(i), newString);
                }
            }
        }

        public void Swap(ref char x, ref char y)
        {
            var tmp = x;
            x = y;
            y = tmp;
        }

        //how to do it in place??
        public void RunLengthCompression(string input)
        {
            int count = 1;
            string output = string.Empty;
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (i < input.Length - 1 && input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    output += input[i].ToString() + count;
                    count = 1;
                }
            }
            Console.WriteLine(output);
        }

        //O(n)
        public void FindWords(string input)
        {
            int sepState = 0;
            int wordCount = 1;

            for (int i = 0; i <= input.ToCharArray().Length - 1; i++)
            {
                if (input[i] == ' ' || input[i] == '\n' || input[i] == '\t')
                {
                    sepState = 1;
                }
                else if (sepState == 1)
                {
                    sepState = 0;
                    wordCount++;
                }
            }
            Console.WriteLine(wordCount);

        }

        public void FirstNonRepeatingChr(string input)
        {
            char output = ' ';
            var dict = new Dictionary<char, int>();

            //O(n)
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (dict.ContainsKey(input[i])) dict[input[i]]++;
                else dict.Add(input[i], 1);
            }
            //O(n)
            foreach (var kv in dict)
            {
                if (kv.Value == 1)
                {
                    output = kv.Key;
                    break;
                }
            }
            Console.WriteLine(output.ToString());
        }

        public void ReverseWordOrder(string input)
        {
            int start = 0;
            int end = 0;
            string final = string.Empty;
            var upside = input + " ";// ReverseString(input) +" ";
            for (int i = 0; i <= upside.Length - 1; i++)
            {
                if (upside[i] == ' ')
                {
                    end = i;
                    final += ReverseString(upside.Substring(start, end-start)) + " ";
                    start = end + 1;
                }
            }
            Console.WriteLine(final);
        }

        public string ReverseString(string input)
        {
            var data = input.ToCharArray();
            int start = 0;
            int end = data.Length - 1;
            while (true)
            {
                if (start >= end) break;

                var tmp = data[start];
                data[start] = data[end];
                data[end] = tmp;
                start++;
                end--;

            }
            return (new string(data));
        }

        public string ReverseRecursion(string s)
        {
            if (s.Length > 0)
                return s[s.Length - 1] + ReverseRecursion(s.Substring(0, s.Length - 1));
            else
                return s;
        }
        
        #endregion

    }
}
