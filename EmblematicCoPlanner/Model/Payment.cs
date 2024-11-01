namespace EmblematicCoPlanner.Model;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid AppointmentId { get; set; }
    public Guid ProviderId { get; set; }
    public string ClientEmail { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Appointment Appointment { get; set; }
    public ServiceProviderProfile Provider { get; set; }
}
