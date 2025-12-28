using BackendMastery.Persistence.ORM.ContextLifecycle.Infrastructure;

namespace BackendMastery.Persistence.ORM.ContextLifecycle;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Persistence Context Lifecycle Demo ===\n");

        Console.WriteLine("---- Same Context ----");
        var context1 = new FakeDbContext();

        var userA1 = context1.GetUserById(1);
        var userA2 = context1.GetUserById(1);

        Console.WriteLine($"Same instance? {ReferenceEquals(userA1, userA2)}");

        Console.WriteLine("\n---- Different Context ----");
        var context2 = new FakeDbContext();

        var userB1 = context2.GetUserById(1);

        Console.WriteLine($"Same instance across contexts? {ReferenceEquals(userA1, userB1)}");

        Console.WriteLine("\n=== Demo Complete ===");
    }
}