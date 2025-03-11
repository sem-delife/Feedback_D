using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Fach
    {
        [Key]
        public int FachID { get; set; } // Primärschlüssel
        public string FachName { get; set; } // Name des Fachs
    }
}
