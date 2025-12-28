namespace BackendMastery.Persistence.DataModeling.Aggregates.Storage;

public class OrderRecord
{
    public Guid Id { get; set; }
    public decimal TotalAmount { get; set; }
}