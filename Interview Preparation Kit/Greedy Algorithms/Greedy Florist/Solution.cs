using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Greedy_Algorithms.Greedy_Florist
{
    internal class Solution
    {
        // Complete the getMinimumCost function below.
        private static int getMinimumCost(int k, int[] c)
        {
            int minCost = 0,
                previousPurchases = 0;

            Array.Sort(c);

            for (int index = c.Length - 1; index >= 0; index--)
            {
                previousPurchases = (c.Length - (index + 1)) / k;
                minCost += (previousPurchases + 1) * c[index];
            }

            return minCost;
        }

        private static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));

            var watch = Stopwatch.StartNew();

            int minimumCost = getMinimumCost(k, c);

            watch.Stop();

            Console.WriteLine(minimumCost);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}