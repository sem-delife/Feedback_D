using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback_Application.Pages.FeedbackPages
{
    public class ErgebnisseModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ErgebnisseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FeedbackErgebnisViewModel> FeedbackErgebnisse { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var rawData = await (
                from e in _context.Erstellung
                join f in _context.Feedbackbogen on e.FeedbackID equals f.BogenID
                join er in _context.Ergebnisse on e.ErstellungsID equals er.FeedbackID into ergebnisseGroup
                from ergebnis in ergebnisseGroup.DefaultIfEmpty()
                join a in _context.Aussagen on ergebnis.AussageID equals a.AussageID into aussagenGroup
                from aussage in aussagenGroup.DefaultIfEmpty()
                join b in _context.Bewertungen on ergebnis.BewertungsID equals b.BewertungsID into bewertungenGroup
                from bewertung in bewertungenGroup.DefaultIfEmpty()
                select new
                {
                    e.ErstellungsID,
                    e.Erstellungsdatum,
                    FeedbackTitel = f.Beschreibung,
                    Aussage = aussage != null ? aussage.Aussage : "Unbekannt",
                    BewertungsChar = bewertung != null ? bewertung.BewertungsChar : "Unbekannt"
                }
            ).ToListAsync(); // Zuerst alle Daten in den Speicher holen

            // Jetzt erst im Speicher gruppieren und Dictionary erstellen
            FeedbackErgebnisse = rawData
                .GroupBy(x => new { x.ErstellungsID, x.FeedbackTitel, x.Erstellungsdatum })
                .Select(g => new FeedbackErgebnisViewModel
                {
                    FeedbackTitel = g.Key.FeedbackTitel,
                    Erstellungsdatum = g.Key.Erstellungsdatum,
                    Ergebnisse = g
                        .Where(x => x.Aussage != "Unbekannt") // Falls es keine Aussage gibt, ignorieren
                        .GroupBy(x => x.Aussage)
                        .Select(grp => new FeedbackAussageErgebnis
                        {
                            Aussage = grp.Key,
                            Antwortverteilung = grp
                                .Where(x => x.BewertungsChar != "Unbekannt")
                                .GroupBy(x => x.BewertungsChar)
                                .ToDictionary(b => b.Key, b => b.Count())
                        })
                        .ToList()
                })
                .ToList();

            return Page();
        }


    }

    public class FeedbackErgebnisViewModel
    {
        public string FeedbackTitel { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public List<FeedbackAussageErgebnis> Ergebnisse { get; set; }
    }

    public class FeedbackAussageErgebnis
    {
        public string Aussage { get; set; }
        public Dictionary<string, int> Antwortverteilung { get; set; }
    }
}
