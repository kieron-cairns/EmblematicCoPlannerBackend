using System.ComponentModel.DataAnnotations;

namespace EmblematicCoPlanner.Model;

public class AppointmentStatus
{
    [Key]
    public Guid StatusId { get; set; }
    public Guid AppointmentId { get; set; }
    public bool? IsAccepted { get; set; }
    public string Status { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation property
    public Appointment Appointment { get; set; }
}
