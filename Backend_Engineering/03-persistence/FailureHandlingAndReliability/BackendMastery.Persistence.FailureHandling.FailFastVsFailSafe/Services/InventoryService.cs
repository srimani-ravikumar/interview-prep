using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Domain;
using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Services;

/// <summary>
/// Coordinates inventory operations.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This is where fail-fast vs fail-safe decisions live
///
/// USE CASE:
/// - Order placement
///
/// KEY RULE:
/// ❗ Decision must be intentional, not accidental
/// </remarks>
public class InventoryService
{
    private readonly InventoryStore _store;

    public InventoryService(InventoryStore store)
    {
        _store = store;
    }

    public void ReserveStock(string productId, int quantity)
    {
        try
        {
            // CRITICAL READ
            var item = _store.Get(productId);

            // BUSINESS RULE
            item.Reduce(quantity);

            // CRITICAL WRITE
            _store.Save(item);

            Console.WriteLine($"Stock reserved: {quantity} units");
        }
        catch (Exception ex)
        {
            // FAIL-FAST: inventory correctness > availability
            Console.WriteLine("CRITICAL FAILURE — stopping operation");
            throw;
        }
        finally
        {
            // FAIL-SAFE: metrics must not break core flow
            MetricsFallback.RecordFailure("Inventory reservation attempted");
        }
    }
}