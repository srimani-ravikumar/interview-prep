namespace BackendMastery.ProdReadiness.CircuitBreakers.Contracts;

/// <summary>
/// Represents the outcome of a payment attempt.
///
/// WHY THIS EXISTS:
/// Payment operations are critical side effects.
/// Their outcomes must be explicit, structured, and extensible.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents fragile string-based APIs that
/// cannot evolve safely over time.
///
/// WHEN TO USE:
/// Every irreversible or business-critical operation.
///
/// WHAT BREAKS IF MISUSED:
/// - Clients rely on string parsing
/// - Backward compatibility becomes impossible
/// - Observability and auditing suffer
/// </summary>
public sealed record PaymentResponse(
    string Status,
    string? ReferenceId);