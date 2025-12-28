namespace BackendMastery.Persistence.ORM.ContextLifecycle.Domain;

/// <summary>
/// Represents a domain entity.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This is a pure in-memory object
/// - It has no idea about persistence
///
/// USE CASE:
/// - Represents a user loaded from storage
///
/// KEY RULE:
/// ❗ Domain entities must not know how they are persisted
/// </remarks>
public class User
{
    public int Id { get; }
    public string Name { get; private set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }
}