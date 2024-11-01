namespace EmblematicCoPlanner.Model;

public class Notification
{
    public Guid NotificationId { get; set; }
    public Guid? UserId { get; set; }
    public string ClientEmail { get; set; }
    public Guid AppointmentId { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public Appointment Appointment { get; set; }
}
