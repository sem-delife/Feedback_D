using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Feedback_Application;

var builder = WebApplication.CreateBuilder(args);

// ConnectionString für MySQL holen
var connectionString = builder.Configuration.GetConnectionString("FeedbackDb");

// DbContext für MySQL registrieren
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Identity-Registrierung mit DefaultIdentity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

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
app.MapControllers(); // WICHTIG für Identity-Routen

app.Run();
