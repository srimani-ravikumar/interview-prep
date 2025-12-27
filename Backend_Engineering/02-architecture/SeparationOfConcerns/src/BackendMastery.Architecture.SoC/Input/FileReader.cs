using BackendMastery.Architecture.SoC.Models;

namespace BackendMastery.Architecture.SoC.Input;

/// <summary>
/// Responsible ONLY for reading input.
/// </summary>
/// <remarks>
/// Intuition:
/// - This class changes if input source changes
/// - File → API → Queue → Stream
///
/// It should NOT:
/// - validate
/// - transform
/// - decide business rules
/// </remarks>
public class FileReader
{
    public IEnumerable<Record> Read()
    {
        // Simulated file read
        return new List<Record>
        {
            new() { Value = "data-1" },
            new() { Value = "" },        // invalid
            new() { Value = "data-2" }
        };
    }
}