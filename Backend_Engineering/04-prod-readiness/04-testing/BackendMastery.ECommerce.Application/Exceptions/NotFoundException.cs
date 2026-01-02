namespace BackendMastery.ECommerce.Application.Exceptions;

/// <summary>
/// Represents a missing business resource.
/// Will later map to HTTP 404.
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}