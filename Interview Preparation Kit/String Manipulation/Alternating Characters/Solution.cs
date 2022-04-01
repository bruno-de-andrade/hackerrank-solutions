using System.Diagnostics;

namespace InterviewPreparationKit.StringManipulation.AlternatingCharacters
{
    class Solution
    {
        // Complete the alternatingCharacters function below.
        private static int AlternatingCharacters(string s)
        {
            char lastChar = ' ';
            int countDeletions = 0;

            for (int index = 0; index < s.Length; index++)
            {
                if (lastChar == s[index])
                {
                    countDeletions++;
                }

                lastChar = s[index];
            }

            return countDeletions;
        }

        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                var watch = Stopwatch.StartNew();

                int result = AlternatingCharacters(s);

                watch.Stop();

                Console.WriteLine(result);

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            }

            Console.ReadKey();
        }
    }
}