using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.String_Manipulation.Common_Child
{
    internal class Solution
    {
        // Complete the commonChild function below.
        private static int commonChild(string s1, string s2)
        {
            int[,] letterTable = new int[s1.Length, s2.Length];

            for (int i = 1; i < s1.Length; i++)
            {
                for (int j = 1; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    { 
                        letterTable[i, j] = letterTable[i - 1, j - 1] + 1;
                    }
                    else
                    { 
                        letterTable[i, j] = Math.Max(letterTable[i, j - 1], letterTable[i - 1, j]);
                    }
                }
            }

            return letterTable[s1.Length - 1, s2.Length - 1];
        }    

        private static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            
            string s2 = Console.ReadLine();

            s1 = "0" + s1;
            s2 = "0" + s2;

            var watch = Stopwatch.StartNew();

            int result = commonChild(s1, s2);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}