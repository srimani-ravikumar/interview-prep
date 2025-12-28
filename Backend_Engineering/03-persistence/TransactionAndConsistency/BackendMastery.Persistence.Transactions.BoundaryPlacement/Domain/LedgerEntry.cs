namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Domain;

/// <summary>
/// Immutable ledger record.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Ledger is audit truth
/// - Cannot be partially written
///
/// KEY RULE:
/// ❗ Ledger and balance must move together
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