namespace InterviewPreparationKit.Search.Pairs
{
    class Solution
    {
        private static int Pairs(int k, int[] arr)
        {
            int pairsCount = 0,
                difference;

            Array.Sort(arr);

            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    difference = arr[i] - arr[j];

                    if (difference == k)
                    {
                        pairsCount++;
                    }
                    else if (difference > k)
                    {
                        break;
                    }
                }
            }

            return pairsCount;
        }

        private static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = Pairs(k, arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
