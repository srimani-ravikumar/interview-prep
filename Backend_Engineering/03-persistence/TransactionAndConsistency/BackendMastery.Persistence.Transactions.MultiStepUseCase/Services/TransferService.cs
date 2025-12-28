using BackendMastery.Persistence.Transactions.MultiStepUseCase.Domain;
using BackendMastery.Persistence.Transactions.MultiStepUseCase.Infrastructure;

namespace BackendMastery.Persistence.Transactions.MultiStepUseCase.Services;

/// <summary>
/// Handles money transfer use case.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This is ONE business action
/// - But it has MULTIPLE writes
///
/// USE CASE:
/// - Transfer money
///
/// KEY RULE:
/// ❗ Transaction boundary must live at the use-case level
/// </remarks>
public class TransferService
{
    private readonly FakeDatabase _db = new();

    public void Transfer(Account account, decimal amount)
    {
        _db.BeginTransaction();

        try
        {
            // Step 1: Update balance
            account.Debit(amount);
            _db.Save("Account");

            // Step 2: Write ledger
            var ledger = new LedgerEntry(account.Id, amount);
            _db.Save("LedgerEntry");

            // Uncomment to simulate failure AFTER first write
            // throw new Exception("Ledger service unavailable");

            _db.Commit();
        }
        catch
        {
            _db.Rollback();
            throw;
        }
    }
}