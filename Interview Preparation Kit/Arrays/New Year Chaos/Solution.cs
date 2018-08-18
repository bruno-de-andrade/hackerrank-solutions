using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Arrays.New_Year_Chaos
{
    internal class Solution
    {
        // Complete the minimumBribes function below.
        private static void minimumBribes(int[] q)
        {
            int sumBribes = 0,
                aux = 0;

            for (int index = q.Length - 1; index > 0; index--)
            {
                if (q[index] == index + 1)
                    continue;

                if (q[index - 1] == index + 1)
                {
                    aux = q[index - 1];
                    q[index - 1] = q[index];
                    q[index] = aux;
                    sumBribes++;
                    continue;
                }

                if (q[index - 2] == index + 1)
                {
                    aux = q[index - 2];
                    q[index - 2] = q[index - 1];
                    q[index - 1] = q[index];
                    q[index] = aux;
                    sumBribes += 2;
                    continue;
                }

                Console.WriteLine("Too chaotic");
                return;
            }

            Console.WriteLine(sumBribes);
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

                var watch = Stopwatch.StartNew();

                minimumBribes(q);

                watch.Stop();

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            }

            Console.ReadKey();
        }
    }
}