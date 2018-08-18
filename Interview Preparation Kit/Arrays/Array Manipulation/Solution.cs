using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Arrays.Array_Manipulation
{
    internal class Solution
    {
        //Stores only the difference between subsequent indexes
        private static long arrayManipulation(int n, int[][] queries)
        {
            long[] list = new long[n];
            long maxValue = 0,
                 sum = 0;

            for (int index = 0; index < queries.Length; index++)
            {
                list[queries[index][0] - 1] += queries[index][2];

                //Check if exists a value after the upper index and subtract to store the diff
                if ((queries[index][1]) < n)
                    list[queries[index][1]] -= queries[index][2];
            }

            for (int index = 0; index < n; index++)
            {
                sum += list[index];

                if (sum > maxValue)
                    maxValue = sum;
            }

            return maxValue;
        }

        //Solution too slow with huge test cases
        private static long arrayManipulation2(int n, int[][] queries)
        {
            long[] list = new long[n];
            long maxValue = 0;
            int summand = 0,
                endIndex = 0;

            for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
            {
                summand = queries[queryIndex][2];
                endIndex = queries[queryIndex][1] - 1;

                for (int valueIndex = queries[queryIndex][0] - 1; valueIndex <= endIndex; valueIndex++)
                {
                    list[valueIndex] += summand;
                }
            }

            for (int index = 0; index < n; index++)
            {
                if (list[index] > maxValue)
                    maxValue = list[index];
            }

            return maxValue;
        }

        private static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            var watch = Stopwatch.StartNew();

            long result = arrayManipulation(n, queries);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}