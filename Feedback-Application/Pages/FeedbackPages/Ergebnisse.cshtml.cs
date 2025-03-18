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
            var isAdmin = User.IsInRole("Admin");

            if (string.IsNullOrEmpty(userGuid))
            {
                return Forbid();
            }

            Console.WriteLine($"Aktuelle Benutzer-GUID: {userGuid} (Admin: {isAdmin})");

            var userEntity = await _context.Users
                .Where(u => u.Id == userGuid)
                .Select(u => new { IntId = u.Id }) // Falls es eine andere Spalte gibt, hier anpassen
                .FirstOrDefaultAsync();

            if (userEntity == null && !isAdmin)
            {
                return Forbid(); // Falls kein Benutzer gefunden wird und er kein Admin ist
            }

            var userIntId = userEntity?.IntId; // Falls null, bleibt es null

            Console.WriteLine($"Gemappte User-IntID: {userIntId}");

            var rawData = await (
                from e in _context.Erstellung
                join f in _context.Feedbackbogen on e.FeedbackID equals f.BogenID
                join er in _context.Ergebnisse on e.ErstellungsID equals er.ErstellungsID into ergebnisseGroup
                from ergebnis in ergebnisseGroup.DefaultIfEmpty()
                join a in _context.Aussagen on ergebnis.AussageID equals a.AussageID into aussagenGroup
                from aussage in aussagenGroup.DefaultIfEmpty()
                join b in _context.Bewertungen on ergebnis.BewertungsID equals b.BewertungsID into bewertungenGroup
                from bewertung in bewertungenGroup.DefaultIfEmpty()
                where isAdmin || e.UserID == userIntId 
                select new
                {
                    e.ErstellungsID,
                    e.Erstellungsdatum,
                    FeedbackTitel = f.Beschreibung,
                    Aussage = aussage != null ? aussage.Aussage : null,
                    BewertungsChar = bewertung != null ? bewertung.BewertungsChar : null
                }
            ).ToListAsync();

            Console.WriteLine($"Gefundene Umfragen: {rawData.Count}");

            FeedbackErgebnisse = rawData
                .GroupBy(x => new { x.ErstellungsID, x.FeedbackTitel, x.Erstellungsdatum })
                .Select(g => new FeedbackErgebnisViewModel
                {
                    ErstellungsID = g.Key.ErstellungsID,
                    FeedbackTitel = g.Key.FeedbackTitel,
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
                .ToList();

            return Page();
        }





    }

    public class FeedbackErgebnisViewModel
    {
        public int ErstellungsID { get; set; }
        public string FeedbackTitel { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public List<FeedbackAussageErgebnis> Ergebnisse { get; set; } = new();
    }

    public class FeedbackAussageErgebnis
    {
        public string Aussage { get; set; }
        public Dictionary<string, int> Antwortverteilung { get; set; } = new();
    }
}
