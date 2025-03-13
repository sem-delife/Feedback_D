using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Pages.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Feedback_Application.Areas.Admin.Pages.Shared
{
    public class AdminPanelModel
    {
        [BindProperty]  // Füge diese Zeile hinzu!
        public string TeacherCode { get; set; } = "";

        // Lädt den Lehrer-Code aus der DB
        public async Task LoadDataAsync(ApplicationDbContext context)
        {
            var registrationEntry = await context.Registrierung.FindAsync(1);
            TeacherCode = registrationEntry?.RegPasswort ?? "";
        }

        // Speichert den Lehrer-Code in der DB
        public async Task SaveDataAsync(ApplicationDbContext context)
        {
            var registrationEntry = await context.Registrierung.FindAsync(1);
            if (registrationEntry != null)
            {
                registrationEntry.RegPasswort = TeacherCode;
                await context.SaveChangesAsync();
            }
        }
    }
}
