using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Preparation_Kit.String_Manipulation.Strings_Making_Anagrams
{
    class Solution
    {
        static int makeAnagram(string a, string b)
        {
            var dicA = initializeDictionary(a);
            var dicB = initializeDictionary(b);

            if (dicA.Count > dicB.Count)
            {
                return countDifferences(dicA, dicB);
            }
            else
            {
                return countDifferences(dicB, dicA);
            }
        }

        static Dictionary<char, int> initializeDictionary(string word)
        {
            var countCharacters = new Dictionary<char, int>();

            foreach (char character in word)
            {
                if (countCharacters.TryGetValue(character, out int count))
                {
                    countCharacters[character]++;
                }
                else
                {
                    countCharacters.Add(character, 1);
                }
            }

            return countCharacters;
        }

        static int countDifferences(Dictionary<char, int> dicA, Dictionary<char, int> dicB)
        {
            int countDifferences = 0;

            foreach (KeyValuePair<char, int> entry in dicA)
            {
                if (dicB.TryGetValue(entry.Key, out int count) && count != entry.Value)
                {
                    countDifferences += count > entry.Value ? count - entry.Value : entry.Value - count;
                }
                else if (count != entry.Value)
                {
                    countDifferences += entry.Value;
                }
            }

            foreach (KeyValuePair<char, int> entry in dicB)
            {
                if (!dicA.ContainsKey(entry.Key))
                {
                    countDifferences += entry.Value;
                }
            }

            return countDifferences;
        }

        static void Main(string[] args)
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            var watch = Stopwatch.StartNew();

            int res = makeAnagram(a, b);

            watch.Stop();

            Console.WriteLine(res);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
