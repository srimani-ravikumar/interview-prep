using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Domain;

namespace BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Infrastructure;

/// <summary>
/// Simulates a distributed account store.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Network partitions happen
/// - Data may be unreachable
///
/// KEY RULE:
/// ❗ Failures force a consistency vs availability choice
/// </remarks>
public class AccountStore
{
    private readonly Dictionary<string, Account> _accounts = new();

    public void Add(Account account) => _accounts[account.AccountId] = account;

    public Account GetStrong(string accountId)
    {
        // Simulate partition
        if (Random.Shared.Next(0, 3) == 0)
            throw new Exception("Partition: cannot guarantee consistency");

        return _accounts[accountId];
    }

    public Account GetEventuallyConsistent(string accountId)
    {
        // Always returns, may be stale
        Console.WriteLine("⚠️ Returning potentially stale data");
        return _accounts[accountId];
    }
}