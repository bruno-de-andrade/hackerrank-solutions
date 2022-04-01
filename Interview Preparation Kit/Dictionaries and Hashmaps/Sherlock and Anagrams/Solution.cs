using System.Diagnostics;

namespace InterviewPreparationKit.DictionariesAndHashmaps.SherlockAndAnagrams
{
    class Solution
    {
        private static int SherlockAndAnagrams(string s)
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

                int result = SherlockAndAnagrams(s);

                watch.Stop();

                Console.WriteLine(result);

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            }

            Console.ReadKey();
        }
    }
}
