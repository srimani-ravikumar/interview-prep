// Demonstrates different types of constructors
// Focus: default, parameterized, static constructors
// Static constructor → runs once, cannot be called explicitly.

namespace Basics.Classes
{
    public class Person
    {
        public string Name;
        public int Age;

        // Default constructor
        public Person()
        {
            Name = "Unknown";
            Age = 0;
        }

        // Parameterized constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Static constructor
        // Executes ONCE per type before first usage
        static Person()
        {
            Console.WriteLine("Static constructor executed.");
        }
    }

    public class ConstructorTypesDemo
    {
        public static int Main()
        {
            Person p1 = new Person();
            Person p2 = new Person("Srimani", 25);

            Console.WriteLine($"{p1.Name}, {p1.Age}");
            Console.WriteLine($"{p2.Name}, {p2.Age}");

            return 0;
        }
    }
}