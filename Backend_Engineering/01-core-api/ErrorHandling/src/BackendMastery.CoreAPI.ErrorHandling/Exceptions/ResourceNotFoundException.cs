namespace BackendMastery.CoreAPI.ErrorHandling.Exceptions;

/// <summary>
/// Thrown when a requested resource does not exist.
/// </summary>
/// <remarks>
/// Intuition:
/// - Client asked for something that is not present
///
/// Use case:
/// - Maps naturally to HTTP 404
/// </remarks>
public class ResourceNotFoundException : DomainException
{
    public ResourceNotFoundException(string resourceName, string id)
        : base($"{resourceName} with id '{id}' was not found.")
    {
    }
}