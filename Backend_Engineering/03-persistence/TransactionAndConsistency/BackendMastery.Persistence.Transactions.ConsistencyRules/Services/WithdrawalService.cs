using BackendMastery.Persistence.Transactions.ConsistencyRules.Domain;
using BackendMastery.Persistence.Transactions.ConsistencyRules.Infrastructure;

namespace BackendMastery.Persistence.Transactions.ConsistencyRules.Services;

/// <summary>
/// Handles withdrawal use case.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Transaction ensures atomicity
/// - Business rules ensure correctness
///
/// USE CASE:
/// - ATM withdrawal
///
/// KEY RULE:
/// ❗ Business invariants must be checked BEFORE persistence
/// </remarks>
public class WithdrawalService
{
    private readonly FakeDatabase _db = new();

    public void Withdraw(Account account, decimal amount)
    {
        _db.BeginTransaction();

        try
        {
            // ✅ Business invariant enforced here
            account.Withdraw(amount);

            _db.Save("Account");
            _db.Save("LedgerEntry");

            _db.Commit();
        }
        catch
        {
            _db.Rollback();
            throw;
        }
    }
}