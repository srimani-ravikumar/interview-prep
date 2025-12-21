// Demonstrates indexers
// Focus: accessing objects like arrays
// Indexers enable obj[index] syntax.

namespace Basics.Classes
{
    public class ScoreBoard
    {
        private int[] scores = new int[5];

        // Indexer definition
        public int this[int index]
        {
            get { return scores[index]; }
            set { scores[index] = value; }
        }
    }

    public class IndexersDemo
    {
        public static int Main()
        {
            ScoreBoard board = new ScoreBoard();

            board[0] = 95;
            board[1] = 88;

            Console.WriteLine($"Score 1: {board[0]}");
            Console.WriteLine($"Score 2: {board[1]}");

            return 0;
        }
    }
}