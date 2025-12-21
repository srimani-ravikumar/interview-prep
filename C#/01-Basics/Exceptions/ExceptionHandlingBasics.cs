// Demonstrates basic exception handling using try-catch-finally
// Use exceptions for exceptional cases, not control flow.

namespace Basics.Exceptions
{
    public class ExceptionHandlingBasics
    {
        public static int Main()
        {
            Console.WriteLine("Enter a number:");

            try
            {
                int number = int.Parse(Console.ReadLine());
                int result = 100 / number;

                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not allowed.");
            }
            finally
            {
                // Always executes (cleanup/logging)
                Console.WriteLine("Execution completed.");
            }

            return 0;
        }
    }
}