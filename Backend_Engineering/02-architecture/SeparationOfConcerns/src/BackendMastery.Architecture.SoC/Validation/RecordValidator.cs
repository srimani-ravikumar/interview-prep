using BackendMastery.Architecture.SoC.Models;

namespace BackendMastery.Architecture.SoC.Validation;

/// <summary>
/// Responsible ONLY for validation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Validation rules change independently
/// - Business constraints evolve over time
///
/// This class should NOT:
/// - read input
/// - transform data
/// - write output
/// </remarks>
public class RecordValidator
{
    public bool IsValid(Record record)
    {
        return !string.IsNullOrWhiteSpace(record.Value);
    }
}