using System;
using System.Collections.Generic;

namespace Feedback_Application.Pages.Models
{
    public class AggregierteErgebnisseViewModel
    {
        public int? KlassenID { get; set; }
        public int? AbteilungsID { get; set; }
        public int? FachID { get; set; }
        public string AggregationsTyp { get; set; } // "Klasse", "Abteilung" oder "Fach"
        public string Titel { get; set; } // Z. B. "Klasse IT12 - Schuljahr 2024"
        public int AnzahlFeedbacks { get; set; }
        public List<AggregierteAussageErgebnis> Ergebnisse { get; set; } = new();
    }

    public class AggregierteAussageErgebnis
    {
        public string Aussage { get; set; }
        public double Durchschnittswert { get; set; }
        public int AnzahlAntworten { get; set; }
    }
}
