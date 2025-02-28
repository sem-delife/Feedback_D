using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BCrypt.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Feedback_Application.Areas.Identity;
using Org.BouncyCastle.Crypto.Generators;

namespace Feedback_Application.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ApplicationDbContext context, ILogger<LoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Seite zum Login anzeigen
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Hole den Benutzer aus der Datenbank
                var benutzer = _context.Benutzer.FirstOrDefault(b => b.Username == Input.Username);

                if (benutzer != null)
                {
                    // �berpr�fe das Passwort (mit bcrypt gehasht)
                    if (VerifyPassword(benutzer.Passwort, Input.Password))
                    {
                        // Erstelle Claims (z.B. Benutzername und Rolle)
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, benutzer.Username),
                            new Claim(ClaimTypes.NameIdentifier, benutzer.UserID.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        // Melde den Benutzer an und setze das Authentifizierungscookie
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        _logger.LogInformation("User logged in.");
                        return RedirectToPage("/Index"); // Weiterleitung nach erfolgreichem Login
                    }
                    else
                    {
                        ErrorMessage = "Falsches Passwort.";
                    }
                }
                else
                {
                    ErrorMessage = "Benutzer nicht gefunden.";
                }
            }

            return Page(); // Zeige das Login-Formular mit einer Fehlermeldung
        }

        private bool VerifyPassword(string storedHash, string password)
        {
            // Passwort-Verifizierung mit bcrypt
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}