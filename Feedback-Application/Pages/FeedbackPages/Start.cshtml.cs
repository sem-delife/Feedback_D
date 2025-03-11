using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Feedback_Application.Areas.Identity; // Stelle sicher, dass dieser Namespace vorhanden ist
using Feedback_Application.Pages.Models; // Hier ist das Modell für Erstellung
using System.Threading.Tasks;

namespace Feedback_Application.Pages.FeedbackPages
{
    public class StartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Erstellung NeueErstellung { get; set; } = new Erstellung();

        public StartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Debugging: Werte in der Konsole ausgeben
            Console.WriteLine($"Neue Erstellung: Name={NeueErstellung.KlassenName}, Jahrgang={NeueErstellung.Jahrgang}, Schuljahr={NeueErstellung.Schuljahr}, Abteilung={NeueErstellung.Abteilung}, Fach={NeueErstellung.Fach}");

            // Speichern in die DB
            _context.Erstellung.Add(NeueErstellung);
            await _context.SaveChangesAsync();

            return RedirectToPage("/FeedbackPages/Start");
        }
    }
}
