using BackendMastery.Persistence.FailureHandling.RetryStrategies.Domain;
using BackendMastery.Persistence.FailureHandling.RetryStrategies.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.RetryStrategies.Services;

/// <summary>
/// Handles order creation with retry logic.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Retry must be intentional
/// - Retry limits prevent infinite loops
///
/// KEY RULE:
/// ❗ Permanent failures must NEVER be retried
/// </remarks>
public class OrderService
{
    private readonly OrderStore _store = new();
    private const int MaxRetries = 3;

    public void CreateOrder(decimal amount)
    {
        int attempt = 0;

        while (true)
        {
            try
            {
                attempt++;
                Console.WriteLine($"Attempt {attempt}: Creating order");

                var order = new Order(amount);
                _store.Save(order);

                Console.WriteLine("Order creation SUCCESS");
                return;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Transient failure: {ex.Message}");

                if (attempt >= MaxRetries)
                {
                    Console.WriteLine("Retry limit reached — failing fast");
                    throw;
                }

                Console.WriteLine("Retrying...\n");
            }
            catch (Exception ex)
            {
                // FAIL-FAST: permanent failures
                Console.WriteLine($"Permanent failure: {ex.Message}");
                throw;
            }
        }
    }
}