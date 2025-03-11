using Feedback_Application.Pages.Models;
using Feedback_Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    // Konstruktor, um den DbContext zu injizieren
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }
    [BindProperty]
    public int UserID { get; set; }

    [BindProperty]
    public string SelectedClass { get; set; }
    [BindProperty]
    public int SelectedYear { get; set; }
    [BindProperty]
    public int SchoolYear { get; set; }
    [BindProperty]
    public string Abteilung { get; set; }
    [BindProperty]
    public string Fach { get; set; }
    [BindProperty]
    public string Code { get; set; }

    // Diese Methode wird beim Absenden des Formulars aufgerufen
    public async Task<IActionResult> OnPostSubmitFeedbackAsync()
    {
        try
        {
            var erstellt = new Erstellung
            {
                UserID = UserID,
                KlassenName = SelectedClass,
                Jahrgang = SelectedYear,
                Schuljahr = SchoolYear,
                Abteilung = Abteilung,
                Fach = Fach,
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