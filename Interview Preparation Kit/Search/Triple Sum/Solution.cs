using System;
using System.Diagnostics;
using System.Linq;

namespace Interview_Preparation_Kit.Search.Triple_Sum
{
    internal class Solution
    {
        // Complete the triplets function below.
        private static long triplets(int[] a, int[] b, int[] c)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            a = a.Distinct().ToArray();
            b = b.Distinct().ToArray();
            c = c.Distinct().ToArray();

            int lastIndexA = a.Length - 1, lastIndexC = c.Length - 1;
            long total = 0;

            for (int indexB = b.Length - 1; indexB >= 0; indexB--)
            {
                for (int indexA = lastIndexA; indexA >= 0; indexA--)
                {
                    if (a[indexA] <= b[indexB])
                    {
                        lastIndexA = indexA;
                        break;
                    }
                }

                for (int indexC = lastIndexC; indexC >= 0; indexC--)
                {
                    if (c[indexC] <= b[indexB])
                    {
                        lastIndexC = indexC;
                        total += (long)(lastIndexA + 1) * (lastIndexC + 1);
                        break;
                    }
                }
            }

            return total;
        }

        private static void Main(string[] args)
        {
            string[] lenaLenbLenc = Console.ReadLine().Split(' ');

            int lena = Convert.ToInt32(lenaLenbLenc[0]);

            int lenb = Convert.ToInt32(lenaLenbLenc[1]);

            int lenc = Convert.ToInt32(lenaLenbLenc[2]);

            int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp));

            int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp));

            int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp));

            var watch = Stopwatch.StartNew();

            long ans = triplets(arra, arrb, arrc);

            watch.Stop();

            Console.WriteLine(ans);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
