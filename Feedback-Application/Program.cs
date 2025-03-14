using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Feedback_Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString für MySQL holen
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext für MySQL registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));


// Identity mit Rollenunterstützung registrieren
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Token für Passwort-Reset etc.

builder.Services.AddRazorPages();

var app = builder.Build();

// HTTP-Request-Pipeline konfigurieren
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Rollen beim Start der App sicherstellen (erst nach app.Build())
await app.Services.EnsureRolesCreatedAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // WICHTIG für Identity-Routen

app.Run();
