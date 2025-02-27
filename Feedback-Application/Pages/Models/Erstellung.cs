using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Erstellung
    {
        [Key]
        public int FeedbackID { get; set; } // Primärschlüssel, Auto-Increment
        [Required]
        public int? UserID { get; set; } // Benutzer ID, optional (nullable)
        public string Code { get; set; } // Code, optional
        public string KlassenName { get; set; } // Klassenname, optional
        public int? Jahrgang { get; set; } // Jahrgang, optional
        public int Schuljahr { get; set; } // Schuljahr, optional
        public string Abteilung { get; set; } // Abteilung, optional
        public string Fach { get; set; } // Fach, optional

        // Konstruktor (optional, aber hilfreich)
        public Erstellung()
        {
            // Optional: Initialwerte setzen, falls nötig
        }
    }
}
