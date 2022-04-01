using System.Diagnostics;

namespace InterviewPreparationKit.RecursionAndBacktracking.RecursionFibonacciNumbers
{
    class SolutionMemoization
    {
        static int?[] memoized;

        public static int? Fibonacci(int index)
        {
            if (memoized[index] == null)
            {
                if (index < 2)
                {
                    memoized[index] = index;
                }
                else
                {
                    memoized[index] = Fibonacci(index - 2) + Fibonacci(index - 1);
                }
            }

            return memoized[index];
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            var watch = Stopwatch.StartNew();

            memoized = new int?[n + 1];

            int value = Fibonacci(n).Value;

            watch.Stop();

            Console.WriteLine(value);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
