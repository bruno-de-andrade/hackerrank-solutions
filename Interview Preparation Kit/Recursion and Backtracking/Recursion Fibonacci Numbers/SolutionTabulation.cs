using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Recursion_and_Backtracking.Recursion_Fibonacci_Numbers
{
    class SolutionTabulation
    {
        static int[] table;

        public static int Fibonacci(int maxIndex)
        {
            table[0] = 0;
            table[1] = 1;

            for (int index = 2; index <= maxIndex; index++)
            {
                table[index] = table[index - 2] + table[index - 1];
            }

            return table[maxIndex];
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            var watch = Stopwatch.StartNew();

            table = new int[n + 1];

            int value = Fibonacci(n);

            watch.Stop();

            Console.WriteLine(value);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
