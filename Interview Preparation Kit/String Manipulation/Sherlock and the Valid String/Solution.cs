using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.String_Manipulation.Sherlock_and_the_Valid_String
{
    internal class Solution
    {
        // Complete the isValid function below.
        private static string isValid(string s)
        {
            var dicLetters = new Dictionary<char, int>();
            var dicFrequency = new Dictionary<int, int>();
            int[] keys = new int[2] { 0, 0 };

            //Set the counting of each letter
            foreach (char c in s)
            {
                if (dicLetters.TryGetValue(c, out int count))
                {
                    dicLetters[c]++;
                }
                else
                {
                    dicLetters.Add(c, 1);
                }
            }

            foreach (KeyValuePair<char, int> entry in dicLetters)
            {
                if (dicFrequency.TryGetValue(entry.Value, out int count))
                {
                    dicFrequency[entry.Value]++;
                }
                else
                {
                    if (keys[0] == 0)
                    {
                        keys[0] = entry.Value;
                    }
                    else
                    {
                        keys[1] = entry.Value;
                    }

                    dicFrequency.Add(entry.Value, 1);
                }

                if (dicFrequency.Count > 2 ||
                    (dicFrequency.Count == 2 &&
                     (
                         (dicFrequency[keys[0]] > 1 && dicFrequency[keys[1]] > 1) ||
                         (dicFrequency[keys[0]] == 1 && keys[0] - 1 != keys[1] && keys[0] - 1 != 0) ||
                         (dicFrequency[keys[1]] == 1 && keys[1] - 1 != keys[0] && keys[1] - 1 != 0)
                     )
                    ))
                {
                    return "NO";
                }
            }

            return "YES";
        }

        private static void Main(string[] args)
        {
            string s = Console.ReadLine();

            var watch = Stopwatch.StartNew();

            string result = isValid(s);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}