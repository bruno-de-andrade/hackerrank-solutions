using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Interview_Preparation_Kit.Dictionaries_and_Hashmaps.Frequency_Queries
{
    internal class Solution
    {
        private static List<int> freqQuery(List<List<int>> queries)
        {
            var returnList = new List<int>();
            var dictionaryFrequency = new Dictionary<int, int>();
            var dictionaryOccurencies = new Dictionary<int, int>();
            bool found;

            foreach (var q in queries)
            {
                found = dictionaryFrequency.TryGetValue(q[1], out int value);

                switch (q[0])
                {
                    case 1:
                        if (found)
                        {
                            dictionaryFrequency[q[1]]++;

                            dictionaryOccurencies[value]--;

                            if (dictionaryOccurencies.ContainsKey(value + 1))
                                dictionaryOccurencies[value + 1]++;
                            else
                                dictionaryOccurencies.Add(value + 1, 1);
                        }
                        else
                        {
                            dictionaryFrequency.Add(q[1], 1);

                            if (dictionaryOccurencies.ContainsKey(1))
                                dictionaryOccurencies[1]++;
                            else
                                dictionaryOccurencies.Add(1, 1);
                        }
                        break;
                    case 2:
                        if (found)
                        {
                            if (value > 0)
                            {
                                dictionaryFrequency[q[1]]--;

                                dictionaryOccurencies[value]--;

                                if (dictionaryOccurencies.ContainsKey(value - 1))
                                    dictionaryOccurencies[value - 1]++;
                                else
                                    dictionaryOccurencies.Add(value - 1, 1);
                            }
                            else
                            {
                                dictionaryFrequency.Remove(q[1]);
                                dictionaryOccurencies[value]--;
                            }
                        }
                        break;
                    case 3:
                        if (dictionaryOccurencies.ContainsKey(q[1]))
                            returnList.Add(1);
                        else
                            returnList.Add(0);
                        break;
                }

                if (found && dictionaryOccurencies[value] == 0)
                    dictionaryOccurencies.Remove(value);
            }

            return returnList;
        }

        private static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            var watch = Stopwatch.StartNew();

            List<int> ans = freqQuery(queries);

            watch.Stop();

            Console.WriteLine(string.Join("\n", ans));

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
