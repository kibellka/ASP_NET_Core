using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Preference> Preferences { get; set; }

        public DbSet<PromoCode> PromoCodes { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Customer>().HasKey(e => e.Id);

            modelBuilder.Entity<Preference>().HasKey(e => e.Id);

            modelBuilder.Entity<CustomerPreference>().HasKey(e => new { e.CustomerId, e.PreferenceId });

            modelBuilder.Entity<CustomerPreference>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Preferences)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<CustomerPreference>()
                .HasOne(e => e.Preference)
                .WithMany()
                .HasForeignKey(e => e.PreferenceId);

            modelBuilder.Entity<PromoCode>().HasKey(e => e.Id);

            modelBuilder.Entity<PromoCode>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.PromoCodes)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
