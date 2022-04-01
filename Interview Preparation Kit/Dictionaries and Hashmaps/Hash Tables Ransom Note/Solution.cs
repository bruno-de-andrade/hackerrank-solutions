using System.Diagnostics;

namespace InterviewPreparationKit.DictionariesAndHashmaps.HashTablesRansomNote
{
    class Solution
    {
        private static void CheckMagazine(string[] magazine, string[] note)
        {
            var magazineDict = new Dictionary<string, int>();

            //Create a dictionary with the magazine words and count of occurencies
            for (int index = 0; index < magazine.Length; index++)
            {
                if (!magazineDict.ContainsKey(magazine[index]))
                {
                    magazineDict.Add(magazine[index], 1);
                }
                else
                {
                    magazineDict[magazine[index]]++;
                }
            }

            for (int index = 0; index < note.Length; index++)
            {
                magazineDict.TryGetValue(note[index], out int auxValue);

                if (auxValue == 0)
                {
                    Console.WriteLine("No");
                    return;
                }
                else
                {
                    magazineDict[note[index]]--;
                }
            }

            Console.WriteLine("Yes");
        }

        private static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            var watch = Stopwatch.StartNew();

            CheckMagazine(magazine, note);

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}
