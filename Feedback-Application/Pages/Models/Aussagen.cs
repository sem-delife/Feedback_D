using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Aussagen
    {
        [Key]
        public int AussageID { get; set; } // Primärschlüssel

        [ForeignKey("Oberthema")]
        public int ThemaID { get; set; } // Fremdschlüssel für Oberthema

        public string Aussage { get; set; } // Die eigentliche Aussage
    }
}
