using BackendMastery.Persistence.ORM.ContextLifecycle.Domain;

namespace BackendMastery.Persistence.ORM.ContextLifecycle.Infrastructure;

/// <summary>
/// Simulates an ORM persistence context.
/// </summary>
/// <remarks>
/// INTUITION:
/// - A persistence context is NOT a database
/// - It is an in-memory session that:
///   - Tracks identity
///   - Controls object lifetime
///
/// USE CASE:
/// - One context per request
/// - One unit of work
///
/// KEY RULE:
/// ❗ One database row = one object PER CONTEXT
/// </remarks>
public class FakeDbContext
{
    // Identity Map: ensures same ID -> same object
    private readonly Dictionary<int, User> _identityMap = new();

    public User GetUserById(int id)
    {
        // If already loaded in this context, return same instance
        if (_identityMap.TryGetValue(id, out var cachedUser))
        {
            Console.WriteLine("Returning cached User instance");
            return cachedUser;
        }

        // Simulate database fetch
        Console.WriteLine("Fetching User from database");
        var userFromDb = new User(id, "Alice");

        _identityMap[id] = userFromDb;
        return userFromDb;
    }
}