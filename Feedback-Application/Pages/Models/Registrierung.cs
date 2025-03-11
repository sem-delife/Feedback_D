using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Registrierung
    {
        [Key]
        public int RegID { get; set; } // Primärschlüssel
        public string RegPasswort { get; set; } // Beschreibung des Feedbackbogens
    }
}
