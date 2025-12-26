namespace BackendMastery.CoreAPI.ErrorHandling.Exceptions;

/// <summary>
/// Base exception for all domain-level failures.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents errors meaningful to the business
/// - NOT framework or infrastructure errors
///
/// Use case:
/// - Provides a common parent for domain failures
/// </remarks>
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }
}