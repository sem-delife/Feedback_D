using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Feedback_Application.Pages.FeedbackPages
{
    public class ErgebnisseModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private const int MindestFeedbacksFürAggregation = 5; // Mindestens 5 Feedbacks nötig für Aggregation

        public ErgebnisseModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FeedbackErgebnisViewModel> FeedbackErgebnisse { get; set; } = new();
        public List<AggregierteErgebnisseViewModel> AggregierteErgebnisse { get; set; } = new();

        public List<SelectListItem> KlassenList { get; set; } = new();
        public List<SelectListItem> AbteilungList { get; set; } = new();
        public List<SelectListItem> FachList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? klassenId, int? abteilungsId, int? fachId)
        {
            var userGuid = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (string.IsNullOrEmpty(userGuid))
            {
                return Forbid();
            }

            // Listen für die Dropdowns befüllen
            KlassenList = await _context.Klassen
                .Select(k => new SelectListItem { Value = k.KlassenID.ToString(), Text = k.KlassenName })
                .ToListAsync();

            AbteilungList = await _context.Abteilung
                .Select(a => new SelectListItem { Value = a.AbteilungsID.ToString(), Text = a.AbteilungName })
                .ToListAsync();

            FachList = await _context.Fach
                .Select(f => new SelectListItem { Value = f.FachID.ToString(), Text = f.FachName })
                .ToListAsync();

            if (!isAdmin)
            {
                FeedbackErgebnisse = await HoleEigeneFeedbacks(userGuid);
            }
            else
            {
                AggregierteErgebnisse = await HoleAggregierteErgebnisse(klassenId, abteilungsId, fachId);
            }

            return Page();
        }


        private async Task<List<FeedbackErgebnisViewModel>> HoleEigeneFeedbacks(string userId)
        {
            return await (
                from e in _context.Erstellung
                join f in _context.Feedbackbogen on e.FeedbackID equals f.BogenID
                join er in _context.Ergebnisse on e.ErstellungsID equals er.ErstellungsID into ergebnisseGroup
                from ergebnis in ergebnisseGroup.DefaultIfEmpty()
                join a in _context.Aussagen on ergebnis.AussageID equals a.AussageID into aussagenGroup
                from aussage in aussagenGroup.DefaultIfEmpty()
                join b in _context.Bewertungen on ergebnis.BewertungsID equals b.BewertungsID into bewertungenGroup
                from bewertung in bewertungenGroup.DefaultIfEmpty()
                where e.UserID == userId
                select new
                {
                    e.ErstellungsID,
                    e.Erstellungsdatum,
                    FeedbackTitel = f.Beschreibung,
                    Aussage = aussage != null ? aussage.Aussage : null,
                    BewertungsChar = bewertung != null ? bewertung.BewertungsChar : null
                }
            )
            .ToListAsync()
            .ContinueWith(task => task.Result
                .GroupBy(x => new { x.ErstellungsID, x.FeedbackTitel, x.Erstellungsdatum })
                .Select(g => new FeedbackErgebnisViewModel
                {
                    ErstellungsID = g.Key.ErstellungsID,
                    FeedbackBeschreibung = g.Key.FeedbackTitel,
                    Erstellungsdatum = g.Key.Erstellungsdatum,
                    Ergebnisse = g
                        .Where(x => x.Aussage != null)
                        .GroupBy(x => x.Aussage)
                        .Select(grp => new FeedbackAussageErgebnis
                        {
                            Aussage = grp.Key,
                            Antwortverteilung = grp
                                .Where(x => x.BewertungsChar != null)
                                .GroupBy(x => x.BewertungsChar)
                                .ToDictionary(b => b.Key, b => b.Count())
                        })
                        .ToList()
                })
                .ToList());
        }

        private async Task<List<AggregierteErgebnisseViewModel>> HoleAggregierteErgebnisse(int? klassenId, int? abteilungsId, int? fachId)
        {
            var query = _context.Erstellung
                .Include(e => e.Klassen)   // Korrekt: Navigationseigenschaft einbinden
                .Include(e => e.Abteilung) // Korrekt: Navigationseigenschaft einbinden
                .Include(e => e.Fach)      // Korrekt: Navigationseigenschaft einbinden
                .AsQueryable();

            if (klassenId.HasValue) query = query.Where(e => e.KlassenID == klassenId);
            if (abteilungsId.HasValue) query = query.Where(e => e.AbteilungsID == abteilungsId);
            if (fachId.HasValue) query = query.Where(e => e.FachID == fachId);

            var gruppierteErgebnisse = await query
                .GroupBy(e => new { e.Klassen.KlassenName, e.Abteilung.AbteilungName, e.Fach.FachName }) // Namen statt IDs verwenden
                .Where(g => g.Count() >= MindestFeedbacksFürAggregation) // Mindestanzahl prüfen
                .Select(g => new AggregierteErgebnisseViewModel
                {
                    KlassenID = g.First().KlassenID,
                    AbteilungsID = g.First().AbteilungsID,
                    FachID = g.First().FachID,
                    AnzahlFeedbacks = g.Count(),
                    Titel = $"{g.Key.AbteilungName} - {g.Key.KlassenName} - {g.Key.FachName}", // Menschlich lesbarer Titel
                    Ergebnisse = g.SelectMany(e => _context.Ergebnisse
                        .Where(er => er.ErstellungsID == e.ErstellungsID)
                        .GroupBy(er => er.AussageID)
                        .Select(aussageGrp => new AggregierteAussageErgebnis
                        {
                            Aussage = _context.Aussagen.FirstOrDefault(a => a.AussageID == aussageGrp.Key).Aussage,
                            Durchschnittswert = aussageGrp.Average(er => er.BewertungsID),
                            AnzahlAntworten = aussageGrp.Count()
                        })
                    ).ToList()
                })
                .ToListAsync();

            return gruppierteErgebnisse;
        }

    }
}
