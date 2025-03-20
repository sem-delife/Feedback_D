using System;
using System.Collections.Generic;

namespace Feedback_Application.Pages.Models
{
    public class FeedbackErgebnisViewModel
    {
        public int ErstellungsID { get; set; }
        public string FeedbackTitel { get; set; }
        public string FeedbackBeschreibung { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public List<FeedbackAussageErgebnis> Ergebnisse { get; set; } = new();
    }

    public class FeedbackAussageErgebnis
    {
        public string Aussage { get; set; }
        public Dictionary<string, int> Antwortverteilung { get; set; } = new();
    }
}
