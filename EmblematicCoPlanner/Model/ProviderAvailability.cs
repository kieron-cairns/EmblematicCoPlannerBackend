namespace EmblematicCoPlanner.Model;

public class ProviderAvailability
{
    public Guid AvailabilityId { get; set; }
    public Guid ProviderId { get; set; }
    public string DaysAvailable { get; set; } // Enum/JSON to handle "Mon-Fri", "Sat-Sun", etc.
    public string CustomDays { get; set; } // JSON array for specific days
    public int ServiceDuration { get; set; } // in minutes
    public string TimesAvailable { get; set; } // JSON array for time slots
    public int GapAfterService { get; set; } // in minutes
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ServiceProviderProfile Provider { get; set; }
}


