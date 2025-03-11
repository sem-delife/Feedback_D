using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Erstellung
    {
        [Key]
        public int FeedbackID { get; set; } // Primärschlüssel, Auto-Increment
        [Required]
        [ForeignKey("AspNetUsers")]
        public int? UserID { get; set; } // Benutzer ID, optional (nullable)    
        [ForeignKey("Klassen")]
        public int KlassenID { get; set; } // KlassenID
        [ForeignKey("Abteilung")]
        public int AbteilungsID { get; set; } // Abteilung, optional
        [ForeignKey("Fach")]
        public int FachID { get; set; } // Fach, optional
        public string Code { get; set; } // Code, optional
        public int? Jahrgang { get; set; } // Jahrgang, optional
        public int Schuljahr { get; set; } // Schuljahr, optional

        // Konstruktor (optional, aber hilfreich)
        public Erstellung()
        {
            // Optional: Initialwerte setzen, falls nötig
        }
    }
}