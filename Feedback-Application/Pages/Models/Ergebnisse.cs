using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_Application.Pages.Models
{
    public class Ergebnisse
    {
        [Key]
        public int ErgebnisID { get; set; }

        [ForeignKey("Erstellung")]
        public int ErstellungsID { get; set; }

        [ForeignKey("Feedbackbogen")]
        public int FeedbackID { get; set; }

        [ForeignKey("Aussagen")]
        public int AussageID { get; set; }
        public virtual Aussagen Aussage { get; set; }

        [ForeignKey("Bewertung")]
        public int BewertungsID { get; set; }
        public virtual Bewertungen Bewertung { get; set; }
    }

}
