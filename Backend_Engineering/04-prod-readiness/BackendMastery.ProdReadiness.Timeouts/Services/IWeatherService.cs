namespace BackendMastery.ProdReadiness.Timeouts.Services;

/// <summary>
/// Defines the business-level contract for retrieving weather data.
///
/// WHY THIS EXISTS:
/// Interfaces enforce clear ownership boundaries.
/// Controllers depend on WHAT is needed, not HOW it is achieved.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents infrastructure and resilience concerns
/// from leaking into the HTTP layer.
///
/// WHEN TO USE:
/// - Whenever business logic coordinates one or more dependencies
/// - Whenever resilience policies (timeouts, retries, breakers)
///   must be enforced consistently
///
/// WHAT BREAKS IF MISUSED:
/// - Controllers become tightly coupled to implementations
/// - Resilience logic gets duplicated or bypassed
/// - Testing and evolution become painful
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Retrieves current weather information.
    ///
    /// WHY CancellationToken EXISTS:
    /// Allows request-level cancellation to propagate
    /// down to external dependencies.
    ///
    /// PRODUCTION NOTE:
    /// Cancellation is cooperative — if ignored,
    /// resources remain blocked even after client disconnects.
    /// </summary>
    Task<string> GetWeatherAsync(CancellationToken cancellationToken);
}