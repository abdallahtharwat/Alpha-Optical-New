using Alpha.DataAccess.Data;
using Alpha.DataAccess.Repository;
using Alpha.DataAccess.Repository.IRepository;
using ALpha.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;
using Alpha.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(
builder.Configuration.GetConnectionString("myconnection")
    ));

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()       //options => options.SignIn.RequireConfirmedAccount = true
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// must add after ( identity user)
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "194704029725997";
    option.AppSecret = "84d6e3a53dfa52fb72080d43d093a994";
});

builder.Services.AddAuthentication().AddMicrosoftAccount(option => {
    option.ClientId = "df8534d0-3105-4a11-b2b2-ec17051a8aa8";
    option.ClientSecret = "sad8Q~JZ4w4srCDevzmzPeCNCYV3DZYMOCybvbxG";
});

// add session for shoppingcart count
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();
app.UseAuthentication();;  // check if username or password is valid
app.UseAuthorization(); // you have access to website based on role you have access to some pages and not all the pahes
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();



void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}