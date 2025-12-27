namespace BackendMastery.Architecture.SoC.Repository.Service.Validation;

/// <summary>
/// Validates order input.
/// </summary>
/// <remarks>
/// Intuition:
/// - Prevents invalid state from entering the system
/// - Enforces fail-fast principle
///
/// Reason to change:
/// - Validation rules evolve
/// </remarks>
public class OrderValidator
{
    public bool IsValid(decimal amount)
    {
        return amount > 0;
    }
}