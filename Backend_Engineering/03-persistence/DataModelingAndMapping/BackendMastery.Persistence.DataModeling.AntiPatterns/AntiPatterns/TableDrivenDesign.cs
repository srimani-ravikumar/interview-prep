namespace BackendMastery.Persistence.DataModeling.AntiPatterns;

/// <summary>
/// ❌ ANTI-PATTERN: Table-Driven Design
/// </summary>
/// <remarks>
/// INTUITION:
/// - Database schema dictates domain design
/// - Domain mirrors tables 1:1
///
/// USE CASE (WRONG):
/// - ORM-first design
/// - "Just generate models from DB"
///
/// WHY THIS IS BAD:
/// - Domain changes require schema changes
/// - Business rules get distorted
///
/// KEY RULE:
/// ❗ The database should adapt to the domain, not the other way around.
/// </remarks>
public class OrderTable
{
    public Guid Order_Id { get; set; }
    public decimal Order_Total_Amount { get; set; }
    public string Order_Status_Code { get; set; } = string.Empty;
}

/// <summary>
/// Business logic forced to understand DB structure ❌
/// </summary>
public static class OrderProcessor
{
    public static bool IsPriority(OrderTable record)
    {
        // Business logic leaking DB semantics
        return record.Order_Status_Code == "P1";
    }
}