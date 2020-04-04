using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Preparation_Kit.Dynamic_Programming.Decibinary_Numbers
{
    class Solution
    {
        static Dictionary<long, int> dic = new Dictionary<long, int>();

        static long decibinaryToDecimal(string decibinary)
        {
            long decimalNumber = 0;

            for (int i = 0; i < decibinary.Length; i++)
            {
                decimalNumber += (long)(char.GetNumericValue(decibinary[i]) * Math.Pow(2, decibinary.Length - i - 1));
            }

            dic.TryGetValue(decimalNumber, out int numberOfTimes);
            dic[decimalNumber] = numberOfTimes + 1;

            return decimalNumber;
        }

        static int calcNumberTimesNumber(int number)
        {
            int min = 0, max = 0;

            return 0;
        }

        static long decibinaryNumbers(long x)
        {
            for (int i = 0; i <= x; i += 1)
            {
                var decimalNum = decibinaryToDecimal(i.ToString());

                //if (i % 10 == 0)
                //{
                //    Console.WriteLine(string.Format("Decibinary: {0}; Decimal: {1}", i, decimalNum));
                //}
            }

            foreach (var item in dic)
            {
                Console.WriteLine(string.Format("Number: {0}; Time: {1}", item.Key, item.Value));
            }

            return 1;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long x = Convert.ToInt64(Console.ReadLine());

                long result = decibinaryNumbers(x);

                Console.WriteLine(result);
            }

            //Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
