namespace BackendMastery.Architecture.DependencyInjection.Infrastructure;

/// <summary>
/// System abstraction for time.
/// </summary>
/// <remarks>
/// Intuition:
/// - Time is a dependency.
/// - Hard-coding DateTime.UtcNow makes code untestable.
///
/// Use case:
/// - Deterministic unit tests
/// - Time-based logic
/// </remarks>
public interface ISystemClock
{
    DateTime UtcNow { get; }
}

public class SystemClock : ISystemClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}