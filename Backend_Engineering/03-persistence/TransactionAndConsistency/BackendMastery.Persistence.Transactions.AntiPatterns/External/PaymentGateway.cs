namespace BackendMastery.Persistence.Transactions.AntiPatterns.External;

/// <summary>
/// Simulates external payment provider.
/// </summary>
/// <remarks>
/// INTUITION:
/// - External systems do not participate in DB transactions
///
/// KEY RULE:
/// ❌ You cannot roll back the outside world
/// </remarks>
public class PaymentGateway
{
    public void Charge()
    {
        Console.WriteLine("Charging customer...");
        // Payment succeeds, but DB may later roll back
    }
}