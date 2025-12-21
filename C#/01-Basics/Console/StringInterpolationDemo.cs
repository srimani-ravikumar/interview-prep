namespace Basics.Strings
{
    public class Program
    {
        public static int Main()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your city:");
            string city = Console.ReadLine();

            int year = DateTime.Now.Year;

            // String interpolation using $
            Console.WriteLine($"Hello {name}, welcome from {city}.");
            Console.WriteLine($"Current year is {year}.");

            // Return 0 to indicate successful execution
            return 0;
        }
    }
}