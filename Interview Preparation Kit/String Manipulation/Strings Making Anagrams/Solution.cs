using System.Diagnostics;

namespace InterviewPreparationKit.StringManipulation.StringsMakingAnagrams
{
    class Solution
    {
        static int MakeAnagram(string a, string b)
        {
            var dicA = InitializeDictionary(a);
            var dicB = InitializeDictionary(b);

            if (dicA.Count > dicB.Count)
            {
                return CountDifferences(dicA, dicB);
            }
            else
            {
                return CountDifferences(dicB, dicA);
            }
        }

        static Dictionary<char, int> InitializeDictionary(string word)
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

        static int CountDifferences(Dictionary<char, int> dicA, Dictionary<char, int> dicB)
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

            int res = MakeAnagram(a, b);

            watch.Stop();

            Console.WriteLine(res);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
