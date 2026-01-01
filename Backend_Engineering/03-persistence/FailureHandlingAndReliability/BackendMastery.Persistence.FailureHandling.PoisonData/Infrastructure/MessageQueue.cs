using BackendMastery.Persistence.FailureHandling.PoisonData.Domain;

namespace BackendMastery.Persistence.FailureHandling.PoisonData.Infrastructure;

/// <summary>
/// Simulates a message queue.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Queues retry messages automatically
///
/// KEY RULE:
/// ❗ Queues amplify poison data if unchecked
/// </remarks>
public class MessageQueue
{
    private readonly Queue<Message> _queue = new();

    public void Enqueue(Message message) => _queue.Enqueue(message);

    public Message? Dequeue()
        => _queue.Count > 0 ? _queue.Dequeue() : null;
}