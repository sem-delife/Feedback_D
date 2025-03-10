using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models; // Falls der Namespace korrekt ist

namespace Feedback_Application
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Erstellung> Erstellung { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix für MySQL: nvarchar(max) -> LONGTEXT
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");
            });

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(e => e.Value).HasColumnType("longtext");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.Property(e => e.ClaimValue).HasColumnType("longtext");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.Property(e => e.ClaimValue).HasColumnType("longtext");
            });

            Console.WriteLine("Kill me pls");
        }


    }
}
