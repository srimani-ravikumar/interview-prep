namespace BackendMastery.Architecture.SoC.Repository.Output;

/// <summary>
/// Writes the final report.
/// </summary>
/// <remarks>
/// Intuition:
/// - Responsible only for output
/// - Could be console, file, email, etc.
///
/// Reason to change:
/// - Output destination changes
/// </remarks>
public class ReportWriter
{
    public void Write(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}