using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models; // Hier den richtigen Namespace einfügen
using Feedback_Application.Areas.Identity;
using Microsoft.AspNetCore.Identity;

namespace Feedback_Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        //public DbSet<Benutzer> Benutzer { get; set; }  // Deine Benutzer-Tabelle
        public DbSet<Rollen> Rolle { get; set; }  // Deine Rollen-Tabelle
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Erstellung> Erstellung { get; set; }
    }
}
