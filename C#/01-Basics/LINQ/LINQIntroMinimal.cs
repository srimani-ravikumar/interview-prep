// Minimal LINQ introduction
// Focus: Select, Where, deferred execution
// LINQ uses deferred execution until enumeration.

namespace Basics.Linq
{
    public class LINQIntroMinimal
    {
        public static int Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // LINQ query with deferred execution
            IEnumerable<int> evenNumbers =
                numbers.Where(n => n % 2 == 0);

            Console.WriteLine("Even numbers:");

            // Query executes here
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }

            return 0;
        }
    }
}