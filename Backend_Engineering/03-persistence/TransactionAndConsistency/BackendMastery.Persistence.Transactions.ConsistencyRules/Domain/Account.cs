namespace BackendMastery.Persistence.Transactions.ConsistencyRules.Domain;

/// <summary>
/// Represents a bank account with business invariants.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Balance represents real money
/// - Negative balance may be forbidden by business
///
/// USE CASE:
/// - Withdraw money
///
/// KEY RULE:
/// ❗ Balance must never go below zero
/// </remarks>
public class Account
{
    public Guid Id { get; } = Guid.NewGuid();
    public decimal Balance { get; private set; }

    public Account(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        // 🧠 Business invariant enforcement
        if (amount > Balance)
        {
            throw new InvalidOperationException(
                "Withdrawal denied: insufficient balance");
        }

        Balance -= amount;
    }
}