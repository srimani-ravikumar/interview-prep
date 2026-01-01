using BackendMastery.Persistence.FailureHandling.Compensation.Domain;
using BackendMastery.Persistence.FailureHandling.Compensation.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.Compensation.Services;

/// <summary>
/// Places orders with compensation logic.
/// </summary>
/// <remarks>
/// INTUITION:
/// - No distributed transaction exists
/// - Steps must be compensatable
///
/// KEY RULE:
/// ❗ Never assume rollback is available
/// </remarks>
public class OrderPlacementService
{
    private readonly PaymentGateway _payment = new();
    private readonly InventorySystem _inventory = new();

    public void PlaceOrder(decimal amount)
    {
        var order = new Order(amount);
        bool paymentCompleted = false;

        try
        {
            // STEP 1: Charge payment (irreversible)
            _payment.Charge(order.Amount);
            paymentCompleted = true;

            // STEP 2: Reserve inventory (may fail)
            _inventory.Reserve();

            Console.WriteLine("Order placed SUCCESSFULLY");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FAILURE during order placement: {ex.Message}");

            // COMPENSATION PATH
            if (paymentCompleted)
            {
                _payment.Refund(order.Amount);
                _inventory.Release();

                CompensationLog.Record(
                    $"Order {order.OrderId} compensated after partial failure");
            }
        }
    }
}