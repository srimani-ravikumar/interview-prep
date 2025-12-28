using BackendMastery.Persistence.ORM.QueryShaping.Domain;
using BackendMastery.Persistence.ORM.QueryShaping.ReadModels;

namespace BackendMastery.Persistence.ORM.QueryShaping.Infrastructure;

/// <summary>
/// Simulates query shaping behavior.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Entities load everything
/// - Projections load only required data
///
/// KEY RULE:
/// ❗ Shape data at the query boundary
/// </remarks>
public class FakeDbContext
{
    public Customer LoadFullCustomer(int id)
    {
        Console.WriteLine("SELECT * FROM Customers");
        return new Customer(
            id,
            "Alice",
            "alice@mail.com",
            "123 Long Address, Some City",
            DateTime.UtcNow.AddYears(-2));
    }

    public CustomerSummary LoadCustomerSummary(int id)
    {
        Console.WriteLine("SELECT Id, Name FROM Customers");
        return new CustomerSummary(id, "Alice");
    }
}