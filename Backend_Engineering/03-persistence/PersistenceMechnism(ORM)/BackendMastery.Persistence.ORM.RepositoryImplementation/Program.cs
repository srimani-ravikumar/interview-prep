using BackendMastery.Persistence.ORM.RepositoryImplementation.Application;
using BackendMastery.Persistence.ORM.RepositoryImplementation.Infrastructure;

namespace BackendMastery.Persistence.ORM.RepositoryImplementation;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Repository Pattern Demo ===\n");

        var repository = new OrderRepository();
        var service = new OrderService(repository);

        service.PayOrder(1);

        Console.WriteLine("\n=== Demo Complete ===");
    }
}