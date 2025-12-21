namespace Basics.TypeConversion
{
    public class Program
    {
        public static int Main()
        {
            Console.WriteLine("Enter a number:");

            string input = Console.ReadLine();

            // Safe conversion using TryParse
            if (int.TryParse(input, out int safeResult))
            {
                Console.WriteLine($"TryParse succeeded. Value = {safeResult}");
            }
            else
            {
                Console.WriteLine("TryParse failed. Invalid input.");
            }

            // Unsafe conversion using Parse (can throw exception)
            try
            {
                int riskyResult = int.Parse(input);
                Console.WriteLine($"Parse succeeded. Value = {riskyResult}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Parse failed due to invalid format.");
            }

            // Return 0 to indicate successful execution
            return 0;
        }
    }
}