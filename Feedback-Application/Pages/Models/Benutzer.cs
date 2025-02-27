using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Benutzer
    {
        [Key]
        public int UserID { get; set; }

        public int? RollenID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Passwort { get; set; }

        // Navigation Property, um mit der Rolle zu verbinden
        public Rollen Rolle { get; set; }
    }
}
