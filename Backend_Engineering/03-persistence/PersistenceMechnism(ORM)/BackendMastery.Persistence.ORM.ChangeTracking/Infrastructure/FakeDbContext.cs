using BackendMastery.Persistence.ORM.ChangeTracking.Domain;

namespace BackendMastery.Persistence.ORM.ChangeTracking.Infrastructure;

/// <summary>
/// Simulates ORM change tracking behavior.
/// </summary>
/// <remarks>
/// INTUITION:
/// - ORM snapshots entity state
/// - Detects changes at commit time
///
/// USE CASE:
/// - Track modified entities
///
/// KEY RULE:
/// ❗ ORMs detect changes, they don't require explicit updates
/// </remarks>
public class FakeDbContext
{
    private class TrackedEntity
    {
        public Product Entity { get; }
        public Product Snapshot { get; }
        public EntityState State { get; set; }

        public TrackedEntity(Product entity)
        {
            Entity = entity;
            Snapshot = new Product(entity.Id, entity.Name, entity.Price);
            State = EntityState.Unchanged;
        }
    }

    private readonly Dictionary<int, TrackedEntity> _tracked = new();

    public Product GetProductById(int id)
    {
        Console.WriteLine("Loading Product from database");

        var product = new Product(id, "Keyboard", 1000);
        _tracked[id] = new TrackedEntity(product);

        return product;
    }

    public void SaveChanges()
    {
        Console.WriteLine("\n--- SaveChanges ---");

        foreach (var entry in _tracked.Values)
        {
            if (entry.Entity.Name != entry.Snapshot.Name ||
                entry.Entity.Price != entry.Snapshot.Price)
            {
                entry.State = EntityState.Modified;
                Console.WriteLine($"UPDATE Product SET Name='{entry.Entity.Name}', Price={entry.Entity.Price} WHERE Id={entry.Entity.Id}");
            }
            else
            {
                Console.WriteLine("No changes detected");
            }
        }
    }
}