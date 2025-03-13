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

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            return Page();
        }
    }
}
