// Demonstrates properties and init-only setters
// Focus: encapsulation and immutability
// init → assign once, safer than set.

namespace Basics.Classes
{
    public class Employee
    {
        // Auto-property
        public int Id { get; init; }      // init-only (C# 9+)
        public string Name { get; set; }  // read/write property
    }

    public class PropertiesAndInitOnly
    {
        public static int Main()
        {
            Employee emp = new Employee
            {
                Id = 101,          // allowed only during initialization
                Name = "Alice"
            };

            emp.Name = "Alice Smith";
            // emp.Id = 102; ❌ compile-time error

            Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}");

            return 0;
        }
    }
}