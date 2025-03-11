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

        public DbSet<Registrierung> Registrierung { get; set; }
        public DbSet<Feedbackbogen> Feedbackbogen { get; set; }
        public DbSet<Oberthema> Oberthema { get; set; }
        public DbSet<Aussagen> Aussagen { get; set; }
        public DbSet<Bewertungen> Bewertungen { get; set; }
        public DbSet<ExtraFeedback> ExtraFeedback { get; set; }
        public DbSet<Fach> Fach { get; set; }
        public DbSet<Abteilung> Abteilung { get; set; }
        public DbSet<Klassen> Klassen { get; set; }
        public DbSet<Erstellung> Erstellung { get; set; }
        public DbSet<Variable_Ergebnisse> Variable_Ergebnisse { get; set; }
        public DbSet<Ergebnisse> Ergebnisse { get; set; }



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
