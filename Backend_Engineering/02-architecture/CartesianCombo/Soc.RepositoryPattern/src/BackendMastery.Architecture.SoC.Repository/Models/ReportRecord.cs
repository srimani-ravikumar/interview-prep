namespace BackendMastery.Architecture.SoC.Repository.Models;

/// <summary>
/// Represents a raw report record.
/// </summary>
/// <remarks>
/// Intuition:
/// - Pure data holder
/// - No behavior
///
/// Reason to change:
/// - Data shape changes
/// </remarks>
public class ReportRecord
{
    public string Id { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}