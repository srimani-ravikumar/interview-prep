namespace BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Domain;

/// <summary>
/// Represents a bank account.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Balances must be correct
/// - Wrong balance = legal + financial issues
///
/// USE CASE:
/// - Banking
/// - Wallets
///
/// KEY RULE:
/// ❗ Strong invariants demand strong consistency
/// </remarks>
public class Account
{
    public string AccountId { get; }
    public decimal Balance { get; private set; }

    public Account(string accountId, decimal balance)
    {
        AccountId = accountId;
        Balance = balance;
    }

    public void Debit(decimal amount)
    {
        if (Balance < amount)
            throw new InvalidOperationException("Insufficient balance");

        Balance -= amount;
    }
}