namespace BackendMastery.Persistence.FailureHandling.Compensation.Infrastructure;

/// <summary>
/// Simulates inventory reservation.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Inventory reservation can fail
/// - Happens AFTER payment in many systems
///
/// KEY RULE:
/// ❗ Failure here requires compensation
/// </remarks>
public class InventorySystem
{
    public void Reserve()
    {
        if (Random.Shared.Next(0, 2) == 0)
            throw new Exception("Inventory reservation failed");

        Console.WriteLine("Inventory reserved");
    }

    public void Release()
    {
        Console.WriteLine("COMPENSATION: Inventory released");
    }
}