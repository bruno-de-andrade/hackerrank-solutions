using System.Diagnostics;

namespace InterviewPreparationKit.Search.HashTablesIceCreamParlor
{
    class Solution
    {
        // Complete the whatFlavors function below.
        private static void WhatFlavors(int[] cost, int money)
        {
            var dicIndexes = new Dictionary<int, int>();

            int currentCost;

            for (int i = 0; i < cost.Length; i++)
            {
                currentCost = cost[i];

                //Try find the solution while adding to the dictionary
                if (dicIndexes.TryGetValue(money - currentCost, out int index) && index != i)
                {
                    Console.WriteLine(string.Format("{0} {1}", (dicIndexes[money - currentCost] + 1), (i + 1)));
                    return;
                }
                else
                {
                    dicIndexes[currentCost] = i;
                }
            }
        }

        private static void Main(string[] args)
        {
            var file = new StreamReader(@"Search\Hash Tables Ice Cream Parlor\testCase1.txt");

            var watch = Stopwatch.StartNew();

            int t = Convert.ToInt32(file.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int money = Convert.ToInt32(file.ReadLine());

                int n = Convert.ToInt32(file.ReadLine());

                int[] cost = Array.ConvertAll(file.ReadLine().Trim().Split(' '), costTemp => Convert.ToInt32(costTemp));

                WhatFlavors(cost, money);
            }

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            file.Close();

            Console.ReadKey();
        }
    }
}