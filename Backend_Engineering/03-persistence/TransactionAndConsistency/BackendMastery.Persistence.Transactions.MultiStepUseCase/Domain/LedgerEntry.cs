namespace BackendMastery.Persistence.Transactions.MultiStepUseCase.Domain;

/// <summary>
/// Immutable ledger record.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Ledger is source of truth
/// - Once written, it cannot be undone
///
/// USE CASE:
/// - Audit trail
/// - Financial reporting
///
/// KEY RULE:
/// ❗ Ledger and balance must agree
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