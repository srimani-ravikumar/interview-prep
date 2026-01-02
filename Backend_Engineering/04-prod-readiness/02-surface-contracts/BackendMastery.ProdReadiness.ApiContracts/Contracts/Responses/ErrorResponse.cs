namespace BackendMastery.ProdReadiness.ApiContracts.Contracts.Responses;

/// <summary>
/// INTUITION:
/// Errors are part of the API contract, not an afterthought.
/// 
/// USE CASE:
/// Clients depend on predictable error shapes for recovery logic.
/// 
/// FAILURE MODE:
/// Ad-hoc errors force clients to parse strings or guess intent.
/// </summary>
public sealed class ErrorResponse
{
    public string Code { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}