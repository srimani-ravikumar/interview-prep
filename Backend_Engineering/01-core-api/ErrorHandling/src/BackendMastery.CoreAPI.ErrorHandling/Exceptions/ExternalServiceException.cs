namespace BackendMastery.CoreAPI.ErrorHandling.Exceptions;

/// <summary>
/// Represents failures from external systems.
/// </summary>
/// <remarks>
/// Intuition:
/// - System dependency failed
/// - Our service may still be healthy
///
/// Use case:
/// - Payment gateway down
/// - Third-party API timeout
/// </remarks>
public class ExternalServiceException : Exception
{
    public ExternalServiceException(string message) : base(message) { }
}