using System;
using System.Collections.Generic;

namespace Feedback_Application.Pages.Models
{
    public class FeedbackErgebnisViewModel
    {
        public int FeedbackID { get; set; }
        public int ErstellungsID { get; set; }
        public string FeedbackBeschreibung { get; set; } // Titel des Feedbacks
        public DateTime Erstellungsdatum { get; set; }
        public string FeedbackTitel { get; set; }
        public int FeedbackTeilnehmer
        {
            get
            {
                if (FeedbackID == 3)
                {
                    // Bei Bogen 3 gibt es keine normalen Bewertungen, daher Teilnehmerzahl aus Variablen ableiten
                    return VariableErgebnisse.Count / 2;
                }
                else
                {
                    // Normale Berechnung über die Anzahl der Antworten (Bögen 1 & 2)
                    return Ergebnisse.Count > 0 ? Ergebnisse[0].AnzahlAntworten : 0;
                }
            }
        }

        public List<FeedbackAussageErgebnis> Ergebnisse { get; set; } = new();
        public List<FeedbackVariableErgebnis> VariableErgebnisse { get; set; } = new();
    }

    public class FeedbackAussageErgebnis
    {
        public string Aussage { get; set; }
        public Dictionary<string, int> Antwortverteilung { get; set; } = new(); // Antwortverteilung
        public double Durchschnittswert { get; set; } // Durchschnittswert der Bewertungen
        public int AnzahlAntworten { get; set; } // Anzahl der Antworten für diese Aussage
    }


    public class FeedbackVariableErgebnis
    {
        public string Frage { get; set; }    // Die Frage aus ExtraFeedback
        public string Antwort { get; set; }  // Die Antwort des Nutzers
    }

}
