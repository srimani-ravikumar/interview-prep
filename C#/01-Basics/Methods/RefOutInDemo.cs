// Demonstrates ref, out, and in parameters
// Focus: how data is passed to methods
// ref → read + write
// out → write only
// in → read only (performance optimization)

namespace Basics.Methods
{
    public class RefOutInDemo
    {
        // ref requires variable to be initialized before passing
        public static void Increment(ref int number)
        {
            number++;
        }

        // out does NOT require initialization
        public static void GetDefaultValue(out int number)
        {
            number = 100;
        }

        // in passes value by reference but prevents modification
        public static void PrintValue(in int number)
        {
            Console.WriteLine($"Value received: {number}");
        }

        public static int Main()
        {
            int value = 10;
            Increment(ref value);
            Console.WriteLine($"After ref increment: {value}");

            int outValue;
            GetDefaultValue(out outValue);
            Console.WriteLine($"Value from out parameter: {outValue}");

            PrintValue(in value);

            return 0;
        }
    }
}