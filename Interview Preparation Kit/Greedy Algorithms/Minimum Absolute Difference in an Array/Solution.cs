using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Preparation_Kit.Greedy_Algorithms.Minimum_Absolute_Difference_in_an_Array
{
    class Solution
    {
        // Complete the minimumAbsoluteDifference function below.
        static int minimumAbsoluteDifference(int[] arr)
        {
            int minDiff = Math.Abs(arr[0] - arr[1]),
                diff = 0;

            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                diff = Math.Abs(arr[i] - arr[i + 1]);

                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            return minDiff;

        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = minimumAbsoluteDifference(arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
