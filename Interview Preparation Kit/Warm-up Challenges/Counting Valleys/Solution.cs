namespace InterviewPreparationKit.WarmUpChallenges.CountingValleys
{
    class Solution
    {
        // Complete the countingValleys function below.
        private static int CountingValleys(int n, string s)
        {
            int position = 0,
                numberOfValleys = 0;
            bool enteredValley = false;

            for (int index = 0; index < s.Length; index++)
            {
                position = s[index] == 'D' ? position - 1 : position + 1;

                if (position < 0 && !enteredValley)
                { 
                    enteredValley = true;
                }
                else if (position == 0 && enteredValley)
                {
                    enteredValley = false;
                    numberOfValleys++;
                }
            }

            return numberOfValleys;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = CountingValleys(n, s);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}