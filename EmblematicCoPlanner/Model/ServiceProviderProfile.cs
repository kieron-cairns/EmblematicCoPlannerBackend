namespace EmblematicCoPlanner.Model;

public class ServiceProviderProfile
{
    public Guid ProviderId { get; set; }
    public Guid UserId { get; set; }
    public Guid tenantId { get; set; }
    public string BusinessName { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public bool? RequiresAcceptance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; }
    public ICollection<Service> ServicesOffered { get; set; }
    public ICollection<ProviderAvailability> Availabilities { get; set; }
}
