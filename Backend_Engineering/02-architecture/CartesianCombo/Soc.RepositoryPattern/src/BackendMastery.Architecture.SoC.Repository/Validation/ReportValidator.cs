using BackendMastery.Architecture.SoC.Repository.Models;

namespace BackendMastery.Architecture.SoC.Repository.Validation;

/// <summary>
/// Validates report records.
/// </summary>
/// <remarks>
/// Intuition:
/// - Business rules are simple
/// - Validation is still a separate concern
///
/// Reason to change:
/// - Validation rules evolve
/// </remarks>
public class ReportValidator
{
    public bool IsValid(ReportRecord record)
    {
        return record.Amount > 0;
    }
}