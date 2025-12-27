using BackendMastery.Architecture.SoC.Repository.Models;

namespace BackendMastery.Architecture.SoC.Repository.Processing;

/// <summary>
/// Formats records for reporting.
/// </summary>
/// <remarks>
/// Intuition:
/// - Simple transformation logic
/// - Not a business workflow
///
/// Reason to change:
/// - Output format changes
/// </remarks>
public class ReportFormatter
{
    public string Format(ReportRecord record)
    {
        return $"Record {record.Id} : Amount = {record.Amount}";
    }
}