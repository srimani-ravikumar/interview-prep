namespace BackendMastery.ECommerce.Application.Exceptions;

/// <summary>
/// Represents a business rule failure.
/// NOT a technical error.
/// </summary>
public class BusinessRuleViolationException : Exception
{
    public BusinessRuleViolationException(string message)
        : base(message)
    {
    }
}