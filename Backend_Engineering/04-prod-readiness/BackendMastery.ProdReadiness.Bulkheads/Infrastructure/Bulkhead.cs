using System.Threading;

namespace BackendMastery.ProdReadiness.Bulkheads.Infrastructure;

/// <summary>
/// Implements a simple semaphore-based bulkhead.
///
/// WHY THIS EXISTS:
/// Shared thread pools allow one feature
/// to starve all others.
///
/// WHAT PROBLEM THIS SOLVES:
/// Limits concurrent execution per feature.
///
/// WHEN TO USE:
/// - Risky dependencies
/// - Slow or unpredictable operations
///
/// WHAT BREAKS IF MISUSED:
/// No isolation → global slowdowns.
/// </summary>
public sealed class Bulkhead
{
    private readonly SemaphoreSlim _semaphore;

    public Bulkhead(int maxConcurrency)
    {
        _semaphore = new SemaphoreSlim(maxConcurrency);
    }

    public async Task ExecuteAsync(
        Func<Task> action,
        CancellationToken cancellationToken)
    {
        // If we cannot enter, we fail fast
        if (!await _semaphore.WaitAsync(0, cancellationToken))
        {
            throw new InvalidOperationException(
                "Bulkhead limit reached for this feature.");
        }

        try
        {
            await action();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}