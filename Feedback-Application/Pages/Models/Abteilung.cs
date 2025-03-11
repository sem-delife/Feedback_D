using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Abteilung
    {
        [Key]
        public int AbteilungsID { get; set; } // Primärschlüssel
        public string AbteilungName { get; set; } // Name der Abteilung
    }
}
