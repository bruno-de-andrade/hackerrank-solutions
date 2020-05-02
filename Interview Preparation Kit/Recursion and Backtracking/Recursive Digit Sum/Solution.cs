using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Recursion_and_Backtracking.Recursive_Digit_Sum
{
    class Solution
    {
        static int superDigit(string number, int timesToSum)
        {
            if (number.Length == 1)
                return Convert.ToInt32(number);

            long sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += (int)char.GetNumericValue(number[i]);
            }

            sum *= timesToSum;

            return superDigit(sum.ToString(), 1);
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Recursion and Backtracking\Recursive Digit Sum\testCase1.txt");

            string[] nk = file.ReadLine().Split(' ');

            var watch = Stopwatch.StartNew();

            string n = nk[0];

            int k = Convert.ToInt32(nk[1]);

            int result = superDigit(n, k);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
