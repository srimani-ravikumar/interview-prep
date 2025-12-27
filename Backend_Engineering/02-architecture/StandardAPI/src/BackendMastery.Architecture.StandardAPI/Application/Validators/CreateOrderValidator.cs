namespace BackendMastery.StandardAPI.Application.Validators;

/// <summary>
/// Validates application-level input.
/// </summary>
/// <remarks>
/// Intuition:
/// - Catches bad input early
/// - Prevents domain execution
///
/// This is NOT a domain rule.
/// </remarks>
public class CreateOrderValidator
{
    public void Validate(decimal amount)
    {
        if (amount == default)
            throw new ArgumentException("Amount is required.");
    }
}