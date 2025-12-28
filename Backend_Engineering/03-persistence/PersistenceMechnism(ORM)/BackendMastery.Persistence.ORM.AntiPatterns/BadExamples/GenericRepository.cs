namespace BackendMastery.Persistence.ORM.AntiPatterns.BadExamples;

/// <summary>
/// ❌ Anti-pattern: Generic repository.
/// </summary>
/// <remarks>
/// WHY THIS IS BAD:
/// - Exposes persistence mechanics everywhere
/// - Encourages CRUD thinking
/// - Hides intent
///
/// ROOT CAUSE:
/// - Treating repositories as collections
/// </remarks>
public class GenericRepository<T>
{
    public IQueryable<T> Query()
    {
        // Pretend this comes from DbSet<T>
        return new List<T>().AsQueryable();
    }
}