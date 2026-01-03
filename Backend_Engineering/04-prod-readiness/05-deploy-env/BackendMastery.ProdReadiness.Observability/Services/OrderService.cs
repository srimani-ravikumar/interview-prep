using BackendMastery.ProdReadiness.Observability.Contracts;
using BackendMastery.ProdReadiness.Observability.Infrastructure;

namespace BackendMastery.ProdReadiness.Observability.Services;

/// <summary>
/// Handles order creation with observable logging.
///
/// WHY THIS EXISTS:
/// Business logic must emit signals
/// meaningful to operators.
///
/// LOGGING RULES:
/// - Log intent
/// - Log failure with context
/// - Never swallow exceptions
///
/// WHAT BREAKS IF MISUSED:
/// Silent failures create blind spots.
/// </summary>
public sealed class OrderService : IOrderService
{
    private readonly ILogger<OrderService> _logger;
    private readonly UnreliableInventoryClient _inventory;

    public OrderService(
        ILogger<OrderService> logger,
        UnreliableInventoryClient inventory)
    {
        _logger = logger;
        _inventory = inventory;
    }

    public async Task<OrderResponse> CreateAsync(
        CancellationToken cancellationToken)
    {
        var orderId = Guid.NewGuid().ToString();

        _logger.LogInformation(
            "Starting order creation. OrderId={OrderId}",
            orderId);

        try
        {
            await _inventory
                .ReserveAsync(orderId, cancellationToken);

            _logger.LogInformation(
                "Order created successfully. OrderId={OrderId}",
                orderId);

            return new OrderResponse(orderId, "CREATED");
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Order creation failed. OrderId={OrderId}",
                orderId);

            throw;
        }
    }
}