// Demonstrates static vs instance members
// Focus: shared vs per-object behavior
// Static → shared memory
// Instance → object-specific state

namespace Basics.Classes
{
    public class Counter
    {
        // Static field shared across all instances
        public static int StaticCount = 0;

        // Instance field belongs to each object
        public int InstanceCount = 0;

        public void Increment()
        {
            StaticCount++;
            InstanceCount++;
        }
    }

    public class StaticVsInstanceDemo
    {
        public static int Main()
        {
            Counter counter1 = new Counter();
            Counter counter2 = new Counter();

            counter1.Increment();
            counter2.Increment();

            Console.WriteLine($"Static Count: {Counter.StaticCount}");
            Console.WriteLine($"Counter1 Instance Count: {counter1.InstanceCount}");
            Console.WriteLine($"Counter2 Instance Count: {counter2.InstanceCount}");

            return 0;
        }
    }
}