using Feedback_Application.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Feedback_Application; // Hier den Namespace für deinen ApplicationDbContext verwenden
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Feedback_Application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Konstruktor, um den DbContext zu injizieren
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Standardmäßige Methode für den Index
        public void OnGet()
        {
        }

        // POST: Speichern der Formular-Daten
        public async Task<IActionResult> OnPostSaveFeedbackAsync(
            int userID,
            string selectedClass,
            int selectedYear,
            int schoolYear,
            string abteilung,
            string fach,
            string code)
        {
            Console.WriteLine("IN DB EINTRAGUNG");
            // Erstellen eines neuen Feedback-Objekts
            var feedback = new Erstellung
            {
                UserID = userID,
                KlassenName = selectedClass,
                Jahrgang = selectedYear,
                Schuljahr = schoolYear,
                Abteilung = abteilung,
                Fach = fach,
                Code = code
            };

            // Feedback-Objekt zur Datenbank hinzufügen
            _context.Erstellung.Add(feedback);
            await _context.SaveChangesAsync();

            // Bestätigung oder Redirect zurück zur Startseite
            return RedirectToPage("/Index");  // Du kannst auch eine andere Seite verwenden
        }
    }
}
