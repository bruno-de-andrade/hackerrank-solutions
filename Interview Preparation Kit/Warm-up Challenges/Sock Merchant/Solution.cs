namespace InterviewPreparationKit.WarmUpChallenges.SockMerchant
{
    class Solution
    {
        // Complete the sockMerchant function below.
        private static int sockMerchant(int n, int[] ar)
        {
            int[,] counts = new int[n, 2]; //Matrix containing in each line a number and the count of it

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (counts[j, 0] == 0)
                    {
                        counts[j, 0] = ar[i];
                        counts[j, 1] = 1;
                        break;
                    }

                    if (counts[j, 0] == ar[i])
                    {
                        counts[j, 1]++;
                        break;
                    }
                }
            }

            int numberOfPairs = 0;

            for (int index = 0; index < n; index++)
            {
                if (counts[index, 0] > 0)
                {
                    numberOfPairs += (counts[index, 1] / 2);
                }
            }

            return numberOfPairs;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = sockMerchant(n, ar);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}