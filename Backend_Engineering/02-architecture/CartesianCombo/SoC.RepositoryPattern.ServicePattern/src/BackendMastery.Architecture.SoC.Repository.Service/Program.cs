using BackendMastery.Architecture.SoC.Repository.Service.Output;
using BackendMastery.Architecture.SoC.Repository.Service.Repositories;
using BackendMastery.Architecture.SoC.Repository.Service.Services;
using BackendMastery.Architecture.SoC.Repository.Service.Validation;

/// <summary>
/// Application entry point.
/// </summary>
/// <remarks>
/// Intuition:
/// - Owns object creation
/// - Wires all concerns together
///
/// This keeps other layers clean.
/// </remarks>
IOrderRepository repository = new InMemoryOrderRepository();
var validator = new OrderValidator();
IOrderService service = new OrderService(repository, validator);
var presenter = new OrderPresenter();

var order = service.PlaceOrder(1500);
presenter.Show(order);