using System;

namespace Interview_Preparation_Kit.Dynamic_Programming.Candies
{
    internal class Solution
    {
        // Complete the candies function below.
        private static long candies(int n, int[] arr)
        {
            long[] arrAmounts = new long[arr.Length];
            long totalAmount = 0;

            arrAmounts[0] = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                arrAmounts[i] = arr[i] > arr[i - 1] ? arrAmounts[i - 1] + 1 : 1;
            }

            totalAmount += arrAmounts[arr.Length - 1];

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1] && arrAmounts[i] <= arrAmounts[i + 1])
                {
                    arrAmounts[i] = arrAmounts[i + 1] + 1;
                }

                totalAmount += arrAmounts[i];
            }

            return totalAmount;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            long result = candies(n, arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
