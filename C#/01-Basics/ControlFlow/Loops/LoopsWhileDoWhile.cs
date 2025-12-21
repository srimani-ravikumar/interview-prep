namespace Basics.Loops
{
    public class Program
    {
        public static int Main()
        {
            int counter = 1;

            // while loop: condition checked BEFORE execution
            Console.WriteLine("While loop output:");
            while (counter <= 5)
            {
                Console.WriteLine($"Counter value: {counter}");
                counter++;
            }

            // do-while loop: executes AT LEAST ONCE
            int number;
            do
            {
                Console.WriteLine("Enter a number greater than 10:");
                string input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number) || number <= 10);

            Console.WriteLine("Valid number entered.");

            // Return 0 to indicate successful execution
            return 0;
        }
    }
}