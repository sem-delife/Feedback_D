using System.ComponentModel.DataAnnotations;

namespace Feedback_Application.Pages.Models
{
    public class Rollen
    {
        [Key]
        public int RollenID { get; set; }
        public string Rolle { get; set; }
    }
}
