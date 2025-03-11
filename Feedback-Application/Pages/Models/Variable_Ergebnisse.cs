using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Variable_Ergebnisse
    {
        [Key]
        public int VarErgebnisID { get; set; } // Primärschlüssel

        [ForeignKey("ExtraFeedback")]
        public int FragenID { get; set; } // Fremdschlüssel für ExtraFeedback

        [ForeignKey("Erstellung")]
        public int FeedbackID { get; set; } // Fremdschlüssel für Feedback (Erstellung)

        public string AntwortUser { get; set; } // Die Antwort des Benutzers
    }
}
