namespace BackendMastery.Architecture.SoC.Models;

/// <summary>
/// Simple data model.
/// </summary>
/// <remarks>
/// Intuition:
/// - This model carries data
/// - It does NOT contain behavior
///
/// Why?
/// - Behavior belongs to processing stages
/// - Data should be passive here
/// </remarks>
public class Record
{
    public string Value { get; set; } = string.Empty;
}