namespace EmblematicCoPlanner.Model;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    public Guid ClientId { get; set; }
    public Guid ProviderId { get; set; }
    public Guid ServiceId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Guid StatusId { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Client Client { get; set; }
    public ServiceProviderProfile Provider { get; set; }
    public Service Service { get; set; }
    public AppointmentStatus Status { get; set; }
}
