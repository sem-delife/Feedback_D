using Feedback_Application.Pages.Models;
using Feedback_Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public List<SelectListItem> KlassenList { get; set; }
    public List<SelectListItem> FachList { get; set; }
    public List<SelectListItem> AbteilungList { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
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