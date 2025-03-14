using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Erstellung
    {
        [Key] // Primärschlüssel mit Auto-Increment
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErstellungsID { get; set; }

        [ForeignKey("Feedbackbogen")]
        public int FeedbackID { get; set; } // Fremdschlüssel zum Feedbackbogen

        [Required]
        [ForeignKey("AspNetUsers")]
        public string? UserID { get; set; } // Benutzer ID, optional (nullable)

        [ForeignKey("Klassen")]
        public int KlassenID { get; set; } // KlassenID

        [ForeignKey("Abteilung")]
        public int AbteilungsID { get; set; } // Abteilung

        [ForeignKey("Fach")]
        public int FachID { get; set; } // Fach

        public string Code { get; set; } // Feedback-Code

        public int? Jahrgang { get; set; } // Jahrgang

        public int Schuljahr { get; set; } // Schuljahr

        [Required]
        public DateTime Erstellungsdatum { get; set; } = DateTime.UtcNow; // Neues Feld mit Standardwert

        // Konstruktor (optional)
        public Erstellung()
        {
            // Initialwerte können hier gesetzt werden (falls nötig)
        }
    }
}
