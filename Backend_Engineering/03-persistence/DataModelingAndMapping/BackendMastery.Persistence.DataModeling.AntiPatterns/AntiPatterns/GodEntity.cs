namespace BackendMastery.Persistence.DataModeling.AntiPatterns;

/// <summary>
/// ❌ ANTI-PATTERN: God Entity
/// </summary>
/// <remarks>
/// INTUITION:
/// - One object "knows everything"
/// - Feels convenient initially
///
/// USE CASE (WRONG):
/// - Rapid prototyping that never refactors
/// - "Put everything in Order"
///
/// WHY THIS IS BAD:
/// - Violates Single Responsibility
/// - Hard to change
/// - Hard to test
///
/// KEY RULE:
/// ❗ If one class handles everything, it will eventually break everything.
/// </remarks>
public class Order
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }

    // Pricing logic
    public void ApplyDiscount(decimal discount)
    {
        Amount -= discount;
    }

    // Persistence logic ❌
    public void SaveToDatabase()
    {
        Console.WriteLine("Saving order...");
    }

    // Reporting logic ❌
    public string GenerateInvoice()
    {
        return $"Invoice for {Amount}";
    }

    // Integration logic ❌
    public void SendEmail()
    {
        Console.WriteLine("Sending email...");
    }
}
