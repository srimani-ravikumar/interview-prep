namespace BackendMastery.Persistence.FailureHandling.Compensation.Infrastructure;

/// <summary>
/// Simulates an external payment gateway.
/// </summary>
/// <remarks>
/// INTUITION:
/// - External systems cannot be rolled back
/// - Money once charged is gone
///
/// KEY RULE:
/// ❗ External side effects are irreversible
/// </remarks>
public class PaymentGateway
{
    public void Charge(decimal amount)
    {
        Console.WriteLine($"Payment charged: {amount}");

        // Simulate success (money already moved)
    }

    public void Refund(decimal amount)
    {
        Console.WriteLine($"COMPENSATION: Payment refunded: {amount}");
    }
}