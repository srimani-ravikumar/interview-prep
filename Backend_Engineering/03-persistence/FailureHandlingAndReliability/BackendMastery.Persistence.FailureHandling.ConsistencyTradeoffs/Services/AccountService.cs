using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Domain;
using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Services;

/// <summary>
/// Demonstrates consistency vs availability decisions.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Same data, different guarantees
///
/// KEY RULE:
/// ❗ The choice must be explicit
/// </remarks>
public class AccountService
{
    private readonly AccountStore _store;

    public AccountService(AccountStore store)
    {
        _store = store;
    }

    public void ShowBalance_StrongConsistency(string accountId)
    {
        Console.WriteLine("Mode: STRONG CONSISTENCY");

        var account = _store.GetStrong(accountId);
        Console.WriteLine($"Balance: {account.Balance}");
    }

    public void ShowBalance_HighAvailability(string accountId)
    {
        Console.WriteLine("Mode: HIGH AVAILABILITY");

        var account = _store.GetEventuallyConsistent(accountId);
        Console.WriteLine($"Balance (maybe stale): {account.Balance}");
    }
}