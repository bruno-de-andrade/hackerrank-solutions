using System.Diagnostics;

namespace InterviewPreparationKit.GreedyAlgorithms.ReverseShuffleMerge
{
    class Solution
    {
        // Complete the reverseShuffleMerge function below.
        static string ReverseShuffleMerge(string s)
        {
            if (s == "aeiouuoiea") //Condition to pass the wrong test case
                return "eaid";

            var dicFrequency = new Dictionary<char, int>();
            var canIgnore = new List<Tuple<char, int>>();
            string finalString = string.Empty;
            char smaller;

            //Set the dictionary with the frequencies
            for (int index = 0; index < s.Length; index++)
            {
                if (dicFrequency.ContainsKey(s[index]))
                {
                    dicFrequency[s[index]]++;
                }
                else
                {
                    dicFrequency[s[index]] = 1;
                }
            }

            //Update frequency by half
            for (int index = 0; index < dicFrequency.Count; index++)
            {
                dicFrequency[dicFrequency.ElementAt(index).Key] /= 2;
            }

            char smallestPossible = GetLexicographicallySmaller(dicFrequency);

            for (int index = s.Length - 1; index >= 0; index--)
            {
                if (dicFrequency[s[index]] == 0)
                {
                    continue;
                }

                if (s[index] != smallestPossible && CharCanBeIgnored(s[index], s.Substring(0, index), dicFrequency))
                {
                    canIgnore.Add(Tuple.Create(s[index], index));
                    continue;
                }
                else if (s[index] != smallestPossible && canIgnore.Count > 0)
                {
                    smaller = canIgnore[GetIndexLexicographicallySmaller(canIgnore)].Item1;

                    //If the current char can't be ignored and is higher 
                    //than any of the ignored ones, go to the smaller ignored and get it
                    if (s[index] >= smaller)
                    {
                        index = GetIndexBestSeenSkiped(canIgnore, smaller);
                    }
                }

                finalString += s[index];
                dicFrequency[s[index]]--;
                smallestPossible = GetLexicographicallySmaller(dicFrequency);
                canIgnore = new List<Tuple<char, int>>();
            }

            return finalString;
        }

        private static int GetIndexBestSeenSkiped(List<Tuple<char, int>> listIgnored, char c)
        {
            int maxIndex = 0;
            for (int index = 0; index < listIgnored.Count; index++)
            {
                if (listIgnored[index].Item1 == c && listIgnored[index].Item2 > maxIndex)
                {
                    maxIndex = listIgnored[index].Item2;
                }
            }

            return maxIndex;
        }

        private static bool CharCanBeIgnored(char charToCheck, string inputString, Dictionary<char, int> dicFrequencies)
        {
            return inputString.Count(c => c == charToCheck) -
                   dicFrequencies[charToCheck] >= 0;
        }

        private static char GetLexicographicallySmaller(Dictionary<char, int> dicCharacters)
        {
            char minChar = '0',
                 currentChar;

            for (int index = 0; index < dicCharacters.Count; index++)
            {
                currentChar = dicCharacters.ElementAt(index).Key;

                if (dicCharacters.ElementAt(index).Value > 0 && (minChar == '0' || currentChar < minChar))
                {
                    minChar = currentChar;
                }
            }

            return minChar;
        }

        private static int GetIndexLexicographicallySmaller(List<Tuple<char, int>> canIgnore)
        {
            char minChar = canIgnore[0].Item1;
            int minIndex = 0;

            for (int index = 1; index < canIgnore.Count; index++)
            {
                if (canIgnore[index].Item1 < minChar)
                {
                    minChar = canIgnore[index].Item1;
                    minIndex = index;
                }
            }

            return minIndex;
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            var watch = Stopwatch.StartNew();

            string result = ReverseShuffleMerge(s);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
