using BackendMastery.ProdReadiness.Retries.Configuration;
using BackendMastery.ProdReadiness.Retries.Infrastructure;

namespace BackendMastery.ProdReadiness.Retries.Services;

/// <summary>
/// Implements controlled retry behavior with backoff.
///
/// WHY THIS EXISTS:
/// Retries must be deliberate, bounded, and delayed.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents transient failures from becoming user-visible.
///
/// WHEN TO USE:
/// Only for retry-safe operations.
///
/// WHAT BREAKS IF MISUSED:
/// Retrying unsafe writes leads to data corruption.
/// </summary>
public sealed class ReportService : IReportService
{
    private readonly UnstableReportClient _client;
    private readonly RetryOptions _options;

    public ReportService(
        UnstableReportClient client,
        RetryOptions options)
    {
        _client = client;
        _options = options;
    }

    public async Task<string> GetReportAsync(
        CancellationToken cancellationToken)
    {
        for (int attempt = 1; attempt <= _options.MaxAttempts; attempt++)
        {
            try
            {
                return await _client
                    .FetchReportAsync(cancellationToken);
            }
            catch (TimeoutException) when (attempt < _options.MaxAttempts)
            {
                // Exponential backoff:
                // Each retry waits longer to reduce pressure
                var delay = TimeSpan.FromMilliseconds(
                    _options.BaseDelayMilliseconds * attempt);

                await Task.Delay(delay, cancellationToken);
            }
        }

        // Final failure must surface
        throw new TimeoutException(
            "Report service failed after retries.");
    }
}