using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Dictionaries_and_Hashmaps.Two_Strings
{
    internal class Solution
    {
        private static string twoStrings(string s1, string s2)
        {
            var dicS1 = new Dictionary<string, int>();

            for (int index = 0; index < s1.Length; index++)
            {
                if (!dicS1.ContainsKey(s1[index].ToString()))
                    dicS1.Add(s1[index].ToString(), 0);
            }

            for (int index = 0; index < s2.Length; index++)
            {
                if (dicS1.ContainsKey(s2[index].ToString()))
                    return "YES";
            }

            return "NO";
        }

        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s1 = Console.ReadLine();

                string s2 = Console.ReadLine();

                var watch = Stopwatch.StartNew();

                string result = twoStrings(s1, s2);

                Console.WriteLine(result);

                watch.Stop();

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            }

            Console.ReadKey();
        }
    }
}
