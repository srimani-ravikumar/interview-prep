using BackendMastery.Architecture.SoC.Repository.Service.Models;

namespace BackendMastery.Architecture.SoC.Repository.Service.Output;

/// <summary>
/// Responsible for presenting order results.
/// </summary>
/// <remarks>
/// Intuition:
/// - Output formatting is a concern
/// - Should not leak into services
///
/// Reason to change:
/// - Presentation requirements change
/// </remarks>
public class OrderPresenter
{
    public void Show(Order order)
    {
        Console.WriteLine($"Order {order.Id} placed. Priority: {order.IsPriority}");
    }
}