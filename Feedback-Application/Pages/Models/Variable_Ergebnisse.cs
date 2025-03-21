using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Variable_Ergebnisse
    {
        [Key]
        public int VarErgebnisID { get; set; }

        [ForeignKey("ExtraFeedback")]
        public int FragenID { get; set; }
        public virtual ExtraFeedback ExtraFeedback { get; set; }

        [ForeignKey("Erstellung")]
        public int ErstellungsID { get; set; }
        public virtual Erstellung Erstellung { get; set; } // Navigation zur Erstellung

        public string AntwortUser { get; set; }
    }


}
