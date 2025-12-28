namespace BackendMastery.Persistence.Transactions.SingleOperation.Domain;

/// <summary>
/// Represents a bank account.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This looks innocent: just one write
/// - But even a single write must be atomic
///
/// USE CASE:
/// - Creating a user account
/// - Opening a bank account
///
/// KEY RULE:
/// ❗ Even the simplest write must either fully succeed or not exist
/// </remarks>
public class Account
{
    public Guid Id { get; } = Guid.NewGuid();
    public decimal Balance { get; private set; }

    public Account(decimal initialBalance)
    {
        Balance = initialBalance;
    }
}