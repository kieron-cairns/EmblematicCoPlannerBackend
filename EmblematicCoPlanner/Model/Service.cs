namespace EmblematicCoPlanner.Model;

public class Service
{
    public Guid ServiceId { get; set; }
    public Guid ProviderId { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; } // in minutes
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ServiceProviderProfile ServiceProviderProfile { get; set; }
}
