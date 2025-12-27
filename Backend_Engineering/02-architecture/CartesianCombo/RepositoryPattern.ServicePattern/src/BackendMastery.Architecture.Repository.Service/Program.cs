using BackendMastery.Architecture.Repository.Service.Repositories;
using BackendMastery.Architecture.Repository.Service.Services;

/// <summary>
/// Application entry point.
/// </summary>
/// <remarks>
/// Intuition:
/// - Wires repository and service
/// - No framework assumptions
/// </remarks>
IOrderRepository repository = new InMemoryOrderRepository();
IOrderService service = new OrderService(repository);

var order = service.PlaceOrder(1500);

Console.WriteLine($"Order {order.Id} placed. Priority: {order.IsPriority}");