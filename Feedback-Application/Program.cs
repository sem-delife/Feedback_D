using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString für MySQL holen
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext für MySQL registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();


// Razor Pages hinzufügen
builder.Services.AddRazorPages();

var app = builder.Build();




// Testabfrage nach dem Aufbau der Anwendung
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Test-Select für die Tabelle 'Rolle' durchführen
    var rollen = dbContext.Rolle.ToList(); // Alle Einträge aus der Tabelle 'Rolle'

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Identity-Authentifizierung aktivieren
app.UseAuthorization();

app.MapRazorPages(); // Razor Pages aktivieren

app.Run();
