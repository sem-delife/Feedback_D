using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Feedback_Application.Areas.Admin.Pages.Shared;  // Für das AdminPanelModel
using Feedback_Application.Pages.Models;

namespace Feedback_Application.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            AdminPanel = new AdminPanelModel();
        }

        // Profildaten und Admin Panel Model
        public string Username { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        // Admin Panel (Lehrer-Code)
        public AdminPanelModel AdminPanel { get; set; } = new AdminPanelModel();

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        // Laden der Profildaten
        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        // Laden der Admin-Daten (Lehrer-Code)
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            // Admin Panel mit Lehrer-Code laden
            AdminPanel = new AdminPanelModel();
            await AdminPanel.LoadDataAsync(_context);

            return Page(); // WICHTIG: Eine IActionResult-Rückgabe ist erforderlich
        }



        // Aktualisieren der Profil- und Admin-Daten
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            // Speichern des Lehrer-Codes
            await AdminPanel.SaveDataAsync(_context);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAdminPanelAsync([FromForm] string TeacherCode)
        {
            Console.WriteLine("OnPostAdminPanelAsync wurde aufgerufen!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState ist ungültig!");
                await LoadAsync(await _userManager.GetUserAsync(User));
                return Page();
            }

            // Sicherstellen, dass AdminPanel existiert
            if (AdminPanel == null)
            {
                AdminPanel = new AdminPanelModel();
            }

            Console.WriteLine($"Neuer Lehrer-Code: {TeacherCode}");

            // Lehrer-Code setzen und speichern
            AdminPanel.TeacherCode = TeacherCode;
            await AdminPanel.SaveDataAsync(_context);

            StatusMessage = "Lehrer-Code wurde erfolgreich aktualisiert!";
            return RedirectToPage();
        }

    }
}
