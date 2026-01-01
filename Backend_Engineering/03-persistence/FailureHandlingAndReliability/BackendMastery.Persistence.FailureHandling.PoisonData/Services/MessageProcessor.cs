using BackendMastery.Persistence.FailureHandling.PoisonData.Domain;
using BackendMastery.Persistence.FailureHandling.PoisonData.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.PoisonData.Services;

/// <summary>
/// Processes messages with poison detection.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Some messages will never succeed
/// - Retrying forever blocks healthy data
///
/// KEY RULE:
/// ❗ Quarantine poison data to protect the system
/// </remarks>
public class MessageProcessor
{
    private readonly PoisonTracker _tracker = new();
    private readonly DeadLetterQueue _dlq = new();

    public void Process(Message message)
    {
        try
        {
            Console.WriteLine($"Processing message {message.Id}");

            // Simulate poison payload
            if (message.Payload == "POISON")
                throw new Exception("Invalid payload format");

            Console.WriteLine($"Message {message.Id} processed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Failure processing message {message.Id}: {ex.Message}");

            bool isPoison = _tracker.RegisterFailure(message.Id);

            if (isPoison)
            {
                _dlq.Send(message);
            }
            else
            {
                Console.WriteLine(
                    $"Message {message.Id} will be retried");
            }
        }
    }
}