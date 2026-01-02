namespace BackendMastery.ProdReadiness.Validation.Contracts.Responses;

/// <summary>
/// INTUITION:
/// Error responses are part of the API contract.
///
/// USE CASE:
/// Clients parse this structure to decide recovery behavior.
///
/// FAILURE MODE:
/// Inconsistent shapes force string parsing and guesswork.
/// </summary>
public sealed class ErrorResponse
{
    public string Code { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public IDictionary<string, string[]>? Details { get; init; }
}