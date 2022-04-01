using System.Collections;
using System.Diagnostics;

namespace InterviewPreparationKit.Sorting.SortingComparator
{
    class Solution
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Player[] player = new Player[n];
            Checker checker = new Checker();

            for (int i = 0; i < n; i++)
            {
                string[] playerValues = Console.ReadLine().Split(' ');

                player[i] = new Player(playerValues[0], Convert.ToInt32(playerValues[1]));
            }

            var watch = Stopwatch.StartNew();

            Array.Sort(player, checker);

            watch.Stop();

            for (int i = 0; i < player.Length; i++)
            {
                Console.WriteLine(string.Format("{0} {1}", player[i].name, player[i].score));
            }

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }

    internal class Player
    {
        public string name { get; }
        public int score { get; }

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    internal class Checker : IComparer
    {
        public int Compare(object a, object b)
        {
            var playerA = (Player)a;
            var playerB = (Player)b;

            if (playerA.score > playerB.score)
                return -1;
            else if (playerA.score < playerB.score)
                return 1;
            else
                return playerA.name.CompareTo(playerB.name);
        }
    }
}
