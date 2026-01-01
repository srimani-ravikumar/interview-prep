using BackendMastery.Persistence.FailureHandling.PoisonData.Domain;
using BackendMastery.Persistence.FailureHandling.PoisonData.Infrastructure;
using BackendMastery.Persistence.FailureHandling.PoisonData.Services;

namespace BackendMastery.Persistence.FailureHandling.PoisonData;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== POISON DATA & DEAD RECORDS DEMO ===\n");

        var queue = new MessageQueue();
        var processor = new MessageProcessor();

        // --------------------------------------------------
        // SCENARIO 1: Healthy messages
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Healthy messages\n");

        queue.Enqueue(new Message("M1", "OK"));
        queue.Enqueue(new Message("M2", "OK"));

        Drain(queue, processor);

        // --------------------------------------------------
        // SCENARIO 2: Poison message appears
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: Poison message\n");

        queue.Enqueue(new Message("M3", "POISON"));

        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine($"Attempt {i}:");
            Drain(queue, processor);
            queue.Enqueue(new Message("M3", "POISON")); // redelivery
            Console.WriteLine();
        }

        // --------------------------------------------------
        // SCENARIO 3: System survives poison data
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Healthy message after poison\n");

        queue.Enqueue(new Message("M4", "OK"));
        Drain(queue, processor);

        Console.WriteLine("\n=== DEMO COMPLETE ===");
    }

    private static void Drain(
        MessageQueue queue,
        MessageProcessor processor)
    {
        Message? msg;
        while ((msg = queue.Dequeue()) != null)
        {
            processor.Process(msg);
        }
    }
}