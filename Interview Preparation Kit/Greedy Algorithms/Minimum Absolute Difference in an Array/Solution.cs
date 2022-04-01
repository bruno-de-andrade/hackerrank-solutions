namespace InterviewPreparationKit.GreedyAlgorithms.MinimumAbsoluteDifferenceInAnArray
{
    class Solution
    {
        // Complete the minimumAbsoluteDifference function below.
        static int MinimumAbsoluteDifference(int[] arr)
        {
            int minDiff = Math.Abs(arr[0] - arr[1]);

            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int diff = Math.Abs(arr[i] - arr[i + 1]);

                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            return minDiff;

        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = MinimumAbsoluteDifference(arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
