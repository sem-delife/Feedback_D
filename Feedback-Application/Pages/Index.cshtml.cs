using Feedback_Application.Pages.Models;
using Feedback_Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public string? UserID { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte eine Klasse auswählen.")]
    public int SelectedClass { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte eine Jahrgangsstufe auswählen.")]
    public int SelectedYear { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte ein Schuljahr auswählen.")]
    public int SchoolYear { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte eine Abteilung auswählen.")]
    public int Abteilung { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte ein Fach auswählen.")]
    public int Fach { get; set; }

    [BindProperty, Required(ErrorMessage = "Bitte einen Code generieren.")]
    public string Code { get; set; }

    public List<SelectListItem> KlassenList { get; set; }
    public List<SelectListItem> FachList { get; set; }
    public List<SelectListItem> AbteilungList { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
        if (user != null)
        {
            UserID = user.Id; // Falls User existiert, ID setzen
        }

        KlassenList = await _context.Klassen
            .Select(k => new SelectListItem { Value = k.KlassenID.ToString(), Text = k.KlassenName })
            .ToListAsync();

        FachList = await _context.Fach
            .Select(f => new SelectListItem { Value = f.FachID.ToString(), Text = f.FachName })
            .ToListAsync();

        AbteilungList = await _context.Abteilung
            .Select(a => new SelectListItem { Value = a.AbteilungsID.ToString(), Text = a.AbteilungName })
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostSubmitFeedbackAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page(); // Falls Fehler auftreten, Modal bleibt offen
        }

        try
        {
            // Benutzer-ID sicher aus Identity holen**
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Forbid(); // Falls kein Benutzer angemeldet ist, Zugriff verweigern
            }

            Console.WriteLine($"UserID aus Identity: {userId}");

            //Die richtige FeedbackID aus der DB holen**
            var feedbackbogen = await _context.Feedbackbogen.FirstOrDefaultAsync();
            if (feedbackbogen == null)
            {
                return BadRequest("Kein Feedbackbogen gefunden.");
            }

            //Erstellung-Objekt mit richtiger UserID füllen**
            var erstellt = new Erstellung
            {
                FeedbackID = feedbackbogen.BogenID, // **Fix: Richtige FeedbackID setzen**
                UserID = userId, // UserID direkt setzen!**
                KlassenID = SelectedClass,
                Jahrgang = SelectedYear,
                Schuljahr = SchoolYear,
                AbteilungsID = Abteilung,
                FachID = Fach,
                Code = Code,
                Erstellungsdatum = DateTime.UtcNow // Optional: Erstellungsdatum setzen
            };

            _context.Erstellung.Add(erstellt);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            return Page();
        }
    }

}
