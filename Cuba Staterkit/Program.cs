using Cuba_Staterkit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.AspNetCore.Identity;
using Cuba_Staterkit.RepoServices;
using Microsoft.Extensions.DependencyInjection;
using Cuba_Staterkit.Models;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
{
    // Configure logging for EF Core
    var serviceProvider = builder.Services.BuildServiceProvider();

    var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

    loggerFactory.AddProvider(new DebugLoggerProvider());

    options.UseSqlServer(connectionString);
});

builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    PreventDuplicates = true,
    CloseButton=true
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Services registration  
builder.Services.AddScoped<IQuiz, QuizRepoService>();
builder.Services.AddScoped<IClassSession, SessionRepoService>();
builder.Services.AddScoped<IQuestion, QuestionRepoService>();
builder.Services.AddScoped<IHomeWork, HomeWorkRepoService>();

// injection 
builder.Services.AddScoped<IQuiz, QuizRepoService>();
builder.Services.AddScoped<IClassSession, SessionRepoService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Ensure this path matches your custom login route
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapAreaControllerRoute(
             name: "default",
             areaName: "Identity",
             pattern: "{controller=Account}/{action=Login}");

app.MapRazorPages();

app.Run();
