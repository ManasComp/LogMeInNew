using System.Globalization;
using System.Net.Mime;
using LogMeIn.Areas.Visitor.Controllers;
using LogMeIn.Data.Data;
using LogMeIn.Data.DbInitializer;
using LogMeIn.Data.Repositories;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using LogMeIn.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
//         o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    }
);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.ConsentCookieValue = "true";
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHealthChecks();
builder.Services.AddTransient<CustomError>();

var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePages(MediaTypeNames.Text.Plain, "Nastala chyba s kódemm {0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.UseSession();
app.MapRazorPages();

app.UseMiddleware<CustomError>();

app.MapControllerRoute(
    "default",
    "{area=Visitor}/{controller=Home}/{action=Index}/{catRegistrationId?}");

SeedDatabase();

app.Run();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("cs-CZ")
};
var locationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("cs-CZ"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
app.UseRequestLocalization(locationOptions);

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<IDbInitializer>().Initialize();
    }
}