using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Preparation_Kit.Warm_up_Challenges.Repeated_String
{
    class Solution
    {
        // Complete the repeatedString function below.
        static long repeatedString(string s, long n)
        {
            long countEachString = 0,
                 countRepeatString = 0,
                 countTotal = 0;

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
            countRepeatString = (long)n / s.Length;
            countTotal = countEachString * countRepeatString;

            //Sum the remaining
            n = n - s.Length * countRepeatString;

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

            long result = repeatedString(s, n);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
