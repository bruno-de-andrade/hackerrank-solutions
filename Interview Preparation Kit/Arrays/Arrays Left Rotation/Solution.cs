using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Arrays.Arrays_Left_Rotation
{
    internal class Solution
    {
        private static int[] rotLeft(int[] a, int d)
        {
            for (int rotationIndex = 0; rotationIndex < d; rotationIndex++)
            {
                int firstValue = a[0];

                Array.Copy(a, 1, a, 0, a.Length - 1);

                a[a.Length - 1] = firstValue;
            }

            return a;
        }

        private static void Main(string[] args)
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            var watch = Stopwatch.StartNew();

            int[] result = rotLeft(a, d);

            watch.Stop();

            Console.WriteLine(string.Join(" ", result));

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}