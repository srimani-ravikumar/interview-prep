namespace BackendMastery.StandardAPI.Domain.Exceptions;

/// <summary>
/// Thrown when an order violates business rules.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents a DOMAIN failure
/// - Not an HTTP concern
/// - Not a validation framework concern
/// </remarks>
public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message)
        : base(message)
    {
    }
}