using BackendMastery.Architecture.SoC.Repository.Models;

namespace BackendMastery.Architecture.SoC.Repository.Repositories;

/// <summary>
/// Repository abstraction for report data.
/// </summary>
/// <remarks>
/// Intuition:
/// - Defines WHERE data comes from
/// - Hides storage details
///
/// This is NOT:
/// - Business logic
/// - Workflow orchestration
/// </remarks>
public interface IReportRepository
{
    IEnumerable<ReportRecord> GetAll();
}