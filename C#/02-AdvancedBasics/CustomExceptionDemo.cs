// Demonstrates custom exceptions
// Focus: domain-specific error handling
// Custom exceptions improve clarity and error semantics.

namespace Basics.Exceptions
{
    // Custom exception
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

    public class CustomExceptionDemo
    {
        public static int Main()
        {
            try
            {
                ValidateAge(-5);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        private static void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new InvalidAgeException("Age cannot be negative.");
            }
        }
    }
}