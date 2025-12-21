// Demonstrates Interface Segregation Principle (ISP)
// Focus: small, specific interfaces
// Clients should not depend on methods they don’t use
// Avoid fat interfaces — split them.

namespace Basics.SOLID
{
    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    // Simple printer only prints
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }
    }

    // Advanced printer supports both
    public class AdvancedPrinter : IPrinter, IScanner
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }
    }

    public class SOLIDInterfaceSegregationDemo
    {
        public static int Main()
        {
            IPrinter printer = new BasicPrinter();
            printer.Print();

            return 0;
        }
    }
}