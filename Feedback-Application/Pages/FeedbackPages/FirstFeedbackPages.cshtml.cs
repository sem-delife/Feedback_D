using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;

namespace Feedback_Application.Pages
{
    public class FeedbackReportModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FeedbackReportModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Code { get; set; }

        public Feedbackbogen FeedbackBogen { get; set; }
        public List<Oberthema> Oberthemen { get; set; }
        public List<Aussagen> Aussagen { get; set; }
        public List<Bewertungen> Bewertungen { get; set; }
        public List<Ergebnisse> Ergebnisse { get; set; }
        public List<ExtraFeedback> ExtraFeedbacks { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Code))
            {
                return BadRequest("Kein Code angegeben.");
            }

            var erstellung = await _context.Erstellung
                .FirstOrDefaultAsync(e => e.Code.Trim().ToLower() == Code.Trim().ToLower());

            if (erstellung == null)
            {
                return NotFound("Kein Feedbackbogen mit diesem Code gefunden.");
            }

            FeedbackBogen = await _context.Feedbackbogen
                .FirstOrDefaultAsync(f => f.BogenID == erstellung.FeedbackID);

            if (FeedbackBogen == null)
            {
                return NotFound("Feedbackbogen nicht gefunden.");
            }

            Oberthemen = await _context.Oberthema
                .Where(o => o.BogenID == FeedbackBogen.BogenID)
                .ToListAsync();

            Aussagen = await _context.Aussagen
                .Where(a => Oberthemen.Select(o => o.ThemaID).Contains(a.ThemaID))
                .ToListAsync();

            Bewertungen = await _context.Bewertungen
                .Where(b => b.BogenID == FeedbackBogen.BogenID)
                .ToListAsync();

            Ergebnisse = await _context.Ergebnisse
                .Where(e => e.FeedbackID == FeedbackBogen.BogenID)
                .ToListAsync();

            ExtraFeedbacks = await _context.ExtraFeedback
                .Where(e => e.BogenID == FeedbackBogen.BogenID)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Code))
            {
                ModelState.AddModelError("", "Kein Code angegeben.");
                return Page();
            }

            var erstellung = await _context.Erstellung
                .FirstOrDefaultAsync(e => e.Code.Trim().ToLower() == Code.Trim().ToLower());

            if (erstellung == null)
            {
                ModelState.AddModelError("", "Kein Feedbackbogen mit diesem Code gefunden.");
                return Page();
            }

            int feedbackID = erstellung.FeedbackID;
            int erstellungsID = erstellung.ErstellungsID; // ErstellungsID holen

            // Radio-Button-Bewertungen sammeln
            var ausgewählteBewertungen = Request.Form.Keys
                .Where(k => k.StartsWith("bewertung_"))
                .Select(k => new
                {
                    AussageID = int.Parse(k.Split('_')[1]),
                    BewertungsID = int.Parse(Request.Form[k])
                })
                .ToList();

            foreach (var bewertung in ausgewählteBewertungen)
            {
                _context.Ergebnisse.Add(new Ergebnisse
                {
                    FeedbackID = feedbackID,
                    ErstellungsID = erstellungsID, // ErstellungsID setzen
                    AussageID = bewertung.AussageID,
                    BewertungsID = bewertung.BewertungsID
                });
            }

            // Freitextantworten speichern
            var extraFeedbackAntworten = Request.Form.Keys
                .Where(k => k.StartsWith("extra_feedback_"))
                .Select(k => new
                {
                    FrageID = int.Parse(k.Split('_')[2]),
                    Antwort = Request.Form[k]
                })
                .ToList();

            foreach (var extra in extraFeedbackAntworten)
            {
                if (!string.IsNullOrWhiteSpace(extra.Antwort))
                {
                    _context.Variable_Ergebnisse.Add(new Variable_Ergebnisse
                    {
                        FragenID = extra.FrageID,
                        ErstellungsID = erstellungsID, // ErstellungsID setzen
                        AntwortUser = extra.Antwort
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/FeedbackPages/FeedbackSuccess");
        }
    }
}
