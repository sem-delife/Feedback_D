// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Feedback_Application.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(ILogger<LogoutModel> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            try
            {
                _logger.LogInformation("Logout attempt started.");

                // Logge den Benutzer aus
                await HttpContext.SignOutAsync();

                _logger.LogInformation("User has been logged out.");

                // Weiterleitung zur Startseite oder zu einer bestimmten URL
                return Redirect(returnUrl ?? "/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Logout failed: {ex.Message}");
                return RedirectToPage("/Error"); // Fehlerseite
            }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                _logger.LogInformation("Logout attempt started.");

                // Logge den Benutzer aus
                await HttpContext.SignOutAsync();

                _logger.LogInformation("User has been logged out.");

                // Weiterleitung zur Startseite oder zu einer bestimmten URL
                return RedirectToPage(returnUrl ?? "/Index");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Logout failed: {ex.Message}");
                return RedirectToPage("/Error"); // Fehlerseite
            }
        }
    }
}