using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Sorting.Mark_and_Toys
{
    internal class Solution
    {
        // Complete the maximumToys function below.
        private static int maximumToys(int[] prices, int k)
        {
            int aux, countToys = 0, sumPrice = 0;

            while (sumPrice < k)
            {
                for (int index = prices.Length - 1; index > countToys; index--)
                {
                    if (prices[index] < prices[index - 1])
                    {
                        //swap
                        aux = prices[index];
                        prices[index] = prices[index - 1];
                        prices[index - 1] = aux;
                    }
                }

                if (sumPrice + prices[countToys] <= k)
                {
                    sumPrice += prices[countToys];
                    countToys++;
                }
                else
                    return countToys;
            }

            return countToys;
        }

        private static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp));
            
            var watch = Stopwatch.StartNew();

            int result = maximumToys(prices, k);
            
            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}