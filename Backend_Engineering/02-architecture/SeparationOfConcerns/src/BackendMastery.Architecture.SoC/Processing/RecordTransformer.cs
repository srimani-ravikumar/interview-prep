using BackendMastery.Architecture.SoC.Models;

namespace BackendMastery.Architecture.SoC.Processing;

/// <summary>
/// Responsible ONLY for transformation logic.
/// </summary>
/// <remarks>
/// Intuition:
/// - This is where business computation lives
/// - Changes here reflect new transformation rules
///
/// It should NOT:
/// - know where data came from
/// - know where data goes
/// </remarks>
public class RecordTransformer
{
    public Record Transform(Record record)
    {
        return new Record
        {
            Value = record.Value.ToUpperInvariant()
        };
    }
}