namespace Basics.IfElse
{
    public class Program
    {
        public static int Main()
        {
            int age;

            while (true)
            {
                Console.WriteLine("Enter your age:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out age))
                {
                    break;
                }

                Console.WriteLine("Please enter a valid numeric age.");
            }

            // Basic if-else decision making
            if (age < 18)
            {
                Console.WriteLine("You are a minor.");
            }
            else if (age >= 18 && age < 60)
            {
                Console.WriteLine("You are an adult.");
            }
            else
            {
                Console.WriteLine("You are a senior citizen.");
            }

            // Return 0 to indicate successful execution
            return 0;
        }
    }
}