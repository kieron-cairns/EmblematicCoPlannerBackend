namespace EmblematicCoPlanner.Model;

public class User
{
    public Guid UserId { get; set; }
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public ServiceProviderProfile ServiceProviderProfile { get; set; }
}
