// Demonstrates LINQ GroupBy and Join
// Focus: data shaping and querying
// GroupBy → aggregation
// Join → relational thinking

namespace Basics.Linq
{
    public class LINQGroupByAndJoin
    {
        public static int Main()
        {
            var employees = new List<(int Id, string Name, int DeptId)>
            {
                (1, "Alice", 1),
                (2, "Bob", 2),
                (3, "Charlie", 1)
            };

            var departments = new List<(int Id, string Name)>
            {
                (1, "IT"),
                (2, "HR")
            };

            // GroupBy example
            var grouped = employees.GroupBy(e => e.DeptId);

            Console.WriteLine("Employees grouped by department:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Department Id: {group.Key}");
                foreach (var emp in group)
                {
                    Console.WriteLine(emp.Name);
                }
            }

            // Join example
            var joined =
                from emp in employees
                join dept in departments
                on emp.DeptId equals dept.Id
                select new { emp.Name, Department = dept.Name };

            Console.WriteLine("\nEmployee with departments:");
            foreach (var item in joined)
            {
                Console.WriteLine($"{item.Name} - {item.Department}");
            }

            return 0;
        }
    }
}