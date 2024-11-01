using EmblematicCoPlanner.Model;
using Microsoft.EntityFrameworkCore;

namespace EmblematicCoPlanner;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties for each entity
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
            // Configure unique index for emails within each tenant
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email, u.TenantId })
                .IsUnique();

            // User and ServiceProviderProfile - One-to-One relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.ServiceProviderProfile)
                .WithOne(sp => sp.User)
                .HasForeignKey<ServiceProviderProfile>(sp => sp.UserId);

            // ServiceProviderProfile and Services - One-to-Many relationship
            modelBuilder.Entity<ServiceProviderProfile>()
                .HasMany(sp => sp.ServicesOffered)
                .WithOne(s => s.ServiceProviderProfile)
                .HasForeignKey(s => s.ProviderId);

            // ServiceProviderProfile and ProviderAvailability - One-to-Many relationship
            modelBuilder.Entity<ServiceProviderProfile>()
                .HasMany(sp => sp.Availabilities)
                .WithOne(pa => pa.Provider)
                .HasForeignKey(pa => pa.ProviderId);

            // Client and Appointments - One-to-Many relationship
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId);

            // Appointment and AppointmentStatus - One-to-One relationship
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Status)
                .WithOne(s => s.Appointment)
                .HasForeignKey<AppointmentStatus>(s => s.AppointmentId);

            // Appointment and Provider (ServiceProviderProfile) - Many-to-One relationship
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Provider)
                .WithMany()
                .HasForeignKey(a => a.ProviderId);

            // Appointment and Service - Many-to-One relationship
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId);

            // Notification and User - Optional Many-to-One relationship
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.SetNull); // Keep notifications even if the user is deleted

            // Notification and Appointment - Many-to-One relationship
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Appointment)
                .WithMany()
                .HasForeignKey(n => n.AppointmentId);

            // Payment and Appointment - Many-to-One relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Appointment)
                .WithMany()
                .HasForeignKey(p => p.AppointmentId);

            // Payment and ServiceProviderProfile (Provider) - Many-to-One relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Provider)
                .WithMany()
                .HasForeignKey(p => p.ProviderId);

            // Invitation and ServiceProviderProfile (Tenant) - Many-to-One relationship
            modelBuilder.Entity<Invitation>()
                .HasOne<ServiceProviderProfile>()
                .WithMany()
                .HasForeignKey(i => i.TenantId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete invitations if ServiceProviderProfile is deleted
        }
    }