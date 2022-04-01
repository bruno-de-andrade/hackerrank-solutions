namespace InterviewPreparationKit.DynamicProgramming.MaxArraySum
{
    class Solution
    {
        // Complete the maxSubsetSum function below.
        private static int MaxSubsetSum(int[] arr)
        {
            int maxSum = Math.Max(arr[0], arr[1]);
            int currentMax = -1;

            arr[1] = Math.Max(arr[0], arr[1]);

            for (int i = 2; i < arr.Length; i++)
            {
                currentMax = Math.Max(arr[i], arr[i] + arr[i - 2]);
                maxSum = Math.Max(maxSum, currentMax);

                arr[i] = maxSum;
            }

            return maxSum;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = MaxSubsetSum(arr);

            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
