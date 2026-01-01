namespace BackendMastery.Persistence.FailureHandling.PoisonData.Domain;

/// <summary>
/// Represents an incoming message.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Messages come from outside the system
/// - Input is NOT trustworthy
///
/// USE CASE:
/// - Message queues
/// - Event streams
///
/// KEY RULE:
/// ❗ Never assume input is well-formed
/// </remarks>
public class Message
{
    public string Id { get; }
    public string Payload { get; }

    public Message(string id, string payload)
    {
        Id = id;
        Payload = payload;
    }
}