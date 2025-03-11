using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Oberthema
    {
        [Key]
        public int ThemaID { get; set; } // Primärschlüssel

        [ForeignKey("Feedbackbogen")]
        public int BogenID { get; set; } // Fremdschlüssel für Feedbackbogen

        public string Thema { get; set; } // Name des Oberthemas

    }
}
