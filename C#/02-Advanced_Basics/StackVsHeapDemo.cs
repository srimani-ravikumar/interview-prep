// Demonstrates stack vs heap behavior
// Focus: value vs reference memory allocation
// Stack → copied
// Heap → referenced

namespace Basics.Memory
{
    public struct ValueTypeExample
    {
        public int Number;
    }

    public class ReferenceTypeExample
    {
        public int Number;
    }

    public class StackVsHeapDemo
    {
        public static int Main()
        {
            ValueTypeExample value1 = new ValueTypeExample { Number = 10 };
            ValueTypeExample value2 = value1;
            value2.Number = 20;

            Console.WriteLine($"Value1: {value1.Number}");
            Console.WriteLine($"Value2: {value2.Number}");

            ReferenceTypeExample ref1 = new ReferenceTypeExample { Number = 10 };
            ReferenceTypeExample ref2 = ref1;
            ref2.Number = 20;

            Console.WriteLine($"Ref1: {ref1.Number}");
            Console.WriteLine($"Ref2: {ref2.Number}");

            return 0;
        }
    }
}