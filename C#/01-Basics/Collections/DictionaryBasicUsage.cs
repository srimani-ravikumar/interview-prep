// Demonstrates basic Dictionary<TKey, TValue> usage
// Focus: key-value storage and lookup
// Dictionary → O(1) average lookup using hashing

namespace Basics.Collections
{
    public class DictionaryBasicUsage
    {
        public static int Main()
        {
            // Dictionary stores data as key-value pairs
            Dictionary<int, string> employees = new Dictionary<int, string>();

            employees.Add(101, "Alice");
            employees.Add(102, "Bob");
            employees.Add(103, "Charlie");

            Console.WriteLine("Employee List:");

            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine($"Id: {employee.Key}, Name: {employee.Value}");
            }

            // Safe lookup using ContainsKey
            int searchId = 102;

            if (employees.ContainsKey(searchId))
            {
                Console.WriteLine($"\nEmployee found: {employees[searchId]}");
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }

            return 0;
        }
    }
}