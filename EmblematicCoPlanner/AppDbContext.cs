using EmblematicCoPlanner.Model;
using Microsoft.EntityFrameworkCore;

namespace EmblematicCoPlanner;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ServiceProviderProfile> ServiceProviderProfiles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
    public DbSet<ProviderAvailability> ProviderAvailabilities { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Invitation> Invitations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure one-to-one relationship between User and ServiceProviderProfile
        modelBuilder.Entity<User>()
            .HasOne(u => u.ServiceProviderProfile)
            .WithOne(sp => sp.User)
            .HasForeignKey<ServiceProviderProfile>(sp => sp.UserId);

        // Configure unique index for emails within each tenant
        modelBuilder.Entity<User>()
            .HasIndex(u => new { u.Email, u.TenantId }).IsUnique();

        // Configure one-to-one relationship between Appointment and AppointmentStatus
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Status)
            .WithOne(s => s.Appointment)
            .HasForeignKey<AppointmentStatus>(s => s.AppointmentId);

        // Configure other relationships as required
        modelBuilder.Entity<ServiceProviderProfile>()
            .HasMany(sp => sp.ServicesOffered)
            .WithOne(s => s.ServiceProviderProfile)
            .HasForeignKey(s => s.ProviderId);
        
        modelBuilder.Entity<ServiceProviderProfile>()
            .HasMany(sp => sp.Availabilities)
            .WithOne(pa => pa.Provider)
            .HasForeignKey(pa => pa.ProviderId);
        
        // Additional configurations as needed
    }
}
