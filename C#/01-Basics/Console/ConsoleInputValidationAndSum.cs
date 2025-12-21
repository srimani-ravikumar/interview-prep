// Namespace follows folder-based structure for a learning repository.
// "Basics" → foundational concepts
// "Console" → console input/output programs
namespace Basics.Console
{
    // Utility class that contains math-related operations.
    // Marked static because it holds only behavior, no state.
    public static class Calculator
    {
        // Expression-bodied method for readability and conciseness.
        // Returns the sum of two integers.
        public static int Sum(int number1, int number2) => number1 + number2;
    }

    // Entry class for demonstrating console input validation and summation.
    // Class name reflects the purpose of this program.
    public class ConsoleInputValidationAndSum
    {
        // Application entry point.
        // Returns an integer exit code (0 = successful execution).
        public static int Main()
        {
            int firstNumber;
            int secondNumber;

            // Loop until valid numeric input is entered for the first number
            while (true)
            {
                Console.WriteLine("Enter the value for Number 1:");
                string input = Console.ReadLine();

                // TryParse safely converts string to int without throwing exceptions
                if (int.TryParse(input, out firstNumber))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

            // Loop until valid numeric input is entered for the second number
            while (true)
            {
                Console.WriteLine("Enter the value for Number 2:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out secondNumber))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

            // Perform the addition using the Calculator utility class
            int sum = Calculator.Sum(firstNumber, secondNumber);

            // Display the result using string interpolation
            Console.WriteLine(
                $"Sum of two numbers {firstNumber} and {secondNumber} is {sum}"
            );

            // Return 0 to indicate successful execution
            return 0;
        }
    }
}