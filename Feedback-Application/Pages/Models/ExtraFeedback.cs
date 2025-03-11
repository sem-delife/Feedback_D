using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class ExtraFeedback
    {
        [Key]
        public int FragenID { get; set; } // Primärschlüssel

        [ForeignKey("Feedbackbogen")]
        public int BogenID { get; set; } // Fremdschlüssel für Feedbackbogen

        public string Frage { get; set; } // Die Zusatzfrage
    }
}

