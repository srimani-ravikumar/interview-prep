using BackendMastery.Architecture.SoC.Repository.Models;

namespace BackendMastery.Architecture.SoC.Repository.Repositories;

/// <summary>
/// In-memory repository implementation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Knows storage details
/// - Can be swapped without touching consumers
///
/// Reason to change:
/// - Storage mechanism changes
/// </remarks>
public class InMemoryReportRepository : IReportRepository
{
    private readonly List<ReportRecord> _records = new()
    {
        new() { Id = "R1", Amount = 100 },
        new() { Id = "R2", Amount = -50 }, // invalid
        new() { Id = "R3", Amount = 250 }
    };

    public IEnumerable<ReportRecord> GetAll() => _records;
}