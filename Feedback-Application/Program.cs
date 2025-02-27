using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString f�r MySQL holen
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext f�r MySQL registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();


// Razor Pages hinzuf�gen
builder.Services.AddRazorPages();

public static async Task InitializeRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roleNames = { "Admin", "Lehrer" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
            Console.WriteLine($"Rolle '{roleName}' wurde erstellt.");
        }
    }
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Wendet ausstehende Migrations automatisch an
}

// Testabfrage nach dem Aufbau der Anwendung
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Test-Select f�r die Tabelle 'Rolle' durchf�hren
    var rollen = dbContext.Rolle.ToList(); // Alle Eintr�ge aus der Tabelle 'Rolle'

    Console.WriteLine($"Gefundene Rollen: {rollen.Count}");
    foreach (var rolle in rollen)
    {
        Console.WriteLine($"RollenID: {rolle.RollenID}, Rolle: {rolle.Rolle}");
    }
}



// HTTP-Request-Pipeline konfigurieren
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Standard-HSTS-Konfiguration
}

app.UseHttpsRedirection(); //Https Redirects
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity-Authentifizierung aktivieren
app.UseAuthorization();

app.MapRazorPages(); // Razor Pages aktivieren

app.Run();
