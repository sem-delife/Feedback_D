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
                .FirstOrDefaultAsync(e => e.Code == Code);

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
    }
}