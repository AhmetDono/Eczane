using DataAccessLayer.Concrete;
using E_czane.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<RoleManager<AppRole>>();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Auth/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        option.SlidingExpiration = true;
    });

    builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
    {
        options.LoginPath = "/Auth/Login";
    });

//builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
//{
//    options.LoginPath = "/Login/Index";
//});


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

app.UseEndpoints(endpoints =>
{
    // Area-based routing should be defined before the default controller route.
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    // Default controller route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    }
    catch (Exception ex)
    {
        // Hata durumunu ele al
    }
}

app.Run();
