using System.Diagnostics;

namespace InterviewPreparationKit.RecursionAndBacktracking.RecursiveDigitSum
{
    class Solution
    {
        static int SuperDigit(string number, int timesToSum)
        {
            if (number.Length == 1)
                return Convert.ToInt32(number);

            long sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += (int)char.GetNumericValue(number[i]);
            }

            sum *= timesToSum;

            return SuperDigit(sum.ToString(), 1);
        }

        static void Main(string[] args)
        {
            var file = new System.IO.StreamReader(@"Recursion and Backtracking\Recursive Digit Sum\testCase1.txt");

            string[] nk = file.ReadLine().Split(' ');

            var watch = Stopwatch.StartNew();

            string n = nk[0];

            int k = Convert.ToInt32(nk[1]);

            int result = SuperDigit(n, k);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
