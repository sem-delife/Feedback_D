using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Feedbackbogen
    {
        [Key]
        public int BogenID { get; set; } // Primärschlüssel
        public string Beschreibung { get; set; } // Beschreibung des Feedbackbogens
    }
}