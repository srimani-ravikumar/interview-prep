namespace BackendMastery.Persistence.Transactions.Idempotency.Domain;

/// <summary>
/// Represents an order creation.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Order creation is irreversible
/// - Duplicates cause real damage
///
/// USE CASE:
/// - Checkout
/// - Purchase confirmation
///
/// KEY RULE:
/// ❗ Irreversible writes must be idempotent
/// </remarks>
public class Order
{
    public Guid OrderId { get; } = Guid.NewGuid();
    public decimal Amount { get; }

    public Order(decimal amount)
    {
        Amount = amount;
    }
}