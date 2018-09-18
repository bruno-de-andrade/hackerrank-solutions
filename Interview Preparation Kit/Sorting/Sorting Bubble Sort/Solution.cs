using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Sorting.Sorting_Bubble_Sort
{
    internal class Solution
    {
        private static void countSwaps(int[] a)
        {
            int countSwaps = 0;
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        isSorted = false;
                        Swap(ref a, j, j + 1);
                        countSwaps++;
                    }
                }
            }

            Console.WriteLine(string.Format("Array is sorted in {0} swaps.", countSwaps));
            Console.WriteLine(string.Format("First Element: {0}", a[0]));
            Console.WriteLine(string.Format("Last Element: {0}", a[a.Length - 1]));
        }

        private static void Swap(ref int[] arr, int indexA, int indexB)
        {
            var temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            var watch = Stopwatch.StartNew();

            countSwaps(a);

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}