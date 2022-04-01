using System.Diagnostics;

namespace InterviewPreparationKit.Arrays.MinimumSwaps2
{
    class Solution
    {
        private static int MinimumSwaps(int[] arr)
        {
            int swaps = 0;

            for (int index = 0; index < arr.Length - 1; index++)
            {
                if (arr[index] != (index + 1))
                {
                    for (int swapIndex = index + 1; swapIndex < arr.Length; swapIndex++)
                    {
                        if (arr[swapIndex] == (index + 1))
                        {
                            int aux = arr[swapIndex];
                            arr[swapIndex] = arr[index];
                            arr[index] = aux;
                            swaps++;
                            break;
                        }
                    }
                }
            }

            return swaps;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            var watch = Stopwatch.StartNew();

            int res = MinimumSwaps(arr);

            watch.Stop();

            Console.WriteLine(res);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}
