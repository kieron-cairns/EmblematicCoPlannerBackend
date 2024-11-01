namespace EmblematicCoPlanner.Model;

public class Client
{
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<Appointment> Appointments { get; set; }
}
