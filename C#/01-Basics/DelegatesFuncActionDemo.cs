// Demonstrates delegates, Func, and Action
// Focus: method references and callbacks
// Func → returns value
// Action → void
// Both are built on delegates.

namespace Basics.Delegates
{
    // Custom delegate
    public delegate int MathOperation(int a, int b);

    public class DelegatesFuncActionDemo
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Main()
        {
            // Using custom delegate
            MathOperation operation = Add;
            Console.WriteLine(operation(5, 3));

            // Func delegate (returns value)
            Func<int, int, int> multiply = (a, b) => a * b;
            Console.WriteLine(multiply(4, 5));

            // Action delegate (no return)
            Action<string> print = message => Console.WriteLine(message);
            print("Hello from Action");

            return 0;
        }
    }
}