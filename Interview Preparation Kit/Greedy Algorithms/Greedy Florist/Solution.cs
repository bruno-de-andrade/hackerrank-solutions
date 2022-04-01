using System.Diagnostics;

namespace InterviewPreparationKit.GreedyAlgorithms.Greedy_Florist
{
    class Solution
    {
        // Complete the getMinimumCost function below.
        private static int GetMinimumCost(int k, int[] c)
        {
            int minCost = 0;

            Array.Sort(c);

            for (int index = c.Length - 1; index >= 0; index--)
            {
                int previousPurchases = (c.Length - (index + 1)) / k;
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

            int minimumCost = GetMinimumCost(k, c);

            watch.Stop();

            Console.WriteLine(minimumCost);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}