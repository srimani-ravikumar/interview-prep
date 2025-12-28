using BackendMastery.Persistence.Transactions.SingleOperation.Domain;
using BackendMastery.Persistence.Transactions.SingleOperation.Infrastructure;

namespace BackendMastery.Persistence.Transactions.SingleOperation.Services;

/// <summary>
/// Handles account creation.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Developer thinks: "It's just one save"
/// - Reality: implicit transaction protects correctness
///
/// USE CASE:
/// - Register user
/// - Create account
///
/// KEY RULE:
/// ❗ Even one operation has transactional semantics
/// </remarks>
public class AccountService
{
    private readonly FakeDatabase _database = new();

    public void CreateAccount(decimal initialBalance)
    {
        var account = new Account(initialBalance);

        // Developer does NOT think about transactions here
        _database.Save(account);
    }
}