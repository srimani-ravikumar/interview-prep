namespace BackendMastery.Persistence.Transactions.ConsistencyRules.Domain;

/// <summary>
/// Immutable audit record.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Ledger must reflect valid business actions only
///
/// KEY RULE:
/// ❗ Invalid business operations must never reach the ledger
/// </remarks>
public class LedgerEntry
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid AccountId { get; }
    public decimal Amount { get; }

    public LedgerEntry(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}