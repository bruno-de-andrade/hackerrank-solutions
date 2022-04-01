using System.Diagnostics;

namespace InterviewPreparationKit.DynamicProgramming.DecibinaryNumbers
{
    class Solution
    {
        const int MaxNumberOfDigits = 20;

        static readonly int[] maxValueForDigit = new int[MaxNumberOfDigits];
        static readonly List<long[]> numberOfCopiesForDigit = new List<long[]>();
        static readonly List<long> startPositionOffset = new List<long>();
        static readonly Dictionary<long, long> results = new Dictionary<long, long>(); // Position, Decibinary
        static int numberToCompute = 0;
        static long currentPosition = 0;

        static void Initialize()
        {
            // Calculate maximum possible value for each digit
            int maxValue = 0;

            for (int i = 1; i <= MaxNumberOfDigits; i++)
            {
                maxValue += 9 * (1 << i - 1); //Power i at base 2

                maxValueForDigit[i - 1] = maxValue;
            }
        }

        static long DecibinaryNumbers(long nthPosition)
        {
            // As last decimal surpassed the position we are looking for, check all posibilities for last number
            int currentDecimal = CalculateNumberOfDuplicatesUpToPosition(nthPosition);
            currentPosition = startPositionOffset[currentDecimal];

            // Gets maximum number of digits the decimal can be represented in decibinary
            int maxDigits = GetMaximumDigitsForDecimal(currentDecimal);
            int digits;

            for (digits = 1; digits <= maxDigits; digits++)
            {
                if (currentPosition + numberOfCopiesForDigit[currentDecimal][digits - 1] >= nthPosition)
                {
                    currentPosition += numberOfCopiesForDigit[currentDecimal][digits - 2 > 0 ? digits - 2 : 0];
                    break;
                }
            }

            return GetFinalDecibinary(1, currentDecimal, digits, nthPosition);
        }

        static long GetFinalDecibinary(int initialDigit, int decimalValue, int decimalPlaces, long desiredPosition)
        {
            long decibinary = 0;
            int remainingValue = 0;
            int valuePerDigit = 1 << (decimalPlaces - 1);
            int maxValueFor1LessDigit = decimalPlaces >= 2 ? maxValueForDigit[decimalPlaces - 2] : 0;

            // When number of copies for current number doesn't pass desired position, increment and return 
            if (currentPosition + GetNumberOfCopies(decimalValue, decimalPlaces) < desiredPosition)
            {
                currentPosition += GetNumberOfCopies(decimalValue, decimalPlaces);
                return 0;
            }
            
            // Set an initial value for the digit that can reach desired value
            if ((decimalValue - maxValueFor1LessDigit) / valuePerDigit > initialDigit)
                initialDigit = (decimalValue - maxValueFor1LessDigit) / valuePerDigit;

            for (int digit = initialDigit; digit < 10; digit++)
            {
                if (decimalPlaces == 1 && decimalValue < 10)
                {
                    decibinary = decimalValue;
                }
                else
                {
                    decibinary = digit * (long)Math.Pow(10, decimalPlaces - 1);

                    remainingValue = decimalValue - digit * valuePerDigit;
                }

                if (maxValueFor1LessDigit < remainingValue)
                    continue;

                if (remainingValue == 0)
                {
                    currentPosition++;

                    return decibinary;
                }

                decibinary += GetFinalDecibinary(decimalPlaces > 2 ? 0 : 1, remainingValue, decimalPlaces - 1, desiredPosition);

                if (currentPosition == desiredPosition)
                {
                    break;
                }
            }

            return decibinary;
        }

        static int GetMaximumDigitsForDecimal(long number)
        {
            int digits = 0;

            while ((1 << digits) <= number)
            {
                digits++;
            }

            return digits;
        }

        static int CalculateNumberOfDuplicatesUpToPosition(long desiredPosition)
        {
            int decimalNumber = 0;
            long currentPosition = 0;
            int remainingValue;

            if (startPositionOffset.Count > 0)
            {
                decimalNumber = startPositionOffset.Count - 1;
                currentPosition = startPositionOffset[decimalNumber];
            }

            while (currentPosition < desiredPosition)
            {
                if (decimalNumber >= numberToCompute)
                {
                    var numberOfCopies = new long[MaxNumberOfDigits];
                    numberOfCopies[0] = numberToCompute < 10 ? 1 : 0; // Only numbers in range 0-9 can be represented with 1 digit
                    numberOfCopiesForDigit.Add(numberOfCopies);

                    for (int numberOfDigits = 1; numberOfDigits < MaxNumberOfDigits; numberOfDigits++)
                    {
                        for (int digit = 0; digit < 10; digit++)
                        {
                            // Calculate if current number can be represented with specific number of digits
                            // E.g. If current number is 8 than it can be represented with 100 and 200. 100 = 4, 200 = 8
                            // remainingValue will be 8 - 4 = 4 in case of decibinary 100 or 8 - 8 = 0 in case of decibinary 200
                            remainingValue = numberToCompute - digit * (1 << numberOfDigits);

                            // Exit if using digit creates number larger than target value.
                            if (remainingValue < 0)
                                break;

                            // Adds the number of representations for the remainig value with less 1 digit
                            // E.g. for 100 and number 8 remainig will be 4. Adds number of times 4 can be represented with 2 digits
                            //numberOfCopies[numberOfDigits] += getNumberOfCopies(remainingValue, numberOfDigits);
                            numberOfCopies[numberOfDigits] += numberOfCopiesForDigit[remainingValue][numberOfDigits - 1];
                        }
                    }

                    numberToCompute = decimalNumber + 1;
                    startPositionOffset.Add(currentPosition);
                }

                currentPosition += numberOfCopiesForDigit[decimalNumber].Last();
                decimalNumber++;
            }

            return decimalNumber - 1;
        }

        static long GetNumberOfCopies(int number, int digits)
        {
            return numberOfCopiesForDigit[number][digits - 1];
        }

        static void Main(string[] args)
        {
            string[] testCase = File.ReadAllLines(@"Dynamic Programming\Decibinary Numbers\testCase7.txt");

            int q = Convert.ToInt32(testCase[0]);
            long[] values = new long[q];
            long[] sorted = new long[q];

            var watch = Stopwatch.StartNew();

            for (int index = 1; index < testCase.Length; index++)
            {
                values[index - 1] = Convert.ToInt64(testCase[index]);
            }

            Array.Copy(values, sorted, values.Length);
            Array.Sort(sorted);

            Initialize();

            // Calculate the decibinaries sorted to be faster
            for (int index = 0; index < q; index++)
            {
                results[sorted[index]] = DecibinaryNumbers(sorted[index]);
            }

            watch.Stop();

            // Write the results in the same order of the inputed values
            for (int index = 0; index < q; index++)
            {
                Console.WriteLine(results[values[index]]);
            }

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}
