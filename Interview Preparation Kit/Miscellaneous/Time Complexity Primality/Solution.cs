using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Miscellaneous.Time_Complexity_Primality
{
    class Solution
    {
        const string IsPrime = "Prime";
        const string IsNotPrime = "Not prime";

        static string primality(int number)
        {
            // 2 is the only even prime number
            if (number == 2)
                return IsPrime;

            // If number is even or sum of digits is multiple of 3, number is not prime
            if (number < 2 || number % 2 == 0 || getDigitsSum(number) % 3 == 0)
                return IsNotPrime;

            int maxNumberToCheck = (int)Math.Sqrt(number); // Check all numbers up to the square root of the number to evaluate

            for (int numberToCheck = 3; numberToCheck <= maxNumberToCheck; numberToCheck += 2) // Add 2 to skip even numbers
            {
                if (number % numberToCheck == 0)
                    return IsNotPrime;
            }

            return IsPrime;
        }

        static int getDigitsSum(int number)
        {
            string numberToString = number.ToString();
            int sum = 0;

            for (int i = 0; i < numberToString.Length; i++)
            {
                sum += Convert.ToInt32(char.GetNumericValue(numberToString[i]));
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int p = Convert.ToInt32(Console.ReadLine());

            for (int pItr = 0; pItr < p; pItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                var watch = Stopwatch.StartNew();

                string result = primality(n);

                watch.Stop();

                Console.WriteLine(result);
                Console.WriteLine($"Elapsed time: {watch.Elapsed.TotalSeconds} seconds");
            }

            Console.ReadKey();
        }
    }
}
