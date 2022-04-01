using System.Diagnostics;

namespace InterviewPreparationKit.WarmUpChallenges.RepeatedString
{
    class Solution
    {
        // Complete the repeatedString function below.
        static long RepeatedString(string s, long n)
        {
            long countEachString = 0;

            //Find amount of 'a' in a loop through the string
            for (int index = 0; index < s.Length; index++)
            {
                if (s[index] == 'a')
                {
                    countEachString++;
                }

                if (index + 1 == n)
                {
                    return countEachString;
                }
            }

            //Calculate how many times the string must be repeated
            long countRepeatString = n / s.Length;
            long countTotal = countEachString * countRepeatString;

            //Sum the remaining
            n -= s.Length * countRepeatString;

            for (int index = 0; index < n; index++)
            {
                if (s[index] == 'a')
                {
                    countTotal++;
                }
            }

            return countTotal;
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            var watch = Stopwatch.StartNew();

            long result = RepeatedString(s, n);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
