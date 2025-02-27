//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Feedback_Application.Areas.Identity;
using Feedback_Application;
//using Feedback_Application.Pages.Functions;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNetCore.Authentication.Cookies;
//using BCrypt.Net;
var builder = WebApplication.CreateBuilder(args);


// ConnectionString für MySQL holen
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext für MySQL registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Konfigurieren von Identity, um ApplicationUser zu verwenden
//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.User.RequireUniqueEmail = false;
//})
//    .AddEntityFrameworkStores<ApplicationDbContext>();

// Passwort-Hashing-Service
//builder.Services.AddSingleton<PasswortService>();



//string password = "feedbackD"; // Das Passwort des Benutzers
//string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
//Console.WriteLine(hashedPassword);

// Cookie-Authentifizierung einrichten
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";  // Der Pfad zur Login-Seite
        options.LogoutPath = "/Identity/Account/Logout"; // Logout-Pfad
    });



// Razor Pages hinzufügen
builder.Services.AddRazorPages();

var app = builder.Build();


// HTTP-Request-Pipeline konfigurieren
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
