using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Bewertungen
    {
        [Key]
        public int BewertungsID { get; set; } // Primärschlüssel

        [ForeignKey("Feedbackbogen")]
        public int BogenID { get; set; } // Fremdschlüssel für Feedbackbogen

        public string BewertungsChar { get; set; } // Bewertung in Textform
        public int BewertungsInt { get; set; } // Bewertung als Zahl
    }
}
