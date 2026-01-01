namespace BackendMastery.Persistence.FailureHandling.AntiPatterns.Infrastructure;

/// <summary>
/// Simulates an unreliable persistence layer.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Dependencies fail in real life
///
/// KEY RULE:
/// ❗ How you react to failure matters more than failure itself
/// </remarks>
public class UnreliableStore
{
    public void Save(string data)
    {
        if (Random.Shared.Next(0, 2) == 0)
            throw new Exception("Disk write failed");

        Console.WriteLine($"Data persisted: {data}");
    }
}