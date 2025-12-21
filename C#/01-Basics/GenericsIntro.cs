// Demonstrates generics
// Focus: type safety and reusability
// Generics avoid casting and runtime type errors.

namespace Basics.Generics
{
    public class DataStore<T>
    {
        public T Value { get; set; }
    }

    public class GenericsIntro
    {
        public static int Main()
        {
            DataStore<int> intStore = new DataStore<int>();
            intStore.Value = 100;

            DataStore<string> stringStore = new DataStore<string>();
            stringStore.Value = "Hello Generics";

            Console.WriteLine(intStore.Value);
            Console.WriteLine(stringStore.Value);

            return 0;
        }
    }
}