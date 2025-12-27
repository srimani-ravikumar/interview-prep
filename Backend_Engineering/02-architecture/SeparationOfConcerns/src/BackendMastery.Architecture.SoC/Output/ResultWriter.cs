using BackendMastery.Architecture.SoC.Models;

namespace BackendMastery.Architecture.SoC.Output;

/// <summary>
/// Responsible ONLY for output.
/// </summary>
/// <remarks>
/// Intuition:
/// - Output format and destination change frequently
/// - Console → File → API → Queue
///
/// This class should NOT:
/// - validate
/// - transform
/// - apply business rules
/// </remarks>
public class ResultWriter
{
    public void Write(IEnumerable<Record> records)
    {
        foreach (var record in records)
        {
            Console.WriteLine($"Processed: {record.Value}");
        }
    }
}