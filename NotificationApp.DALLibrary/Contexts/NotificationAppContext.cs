using Microsoft.EntityFrameworkCore;
using NotificationApp.ModelLibrary;

namespace NotificationApp.DALLibrary
{
    public class NotificationAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=notificationappdb;Username=postgres;Password=Pratik@Postgres");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id).HasName("pk_userId");
                u.HasIndex(u => u.Email).IsUnique();
                u.HasIndex(u => u.PhoneNumber).IsUnique();
            });
            modelBuilder.Entity<Notification>(n =>
            {
                n.HasKey(n => n.Id).HasName("pk_notificationId");
                n.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}