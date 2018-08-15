using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Arrays._2D_Array___DS
{
    internal class Solution
    {
        private static int hourglassSum(int[][] arr)
        {
            int? maxSum = null;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    int currentSum = arr[y][x] + arr[y][x + 1] + arr[y][x + 2] +
                                     arr[y + 1][x + 1] +
                                     arr[y + 2][x] + arr[y + 2][x + 1] + arr[y + 2][x + 2];

                    if (maxSum == null || currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum.Value;
        }

        private static void Main(string[] args)
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            var watch = Stopwatch.StartNew();

            int result = hourglassSum(arr);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}