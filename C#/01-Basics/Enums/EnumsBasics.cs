// Demonstrates enum usage
// Focus: replacing magic numbers with meaningful names
// Enums improve readability, type safety, and maintainability.

namespace Basics.Enums
{
    // Enum represents a fixed set of named constants
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4
    }

    public class EnumsBasics
    {
        public static int Main()
        {
            OrderStatus status = OrderStatus.Processing;

            Console.WriteLine($"Current order status: {status}");

            // Enum to int conversion
            int statusCode = (int)status;
            Console.WriteLine($"Status code: {statusCode}");

            // int to enum conversion
            OrderStatus convertedStatus = (OrderStatus)3;
            Console.WriteLine($"Converted status: {convertedStatus}");

            return 0;
        }
    }
}