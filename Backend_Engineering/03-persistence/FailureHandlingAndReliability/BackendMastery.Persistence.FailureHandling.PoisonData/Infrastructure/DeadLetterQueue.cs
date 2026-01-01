using BackendMastery.Persistence.FailureHandling.PoisonData.Domain;

namespace BackendMastery.Persistence.FailureHandling.PoisonData.Infrastructure;

/// <summary>
/// Isolates poison messages.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Dead records must be quarantined
/// - System health > individual message
///
/// KEY RULE:
/// ❗ Isolation beats infinite retry
/// </remarks>
public class DeadLetterQueue
{
    public void Send(Message message)
    {
        Console.WriteLine(
            $"[DLQ] Message {message.Id} moved to Dead Letter Queue");
    }
}