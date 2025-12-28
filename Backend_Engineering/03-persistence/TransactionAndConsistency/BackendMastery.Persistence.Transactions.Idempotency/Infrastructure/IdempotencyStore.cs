namespace BackendMastery.Persistence.Transactions.Idempotency.Infrastructure;

/// <summary>
/// Stores processed request identifiers.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Idempotency is not logic
/// - It is DATA
///
/// USE CASE:
/// - Retry after timeout
/// - Message re-delivery
///
/// KEY RULE:
/// ❗ Idempotency check must happen BEFORE transaction execution
/// </remarks>
public class IdempotencyStore
{
    private readonly HashSet<string> _processedKeys = new();

    public bool Exists(string key)
    {
        return _processedKeys.Contains(key);
    }

    public void Save(string key)
    {
        _processedKeys.Add(key);
    }
}