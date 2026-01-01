namespace BackendMastery.Persistence.FailureHandling.Compensation.Infrastructure;

/// <summary>
/// Records compensating actions.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Compensation must be auditable
/// - Silent undo is dangerous
///
/// KEY RULE:
/// ❗ Compensation must be explicit and traceable
/// </remarks>
public static class CompensationLog
{
    public static void Record(string message)
    {
        Console.WriteLine($"[COMPENSATION LOG] {message}");
    }
}