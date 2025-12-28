namespace BackendMastery.Persistence.Transactions.MultiStepUseCase.Domain;

/// <summary>
/// Represents a bank account.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Balance changes are sensitive
/// - Partial updates break trust
///
/// USE CASE:
/// - Money transfer
///
/// KEY RULE:
/// ❗ Balance updates must be consistent with ledger records
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