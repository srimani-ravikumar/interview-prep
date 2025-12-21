// Demonstrates methods with parameters and return values
// Methods encapsulate behavior and improve reuse.

namespace Basics.Methods
{
    public class MethodsWithParamsAndReturn
    {
        // Method with parameters and return type
        public static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public static int Main()
        {
            Console.WriteLine("Enter first number:");
            int.TryParse(Console.ReadLine(), out int num1);

            Console.WriteLine("Enter second number:");
            int.TryParse(Console.ReadLine(), out int num2);

            int result = Multiply(num1, num2);

            Console.WriteLine($"Result of multiplication is {result}");

            return 0;
        }
    }
}