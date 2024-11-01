namespace EmblematicCoPlanner.Model;

public class User
{
    public Guid UserId { get; set; }
    public Guid? TenantId { get; set; } // Nullable if tenant is not always assigned
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public bool IsAdmin { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation property for one-to-one relationship
    public ServiceProviderProfile ServiceProviderProfile { get; set; }
}
