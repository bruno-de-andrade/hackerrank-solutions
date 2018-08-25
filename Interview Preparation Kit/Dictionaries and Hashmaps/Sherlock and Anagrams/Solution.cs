using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Interview_Preparation_Kit.Dictionaries_and_Hashmaps.Sherlock_and_Anagrams
{
    internal class Solution
    {
        private static int sherlockAndAnagrams(string s)
        {
            int countAnagrams = 0;
            var dictionary = new Dictionary<string, int>();
            string key;

            for (int count = 1; count < s.Length; count++)
            {
                for (int index = 0; index + count <= s.Length; index++)
                {
                    char[] keyArray = s.Skip(index).Take(count).ToArray();
                    Array.Sort(keyArray);
                    key = new string(keyArray);

                    if (dictionary.TryGetValue(key, out int occurencies))
                    {
                        countAnagrams += occurencies;
                        dictionary[key] = occurencies + 1;
                    }
                    else
                        dictionary.Add(key, 1);
                }
            }

            return countAnagrams;
        }

        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                var watch = Stopwatch.StartNew();

                int result = sherlockAndAnagrams(s);

                watch.Stop();

                Console.WriteLine(result);

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            }

            Console.ReadKey();
        }
    }
}
