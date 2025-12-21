// Demonstrates difference between struct and class
// Focus: value type vs reference type behavior
// Struct → copied by value
// Class → copied by reference

namespace Basics.Types
{
    // Struct = value type (stored on stack in most cases)
    public struct PointStruct
    {
        public int X;
    }

    // Class = reference type (stored on heap)
    public class PointClass
    {
        public int X;
    }

    public class StructVsClassDemo
    {
        public static int Main()
        {
            PointStruct structPoint = new PointStruct { X = 10 };
            PointStruct copiedStruct = structPoint;
            copiedStruct.X = 20;

            Console.WriteLine($"Struct original X: {structPoint.X}");
            Console.WriteLine($"Struct copy X: {copiedStruct.X}");

            PointClass classPoint = new PointClass { X = 10 };
            PointClass copiedClass = classPoint;
            copiedClass.X = 20;

            Console.WriteLine($"Class original X: {classPoint.X}");
            Console.WriteLine($"Class copy X: {copiedClass.X}");

            return 0;
        }
    }
}