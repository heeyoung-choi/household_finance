using FinanceManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinanceManagement.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true; // Allow users to have the same email
    options.SignIn.RequireConfirmedEmail = true; // Don't require email confirmation
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("require-admin-role", policy => policy.RequireRole("admin")); // Define policy
});

builder.Services.AddRazorPages(
options =>
{
    options.Conventions.AuthorizeAreaFolder("AdminPanel", "/", "require-admin-role");
}
);
builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false; // Don't require numbers
    options.Password.RequireLowercase = false; // Don't require lowercase letters
    options.Password.RequireNonAlphanumeric = false; // Don't require special characters
    options.Password.RequireUppercase = false; // Don't require uppercase letters
    options.Password.RequiredLength = 4; // Minimum 4 characters
    options.Password.RequiredUniqueChars = 1; // Keep at least 1 unique character

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // Ensure unique emails
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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