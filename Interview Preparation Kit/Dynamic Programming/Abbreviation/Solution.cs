using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Dynamic_Programming.Abbreviation
{
    class Solution
    {
        static bool?[,] memory;

        // Complete the abbreviation function below.
        static string abbreviation(string a, string b)
        {
            memory = new bool?[a.Length + 1, b.Length + 1];

            if (canAbbreviate(a, b))
                return "YES";
            else
                return "NO";
        }

        static bool canAbbreviate(string a, string b)
        {
            if (memory[a.Length, b.Length] != null)
                return memory[a.Length, b.Length].Value;

            bool curResult;

            if (a.Length < b.Length)
                curResult = false;
            else if (b == "")
            {
                if (a == "")
                    curResult = true;
                else
                    curResult = !hasAnyUpperCase(a);
            }
            else if (char.IsUpper(a[0]))
            {
                if (a[0] != b[0])
                    curResult = false;
                else
                    curResult = canAbbreviate(a.Substring(1), b.Substring(1));
            }
            else if (char.ToUpper(a[0]) == b[0])
                curResult = canAbbreviate(a.Substring(1), b.Substring(1)) ||
                            canAbbreviate(a.Substring(1), b);
            else
                curResult = canAbbreviate(a.Substring(1), b);

            memory[a.Length, b.Length] = curResult;

            return curResult;
        }

        static bool hasAnyUpperCase(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsUpper(a[i]))
                    return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Dynamic Programming\Abbreviation\testCase1.txt");

            int q = Convert.ToInt32(file.ReadLine());

            var watch = Stopwatch.StartNew();

            for (int qItr = 0; qItr < q; qItr++)
            {
                string a = file.ReadLine();

                string b = file.ReadLine();

                string result = abbreviation(a, b);

                Console.WriteLine(result);
            }

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            file.Close();

            Console.ReadKey();
        }
    }
}
