using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Variable_Ergebnisse
    {
        [Key]
        public int VarErgebnisID { get; set; } // Primärschlüssel

        [ForeignKey("ExtraFeedback")]
        public int FragenID { get; set; } // Fremdschlüssel für ExtraFeedback

        [ForeignKey("Erstellung")]
        public int ErstellungsID { get; set; } // Fremdschlüssel für die Erstellung des Feedbackbogens

        public string AntwortUser { get; set; } // Die Antwort des Benutzers
    }
}
