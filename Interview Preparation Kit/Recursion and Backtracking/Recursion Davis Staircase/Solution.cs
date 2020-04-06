using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Recursion_and_Backtracking.Recursion_Davis_Staircase
{
    class Solution
    {
        static Dictionary<int, int> dic = new Dictionary<int, int>();

        static int stepPerms(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int count = 0;

            // Uses memoization to store sub-problem solutions
            if (!dic.ContainsKey(n))
            {
                for (int steps = 3; steps > 0; steps--)
                {
                    if (n >= steps)
                    {
                        count += stepPerms(n - steps);
                    }
                }

                dic.Add(n, count);
            }

            return dic[n];
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Recursion and Backtracking\Recursion Davis Staircase\testCase1.txt");

            int s = Convert.ToInt32(file.ReadLine());

            var watch = Stopwatch.StartNew();

            for (int sItr = 0; sItr < s; sItr++)
            {
                int n = Convert.ToInt32(file.ReadLine());

                int res = stepPerms(n);

                Console.WriteLine(res);
            }

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            file.Close();

            Console.ReadKey();
        }
    }
}
