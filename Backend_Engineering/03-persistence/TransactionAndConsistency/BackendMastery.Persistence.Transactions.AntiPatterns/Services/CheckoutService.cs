using BackendMastery.Persistence.Transactions.AntiPatterns.Infrastructure;
using BackendMastery.Persistence.Transactions.AntiPatterns.External;

namespace BackendMastery.Persistence.Transactions.AntiPatterns.Services;

/// <summary>
/// Checkout service with multiple transaction anti-patterns.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Developer wants "full safety"
/// - Ends up holding transaction far too long
///
/// KEY RULE:
/// ❌ Never keep a transaction open during slow operations
/// </remarks>
public class CheckoutService
{
    private readonly TransactionManager _tx = new();
    private readonly FakeDatabase _db = new();
    private readonly PaymentGateway _payment = new();

    public void Checkout()
    {
        _tx.Begin();

        try
        {
            _db.Save("Order");

            // ❌ External call inside transaction
            _payment.Charge();

            _db.Save("Ledger");

            _tx.Commit();
        }
        catch
        {
            _tx.Rollback();
            throw;
        }
    }
}