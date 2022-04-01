using System.Diagnostics;

namespace InterviewPreparationKit.DictionariesAndHashmaps.CountTriplets
{
    class Solution
    {
        private static long CountTriplets(List<long> arr, long r)
        {
            var dictionaryCount = new Dictionary<long, long>();
            var dictionaryPairs = new Dictionary<long, long>();

            long countTriplets = 0, key, nextKey;

            for (int index = arr.Count - 1; index >= 0; index--)
            {
                key = arr[index];
                nextKey = key * r;

                if (dictionaryPairs.TryGetValue(nextKey, out long nextValue))
                    countTriplets += nextValue;

                if (dictionaryCount.TryGetValue(nextKey, out long value))
                {
                    if (dictionaryPairs.ContainsKey(key))
                        dictionaryPairs[key] += value;
                    else
                        dictionaryPairs.Add(key, value);
                }

                if (dictionaryCount.ContainsKey(key))
                    dictionaryCount[key]++;
                else
                    dictionaryCount.Add(key, 1);
            }

            return countTriplets;
        }

        private static void Main(string[] args)
        {
            string[] nr = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nr[0]);

            long r = Convert.ToInt64(nr[1]);

            List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            var watch = Stopwatch.StartNew();

            long ans = CountTriplets(arr, r);

            watch.Stop();

            Console.WriteLine(ans);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
