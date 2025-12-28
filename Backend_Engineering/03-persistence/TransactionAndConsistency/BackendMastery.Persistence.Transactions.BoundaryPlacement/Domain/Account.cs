namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Domain;

/// <summary>
/// Represents a bank account.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Balance must reflect real money
/// - Any partial update destroys trust
///
/// USE CASE:
/// - Money transfer
///
/// KEY RULE:
/// ❗ Balance updates must be consistent with ledger entries
/// </remarks>
public class Account
{
    public Guid Id { get; } = Guid.NewGuid();
    public decimal Balance { get; private set; }

    public Account(decimal balance)
    {
        Balance = balance;
    }

    public void Debit(decimal amount)
    {
        Balance -= amount;
    }
}