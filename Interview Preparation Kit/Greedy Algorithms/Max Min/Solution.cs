using System;

namespace Interview_Preparation_Kit.Greedy_Algorithms.Max_Min
{
    internal class Solution
    {
        // Complete the maxMin function below.
        private static int maxMin(int k, int[] arr)
        {
            Array.Sort(arr);

            int minUnfairness = arr[k - 1] - arr[0],
                currentUnfairness = 0;

            for (int index = 1; index + k - 1 < arr.Length; index++)
            {
                currentUnfairness = arr[index + k - 1] - arr[index];

                if (currentUnfairness < minUnfairness)
                {
                    minUnfairness = currentUnfairness;
                }
            }

            return minUnfairness;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int k = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            int result = maxMin(k, arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}