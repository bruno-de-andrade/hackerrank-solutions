using System;

namespace Interview_Preparation_Kit.Warm_up_Challenges.Counting_Valleys
{
    internal class Solution
    {
        // Complete the countingValleys function below.
        private static int countingValleys(int n, string s)
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

            int result = countingValleys(n, s);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}