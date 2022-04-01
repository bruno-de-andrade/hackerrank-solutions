using System.Diagnostics;

namespace InterviewPreparationKit.RecursionAndBacktracking.RecursionFibonacciNumbers
{
    class Solution
    {
        static int maxIndex;
        static int curIndex;

        public static int Fibonacci(int lastValue, int curValue)
        {
            if (curIndex == maxIndex)
            {
                return curValue;
            }

            curIndex++;

            return Fibonacci(curValue, lastValue + curValue);
        }

        static void Main(string[] args)
        {
            maxIndex = Convert.ToInt32(Console.ReadLine());
            curIndex = 1;

            var watch = Stopwatch.StartNew();

            int value = Fibonacci(0, 1);

            watch.Stop();

            Console.WriteLine(value);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
