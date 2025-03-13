using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;
using Feedback_Application.Areas.Identity.Pages.Account.Manage.Models;

namespace Feedback_Application.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public string Username { get; set; }
        [TempData] public string StatusMessage { get; set; }

        [BindProperty] public string TeacherCode { get; set; }

        [BindProperty] public string EntityType { get; set; }
        [BindProperty] public string EntityName { get; set; }
        [BindProperty] public int EntityId { get; set; }

        public List<AdminDataTableViewModel> DataTables { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Username = user.UserName;
            var registrationEntry = await _context.Registrierung.FindAsync(1);
            TeacherCode = registrationEntry?.RegPasswort ?? "";

            DataTables = new List<AdminDataTableViewModel>
            {
                new AdminDataTableViewModel
                {
                    Title = "Klassen",
                    Items = await _context.Klassen.Cast<object>().ToListAsync(),
                    NameField = "KlassenName",
                    IdField = "KlassenID"
                },
                new AdminDataTableViewModel
                {
                    Title = "Fächer",
                    Items = await _context.Fach.Cast<object>().ToListAsync(),
                    NameField = "FachName",
                    IdField = "FachID"
                },
                new AdminDataTableViewModel
                {
                    Title = "Abteilungen",
                    Items = await _context.Abteilung.Cast<object>().ToListAsync(),
                    NameField = "AbteilungName",
                    IdField = "AbteilungID"
                }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAddEntityAsync()
        {
            if (string.IsNullOrWhiteSpace(EntityName))
            {
                ModelState.AddModelError("", "Der Name darf nicht leer sein.");
                return Page();
            }

            if (EntityType == "Klassen")
            {
                _context.Klassen.Add(new Klassen { KlassenName = EntityName });
            }
            else if (EntityType == "Fächer")
            {
                _context.Fach.Add(new Fach { FachName = EntityName });
            }
            else if (EntityType == "Abteilungen")
            {
                _context.Abteilung.Add(new Abteilung { AbteilungName = EntityName });
            }
            else
            {
                ModelState.AddModelError("", "Ungültiger Typ.");
                return Page();
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditEntityAsync()
        {
            if (EntityId <= 0 || string.IsNullOrWhiteSpace(EntityName))
            {
                ModelState.AddModelError("", "Ungültige Eingabe.");
                return Page();
            }

            try
            {
                if (EntityType == "Klassen")
                {
                    var entity = await _context.Klassen.FindAsync(EntityId);
                    if (entity != null)
                    {
                        entity.KlassenName = EntityName;
                        _context.Klassen.Update(entity);
                    }
                }
                else if (EntityType == "Fächer")
                {
                    var entity = await _context.Fach.FindAsync(EntityId);
                    if (entity != null)
                    {
                        entity.FachName = EntityName;
                        _context.Fach.Update(entity);
                    }
                }
                else if (EntityType == "Abteilungen")
                {
                    var entity = await _context.Abteilung.FindAsync(EntityId);
                    if (entity != null)
                    {
                        entity.AbteilungName = EntityName;
                        _context.Abteilung.Update(entity);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Ungültiger Typ.");
                    return Page();
                }

                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Fehler beim Bearbeiten: " + ex.Message);
                return Page();
            }
        }


        public async Task<IActionResult> OnPostDeleteEntityAsync(int entityId, string entityType)
        {
            if (entityId <= 0 || string.IsNullOrWhiteSpace(entityType))
            {
                return BadRequest("Ungültige Anfrage.");
            }

            object entity = null;

            if (entityType == "Klassen")
            {
                entity = await _context.Klassen.FindAsync(entityId);
                if (entity != null) _context.Klassen.Remove((Klassen)entity);
            }
            else if (entityType == "Fächer")
            {
                entity = await _context.Fach.FindAsync(entityId);
                if (entity != null) _context.Fach.Remove((Fach)entity);
            }
            else if (entityType == "Abteilungen")
            {
                entity = await _context.Abteilung.FindAsync(entityId);
                if (entity != null) _context.Abteilung.Remove((Abteilung)entity);
            }

            if (entity != null)
            {
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
