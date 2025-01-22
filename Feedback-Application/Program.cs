using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Feedback_Application.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString f�r die Datenbank
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false; 
}).AddEntityFrameworkStores<ApplicationDbContext>(); 

// Razor Pages hinzuf�gen
builder.Services.AddRazorPages();

var app = builder.Build();

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
