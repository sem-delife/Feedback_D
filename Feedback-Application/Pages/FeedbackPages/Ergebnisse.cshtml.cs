using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;
using System;
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

        public List<FeedbackErgebnisViewModel> FeedbackErgebnisse { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var userGuid = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userGuid))
            {
                return Forbid();
            }

            FeedbackErgebnisse = await HoleEigeneFeedbacks(userGuid);

            return Page();
        }

        private async Task<List<FeedbackErgebnisViewModel>> HoleEigeneFeedbacks(string userId)
        {
            var erstellungsDaten = await _context.Erstellung
                .Where(e => e.UserID == userId)
                .Include(e => e.Abteilung)
                .Include(e => e.Klassen)
                .Include(e => e.Fach)
                .Include(e => e.Feedbackbogen)
                .ToListAsync();

            var erstellungsIds = erstellungsDaten.Select(e => e.ErstellungsID).ToList();

            var ergebnisDaten = await _context.Ergebnisse
                .Where(er => erstellungsIds.Contains(er.ErstellungsID))
                .Include(er => er.Aussage)
                .Include(er => er.Bewertung)
                .ToListAsync();

            var variableErgebnisDaten = await _context.Variable_Ergebnisse
                .Where(v => erstellungsIds.Contains(v.ErstellungsID))
                .Include(v => v.ExtraFeedback)
                .ToListAsync();

            return erstellungsDaten.Select(e => new FeedbackErgebnisViewModel
            {
                ErstellungsID = e.ErstellungsID,
                FeedbackID = e.FeedbackID,
                FeedbackTitel = $"{e.Abteilung.AbteilungName} - {e.Klassen.KlassenName} - {e.Fach.FachName} - {e.Erstellungsdatum.ToShortDateString()}",
                FeedbackBeschreibung = e.Feedbackbogen.Beschreibung,
                Erstellungsdatum = e.Erstellungsdatum,
                Ergebnisse = ergebnisDaten
                    .Where(er => er.ErstellungsID == e.ErstellungsID)
                    .GroupBy(er => er.Aussage.Aussage)
                    .Select(grp => new FeedbackAussageErgebnis
                    {
                        Aussage = grp.Key,
                        Durchschnittswert = grp.Average(er => er.Bewertung.BewertungsInt),
                        AnzahlAntworten = grp.Count()
                    })
                    .ToList(),
                VariableErgebnisse = variableErgebnisDaten
                    .Where(v => v.ErstellungsID == e.ErstellungsID)
                    .Select(v => new FeedbackVariableErgebnis
                    {
                        Frage = v.ExtraFeedback.Frage,
                        Antwort = v.AntwortUser
                    })
                    .ToList()
            }).ToList();
        }



    }
}
