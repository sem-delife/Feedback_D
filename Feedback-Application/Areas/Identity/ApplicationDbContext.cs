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

            // Feedbackbogen
            modelBuilder.Entity<Feedbackbogen>().HasData(
                new Feedbackbogen { BogenID = 1, Beschreibung = "Unterrichtsbeurteilung durch Schuelerinnen und Schueler I" },
                new Feedbackbogen { BogenID = 2, Beschreibung = "Zielscheibe" }

            );

            // Oberthemen
            modelBuilder.Entity<Oberthema>().HasData(
                new Oberthema { ThemaID = 1, BogenID = 1, Thema = "Verhalten des Lehrers:" },
                new Oberthema { ThemaID = 2, BogenID = 1, Thema = "Bewerten Sie folgende Aussagen:" },
                new Oberthema { ThemaID = 3, BogenID = 1, Thema = "Wie ist der Unterricht?" },
                new Oberthema { ThemaID = 4, BogenID = 1, Thema = "Bewerten Sie folgende Behauptungen:" },
                new Oberthema { ThemaID = 5, BogenID = 2, Thema = "Bewertung" }
            );

            // Aussagen
            modelBuilder.Entity<Aussagen>().HasData(
                new Aussagen { AussageID = 1, ThemaID = 1, Aussage = "Sie/Er ist ungeduldig" },
                new Aussagen { AussageID = 2, ThemaID = 1, Aussage = "Sie/Er ist sicher im Auftreten" },
                new Aussagen { AussageID = 3, ThemaID = 1, Aussage = "Sie/Er ist freundlich" },
                new Aussagen { AussageID = 4, ThemaID = 1, Aussage = "Sie/Er ist erregbar und aufbrausend" },
                new Aussagen { AussageID = 5, ThemaID = 1, Aussage = "Sie/Er ist tatkraeftig, aktiv" },
                new Aussagen { AussageID = 6, ThemaID = 1, Aussage = "Sie/Er ist aufgeschlossen" },

                new Aussagen { AussageID = 7, ThemaID = 2, Aussage = "Die Lehrerin, der Lehrer bevorzugt manche Schuelerinnen oder Schueler." },
                new Aussagen { AussageID = 8, ThemaID = 2, Aussage = "Die Lehrerin, der Lehrer nimmt die Schuelerinnen und Schueler ernst." },
                new Aussagen { AussageID = 9, ThemaID = 2, Aussage = "Die Lehrerin, der Lehrer ermutigt und lobt viel." },
                new Aussagen { AussageID = 10, ThemaID = 2, Aussage = "Die Lehrerin, der Lehrer entscheidet immer allein." },
                new Aussagen { AussageID = 11, ThemaID = 2, Aussage = "Die Lehrerin, der Lehrer gesteht eigene Fehler ein." },

                new Aussagen { AussageID = 12, ThemaID = 3, Aussage = "Die Ziele des Unterrichts sind klar erkennbar" },
                new Aussagen { AussageID = 13, ThemaID = 3, Aussage = "Der Lehrer redet zu viel." },
                new Aussagen { AussageID = 14, ThemaID = 3, Aussage = "Der Lehrer schweift oft vom Thema ab." },
                new Aussagen { AussageID = 15, ThemaID = 3, Aussage = "Die Fragen und Beiträge der Schuelerinnen und Schueler werden ernst genommen." },
                new Aussagen { AussageID = 16, ThemaID = 3, Aussage = "Die Sprache des Lehrers ist gut verstaendlich." },
                new Aussagen { AussageID = 17, ThemaID = 3, Aussage = "Der Lehrer achtet auf Ruhe und Disziplin im Unterricht." },
                new Aussagen { AussageID = 18, ThemaID = 3, Aussage = "Der Unterricht ist abwechslungsreich." },
                new Aussagen { AussageID = 19, ThemaID = 3, Aussage = "Unterrichtsmaterialien sind ansprechend und gut verstaendlich gestaltet" },
                new Aussagen { AussageID = 20, ThemaID = 3, Aussage = "Der Stoff wird ausreichend wiederholt und geuebt." },

                new Aussagen { AussageID = 21, ThemaID = 4, Aussage = "Die Themen der Schulaufgaben werden rechtzeitig vorher bekannt gegeben." },
                new Aussagen { AussageID = 22, ThemaID = 4, Aussage = "Der Schwierigkeitsgrad der Leistungsnachweise entspricht dem der Unterrichtsinhalte." },
                new Aussagen { AussageID = 23, ThemaID = 4, Aussage = "Die Bewertungen sind nachvollziehbar und verstaendlich." },

                new Aussagen { AussageID = 24, ThemaID = 5, Aussage = "Die Lehrkraft hat ein großes Hintergrundwissen." },
                new Aussagen { AussageID = 25, ThemaID = 5, Aussage = "Die Lehrkraft ist immer gut vorbereitet." },
                new Aussagen { AussageID = 26, ThemaID = 5, Aussage = "Die Lehrkraft zeigt Interesse an ihren Schuelern." },
                new Aussagen { AussageID = 27, ThemaID = 5, Aussage = "Die Lehrkraft sorgt fuer ein gutes Lernklima in der Klasse." },
                new Aussagen { AussageID = 28, ThemaID = 5, Aussage = "Die Notengebung ist fair und nachvollziehbar." },
                new Aussagen { AussageID = 29, ThemaID = 5, Aussage = "Ich konnte dem Unterricht immer gut folgen." },
                new Aussagen { AussageID = 30, ThemaID = 5, Aussage = "Der Unterricht wird vielfaeltig gestaltet." },
                new Aussagen { AussageID = 31, ThemaID = 5, Aussage = "Ich lerne im Unterricht viel." }
            );

            // Bewertungen
            modelBuilder.Entity<Bewertungen>().HasData(
                new Bewertungen { BewertungsID = 1, BogenID = 1, BewertungsChar = "trifft voellig zu", BewertungsInt = 0 },
                new Bewertungen { BewertungsID = 2, BogenID = 1, BewertungsChar = "trifft eher zu", BewertungsInt = 0 },
                new Bewertungen { BewertungsID = 3, BogenID = 1, BewertungsChar = "trifft eher nicht zu", BewertungsInt = 0 },
                new Bewertungen { BewertungsID = 4, BogenID = 1, BewertungsChar = "trifft ueberhaupt nicht zu", BewertungsInt = 0 },
                new Bewertungen { BewertungsID = 5, BogenID = 2, BewertungsChar = "", BewertungsInt = 1 },
                new Bewertungen { BewertungsID = 6, BogenID = 2, BewertungsChar = "", BewertungsInt = 2 },
                new Bewertungen { BewertungsID = 7, BogenID = 2, BewertungsChar = "", BewertungsInt = 3 },
                new Bewertungen { BewertungsID = 8, BogenID = 2, BewertungsChar = "", BewertungsInt = 4 },
                new Bewertungen { BewertungsID = 9, BogenID = 2, BewertungsChar = "", BewertungsInt = 5 }
            );

            // ExtraFeedback
            modelBuilder.Entity<ExtraFeedback>().HasData(
                new ExtraFeedback { FragenID = 1, BogenID = 1, Frage = "Das hat mir besonders gut gefallen:" },
                new ExtraFeedback { FragenID = 2, BogenID = 1, Frage = "Das hat mir nicht gefallen:" },
                new ExtraFeedback { FragenID = 3, BogenID = 1, Frage = "Verbesserungsvorschlaege:" },
                new ExtraFeedback { FragenID = 4, BogenID = 2, Frage = "Was ich sonst noch anmerken moechte: " }
            );

            // Seeding für Registrierung (Lehrer-Code)
            modelBuilder.Entity<Registrierung>().HasData(
                new Registrierung { RegID = 1, RegPasswort = "ABCDE" }
            );
        }


    }
}
