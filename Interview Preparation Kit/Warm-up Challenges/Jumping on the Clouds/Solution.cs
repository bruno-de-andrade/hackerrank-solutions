using System;

namespace Interview_Preparation_Kit.Warm_up_Challenges.Jumping_on_the_Clouds
{
    internal class Solution
    {
        // Complete the jumpingOnClouds function below.
        private static int jumpingOnClouds(int[] c)
        {
            int index = 0,
                jumps = 0;

            while (index < c.Length - 1)
            {
                if ((index + 2) < c.Length && c[index + 2] == 0)
                {
                    index += 2;
                }
                else
                {
                    index++;
                }

                jumps++;
            }

            return jumps;
        }

        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = jumpingOnClouds(c);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}