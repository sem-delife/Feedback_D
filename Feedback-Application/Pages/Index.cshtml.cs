using Feedback_Application.Pages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback_Application;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int UserID { get; set; }

    [BindProperty]
    public int SelectedClass { get; set; }

    [BindProperty]
    public int SelectedYear { get; set; }

    [BindProperty]
    public int SchoolYear { get; set; }

    [BindProperty]
    public int Abteilung { get; set; }

    [BindProperty]
    public int Fach { get; set; }

    [BindProperty]
    public string Code { get; set; }

    // Liste für das Dropdown-Menü
    public List<SelectListItem> KlassenListe { get; set; }

    // Lädt die verfügbaren Klassen beim Seitenaufruf
    public void OnGet()
    {
        KlassenListe = _context.Klassen
            .Select(k => new SelectListItem
            {
                Value = k.KlassenID.ToString(),
                Text = k.KlassenName
            })
            .ToList();
    }

    // Diese Methode wird beim Absenden des Formulars aufgerufen
    public async Task<IActionResult> OnPostSubmitFeedbackAsync()
    {
        try
        {
            var erstellt = new Erstellung
            {
                UserID = UserID,
                KlassenID = SelectedClass,
                Jahrgang = SelectedYear,
                Schuljahr = SchoolYear,
                AbteilungsID = Abteilung,
                FachID = Fach,
                Code = Code
            };

            _context.Erstellung.Add(erstellt);
            await _context.SaveChangesAsync();

            Console.WriteLine("Feedback erfolgreich in DB gespeichert.");
            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            return Page();
        }
    }
}
