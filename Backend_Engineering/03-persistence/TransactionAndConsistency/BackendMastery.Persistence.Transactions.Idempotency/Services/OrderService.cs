using BackendMastery.Persistence.Transactions.Idempotency.Domain;
using BackendMastery.Persistence.Transactions.Idempotency.Infrastructure;

namespace BackendMastery.Persistence.Transactions.Idempotency.Services;

/// <summary>
/// Handles order creation safely.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Same request may arrive multiple times
/// - Transaction alone is insufficient
///
/// USE CASE:
/// - Checkout retry
/// - Payment confirmation retry
///
/// KEY RULE:
/// ❗ Idempotency must be checked BEFORE side effects
/// </remarks>
public class OrderService
{
    private readonly IdempotencyStore _store = new();

    public void CreateOrder(string idempotencyKey, decimal amount)
    {
        // 🔐 Idempotency gate (outside transaction)
        if (_store.Exists(idempotencyKey))
        {
            Console.WriteLine("Duplicate request detected — skipping order creation");
            return;
        }

        BeginTransaction();

        try
        {
            var order = new Order(amount);
            Console.WriteLine($"Order created for amount {order.Amount}");

            // Persist idempotency key ONLY after success
            _store.Save(idempotencyKey);

            CommitTransaction();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
    }

    private void BeginTransaction()
        => Console.WriteLine("BEGIN TRANSACTION");

    private void CommitTransaction()
        => Console.WriteLine("COMMIT TRANSACTION");

    private void RollbackTransaction()
        => Console.WriteLine("ROLLBACK TRANSACTION");
}