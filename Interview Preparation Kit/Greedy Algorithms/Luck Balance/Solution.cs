using System.Diagnostics;

namespace InterviewPreparationKit.GreedyAlgorithms.LuckBalance
{
    class Solution
    {
        // Complete the luckBalance function below.
        private static int LuckBalance(int k, int[][] contests)
        {
            int countImportantContests = 0,
                sumLuck = 0;

            for (int index = 0; index < contests.Length; index++)
            {
                sumLuck += contests[index][0];

                if (contests[index][1] == 1)
                {
                    countImportantContests++;
                }
            }

            int minLuck = 0, minLuckIndex = -1;
            while (countImportantContests > k)
            {
                for (int index = 0; index < contests.Length; index++)
                {
                    if (contests[index][1] == 1 && (minLuck == 0 || contests[index][0] < minLuck))
                    {
                        minLuck = contests[index][0];
                        minLuckIndex = index;
                    }
                }

                sumLuck -= minLuck * 2;
                contests[minLuckIndex][1] = 0;
                minLuck = 0;
                countImportantContests--;
            }

            return sumLuck;
        }

        private static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] contests = new int[n][];

            for (int i = 0; i < n; i++)
            {
                contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
            }

            var watch = Stopwatch.StartNew();

            int result = LuckBalance(k, contests);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
