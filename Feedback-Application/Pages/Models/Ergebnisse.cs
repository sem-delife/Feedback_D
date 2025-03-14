using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Ergebnisse
    {
        [Key]
        public int ErgebnisID { get; set; } // Primärschlüssel

        [ForeignKey("Erstellung")]
        public int FeedbackID { get; set; } // Fremdschlüssel für Feedback (Erstellung)

        [ForeignKey("Aussagen")]
        public int AussageID { get; set; } // Fremdschlüssel für Aussagen

        [ForeignKey("Bewertung")]
        public int BewertungsID { get; set; } // Fremdschlüssel für Bewertungen

        [ForeignKey("VariableErgebnisse")]
        public int? VarErgebnisID { get; set; } // Fremdschlüssel für VariableErgebnisse (optional)

        [ForeignKey("Erstellung")]
        public int ErstellungsID { get; set; } // NEU: ID der spezifischen Feedback-Erstellung
    }
}
