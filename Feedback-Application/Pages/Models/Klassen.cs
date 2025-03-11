using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Klassen
    {
        [Key]
        public int KlassenID { get; set; } // Primärschlüssel
        public string KlassenName { get; set; } // Name der Klasse
    }
}
